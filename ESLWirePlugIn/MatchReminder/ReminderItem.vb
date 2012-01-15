Namespace ESLWirePlugIn.MatchReminder
  Friend Structure ReminderItem
    Public ReadOnly Match As Match
    Public ReadOnly Annouce As DateTime
    Public ReadOnly NotificationDurationInSeconds As Integer
    Public ReadOnly Message As String

    Public ReadOnly ShowInGame As Boolean
    Public ReadOnly ShowBalloon As Boolean
    Public ReadOnly VoiceAnnounce As Boolean

    Public Sub New(ByVal Match As Match,
                   ByVal Annouce As DateTime,
                   ByVal NotificationDurationInSeconds As Integer,
                   ByVal Message As String,
                   ByVal ShowInGame As Boolean,
                   ByVal ShowBalloon As Boolean,
                   ByVal VoiceAnnounce As Boolean)
      Me.Match = Match
      Me.Annouce = Annouce
      Me.NotificationDurationInSeconds = NotificationDurationInSeconds
      Me.Message = Message

      Me.ShowInGame = ShowInGame
      Me.ShowBalloon = ShowBalloon
      Me.VoiceAnnounce = VoiceAnnounce
    End Sub

    Public Function IsExpired(ByVal JustNow As DateTime) As Boolean
      If Me.Annouce <= JustNow Then
        Return True
      Else
        Return False
      End If
    End Function
  End Structure
End Namespace