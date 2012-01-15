Imports System.Xml.Serialization

Namespace ESLWirePlugIn.MatchReminder
  Public Class NotificationSetting
    Implements IComparable(Of NotificationSetting)

    Public Shared ReadOnly DefaultNotifyTimeBeforeMatch As Int32 = 1 * 60
    Public Shared ReadOnly DefaultNotificationDuration As Int32 = 30
    Public Shared ReadOnly MinPriorTime As TimeSpan = TimeSpan.FromSeconds(0 - (60 * 30))
    Public Shared ReadOnly MaxPriorTime As TimeSpan = TimeSpan.FromSeconds(24 * 60 * 60)
    Public Shared ReadOnly MinNotificationDurationTime As TimeSpan = TimeSpan.FromSeconds(1)
    Public Shared ReadOnly MaxNotificationDurationTime As TimeSpan = TimeSpan.FromSeconds(60 * 60)
    Public Const DefaultMessageFormat As String = "Your match $name$ in $gametitle$ is in $timeremaining$."
    Public Const DefaultNotifyInGame As Boolean = True
    Public Const DefaultShowBaloon As Boolean = True
    Public Const DefaultVoiceAnnounce As Boolean = True

    Private ID As Guid

    <XmlElement("NotifyTimeBeforeMatchInSeconds")>
    Public NotifyTimeBeforeMatch As Int32

    <XmlElement("NotificationDurationInSeconds")>
    Public NotificationDuration As Int32

    <XmlElement("ShowInGameNotification")>
    Public ShowInGameNotification As Boolean

    <XmlElement("ShowBaloonNotification")>
    Public ShowBaloonNotification As Boolean

    <XmlElement("VoiceAnnounce")>
    Public VoiceAnnounce As Boolean

    <XmlElement("MessageFormat")>
    Public MessageFormat As String

#Region "Compare"

    Public Function CompareTo(Other As NotificationSetting) As Integer Implements IComparable(Of NotificationSetting).CompareTo
      Return CompareByNotifyBeforeMatch(Me, Other)
    End Function

    Public Shared Function CompareByNotifyBeforeMatch(ByVal X As NotificationSetting,
                                                      ByVal Y As NotificationSetting) As Integer
      Dim Erg As Integer = 0

      If (X IsNot Nothing) Then
        If (Y IsNot Nothing) Then
          Erg = X.NotifyTimeBeforeMatch.CompareTo(Y.NotifyTimeBeforeMatch)
          If Erg = 0 Then Erg = X.ID.CompareTo(Y.ID)
        Else
          Erg = 1
        End If
      ElseIf (Y IsNot Nothing) Then
        Erg = - 1
      End If

      Return Erg
    End Function

#End Region

    Public Sub New()
      Me.ID = Guid.NewGuid()
      Me.NotifyTimeBeforeMatch = DefaultNotifyTimeBeforeMatch
      Me.NotificationDuration = DefaultNotificationDuration
      Me.MessageFormat = DefaultMessageFormat
      Me.ShowInGameNotification = DefaultNotifyInGame
      Me.ShowBaloonNotification = DefaultShowBaloon
      Me.VoiceAnnounce = DefaultVoiceAnnounce
    End Sub

    Public Sub New(ByVal TimeBeforeMatch As Int32,
                   ByVal MessageFormat As String,
                   ByVal NotifyInGame As Boolean,
                   ByVal ShowBaloon As Boolean,
                   ByVal NotificationDuration As Int32)
      Me.NotifyTimeBeforeMatch = TimeBeforeMatch
      Me.MessageFormat = MessageFormat
      Me.ShowInGameNotification = NotifyInGame
      Me.ShowBaloonNotification = ShowBaloon
      Me.NotificationDuration = NotificationDuration
    End Sub

    Public Sub Validate()
      Dim tTime As TimeSpan

      tTime = TimeSpan.FromSeconds(Me.NotifyTimeBeforeMatch)
      If tTime < MinPriorTime AndAlso tTime > MaxPriorTime Then Me.NotifyTimeBeforeMatch = DefaultNotifyTimeBeforeMatch

      tTime = TimeSpan.FromSeconds(Me.NotificationDuration)
      If tTime < MinNotificationDurationTime AndAlso tTime > MaxNotificationDurationTime Then Me.NotificationDuration = DefaultNotificationDuration

      If Not String.IsNullOrEmpty(Me.MessageFormat) AndAlso Me.MessageFormat.Length > 1024 Then Me.MessageFormat = Me.MessageFormat.Substring(0, 1024)
    End Sub
  End Class
End Namespace