Imports System.Xml.Serialization
Imports System.IO
Imports System.Xml
Imports System.Text

Namespace ESLWirePlugIn.MatchReminder
  Public Class Config
    Private Shared ReadOnly Serializer As New XmlSerializer(GetType(Config))
    Private Shared ReadOnly [NameSpace] As XmlSerializerNamespaces = BuildNamespace()

    Public Const DefaultTtsRate As Integer = - 1
    Public Const DefaultTtsVolume As Integer = 100

    <XmlElement("Notifications")>
    Public Notifications As List(Of NotificationSetting)

    <XmlElement("EnableNotifications")>
    Public EnableNotifications As Boolean

    <XmlElement("EnableVoiceAnnouncement")>
    Public EnableVoiceAnnouncement As Boolean

    <XmlElement("EnableBalloonNotification")>
    Public EnableBalloonNotification As Boolean

    <XmlElement("EnableInGameNotification")>
    Public EnableInGameNotification As Boolean

    <XmlElement("ShowTrayIcon")>
    Public ShowTrayIcon As Boolean

    <XmlElement("TTSVolume")>
    Public TtsVolume As Int32

    <XmlElement("TTSRate")>
    Public TtsRate As Int32

    <XmlElement("TTSVoice")>
    Public TtsVoice As String

    Public Sub New()
      Me.Notifications = New List(Of NotificationSetting)
      Me.EnableNotifications = True
      Me.EnableVoiceAnnouncement = True
      Me.EnableBalloonNotification = True
      Me.EnableInGameNotification = True
      Me.ShowTrayIcon = True
      Me.TTSVolume = 100
      Me.TtsRate = - 1
      Me.TTSVoice = ""
    End Sub

    Private Shared Function BuildNamespace() As XmlSerializerNamespaces
      Dim Erg As New XmlSerializerNamespaces

      Call Erg.Add("", "")

      Return Erg
    End Function

    Public Sub CopyTo(ByVal Config As Config)
      With Config
        Call .Notifications.Clear()
        .Notifications.AddRange(Me.Notifications)

        .EnableNotifications = Me.EnableNotifications
        .EnableVoiceAnnouncement = Me.EnableVoiceAnnouncement
        .EnableBalloonNotification = Me.EnableBalloonNotification
        .EnableInGameNotification = Me.EnableInGameNotification
        .ShowTrayIcon = Me.ShowTrayIcon
        .TtsVolume = Me.TtsVolume
        .TtsRate = Me.TtsRate
        .TtsVoice = Me.TtsVoice
      End With
    End Sub

    Public Sub Validate()
      If Me.TtsVolume < 0 OrElse Me.TtsVolume > 100 Then Me.TtsVolume = DefaultTTSVolume
      If Me.TtsRate < - 10 OrElse Me.TtsRate > 10 Then Me.TtsRate = DefaultTtsRate

      With Me.Notifications.GetEnumerator()
        Do While .MoveNext()
          Call .Current.Validate()
        Loop
        Call .Dispose()
      End With
    End Sub

    Public Shared Function Read(ByVal Path As String,
                                ByRef Config As Config,
                                Optional ByRef Ex As Exception = Nothing) As Boolean
      Ex = Nothing
      Config = Nothing

      If String.IsNullOrEmpty(Path) Then
        Ex = New ArgumentNullException("Path")
      ElseIf Not File.Exists(Path) Then
        Ex = New FileNotFoundException(Path)
      Else
        Dim Stream As Stream = Nothing

        Try
          Stream = New FileStream(Path, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read)

          If Stream IsNot Nothing Then
            Dim Reader As New XmlTextReader(Stream)
            Reader.Namespaces = True

            Config = DirectCast(Serializer.Deserialize(Reader), Config)
            Call Reader.Close()

            With Stream
              Call .Close()
              Call .Dispose()
            End With
          End If

          Call Config.Validate()
        Catch iEx As Exception
          If Stream IsNot Nothing Then
            With Stream
              Call .Close()
              Call .Dispose()
            End With
          End If
          Ex = iEx
        End Try
      End If

      Return (Ex Is Nothing)
    End Function

    Public Shared Function Write(ByVal Path As String,
                                 ByVal Config As Config,
                                 Optional ByRef Ex As Exception = Nothing) As Boolean
      Ex = Nothing
      Dim FileStream As FileStream = Nothing

      Try
        Dim Writer As XmlTextWriter
        Dim Stream As MemoryStream

        Stream = New MemoryStream
        Writer = New XmlTextWriter(Stream, Encoding.UTF8)

        With Writer
          .Formatting = Formatting.Indented
          .IndentChar = " "c
          .Indentation = 2
          .Namespaces = False
        End With

        Call Serializer.Serialize(Writer, Config, [NameSpace])

        FileStream = New FileStream(Path, FileMode.Create, FileAccess.Write, FileShare.Read)
        Call Stream.WriteTo(FileStream)

        With FileStream
          Call .Flush()
          Call .Close()
          Call .Dispose()
        End With

        If Stream IsNot Nothing Then
          With Stream
            Call .Flush()
            Call .Close()
            Call .Dispose()
          End With
        End If
      Catch iEx As Exception
        If FileStream IsNot Nothing Then
          With FileStream
            Call .Flush()
            Call .Close()
            Call .Dispose()
          End With
        End If
        Ex = iEx
      End Try

      Return (Ex Is Nothing)
    End Function
  End Class
End Namespace