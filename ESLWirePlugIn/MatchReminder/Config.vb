' NuGardt ESL Wire Plugin Match Reminder
' Copyright (C) 2012 NuGardt Software
' http://www.nugardt.com
'
' This program is free software: you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation, either version 3 of the License, or
' (at your option) any later version.
'
' This program is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License
' along with this program.  If not, see <http://www.gnu.org/licenses/>.
'
Imports System.Xml.Serialization
Imports System.IO
Imports System.Xml
Imports System.Text

Namespace ESLWirePlugIn.MatchReminder
  Public Class Config
    Implements IConfig

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

      Call Me.Reset()
    End Sub

    Public Sub Reset()
      Call Me.Notifications.Clear()

      With Me.Notifications
        Call .Clear()

        Call .Add(New NotificationSetting(0, NotificationSetting.DefaultMessageFormat, True, True, True, 30))
        Call .Add(New NotificationSetting(60, NotificationSetting.DefaultMessageFormat, True, True, False, 30))
        Call .Add(New NotificationSetting(300, NotificationSetting.DefaultMessageFormat, True, True, True, 30))
        Call .Add(New NotificationSetting(600, NotificationSetting.DefaultMessageFormat, True, True, False, 30))
      End With

      Me.EnableNotifications = True
      Me.EnableVoiceAnnouncement = True
      Me.EnableBalloonNotification = True
      Me.EnableInGameNotification = True
      Me.ShowTrayIcon = True
      Me.TtsVolume = 100
      Me.TtsRate = - 1
      Me.TtsVoice = ""
    End Sub

    Private Shared Function BuildNamespace() As XmlSerializerNamespaces
      Dim Erg As New XmlSerializerNamespaces

      Call Erg.Add("", "")

      Return Erg
    End Function

    Public Sub CopyTo(ByVal Config As Config)
      With Config
        Call .Notifications.Clear()
        Call .Notifications.AddRange(Me.Notifications)

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
      If Me.TtsVolume < 0 OrElse Me.TtsVolume > 100 Then Me.TtsVolume = DefaultTtsVolume
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

#Region "Properties"

    Private Property iEnableBalloonNotification As Boolean Implements IConfig.EnableBalloonNotification
      Get
        Return Me.EnableBalloonNotification
      End Get
      Set(Value As Boolean)
        Me.EnableBalloonNotification = Value
      End Set
    End Property

    Private Property iEnableInGameNotification As Boolean Implements IConfig.EnableInGameNotification
      Get
        Return Me.EnableInGameNotification
      End Get
      Set(Value As Boolean)
        Me.EnableInGameNotification = Value
      End Set
    End Property

    Private Property iEnableNotifications As Boolean Implements IConfig.EnableNotifications
      Get
        Return Me.EnableNotifications
      End Get
      Set(Value As Boolean)
        Me.EnableNotifications = Value
      End Set
    End Property

    Private Property iEnableVoiceAnnouncement As Boolean Implements IConfig.EnableVoiceAnnouncement
      Get
        Return Me.EnableVoiceAnnouncement
      End Get
      Set(Value As Boolean)
        Me.EnableVoiceAnnouncement = Value
      End Set
    End Property

    Private Property iNotifications As List(Of NotificationSetting) Implements IConfig.Notifications
      Get
        Return Me.Notifications
      End Get
      Set(Value As List(Of NotificationSetting))
        Me.Notifications = Value
      End Set
    End Property

    Private Property iShowTrayIcon As Boolean Implements IConfig.ShowTrayIcon
      Get
        Return Me.ShowTrayIcon
      End Get
      Set(Value As Boolean)
        Me.ShowTrayIcon = Value
      End Set
    End Property

    Private Property iTtsRate As Integer Implements IConfig.TtsRate
      Get
        Return Me.TtsRate
      End Get
      Set(Value As Integer)
        Me.TtsRate = Value
      End Set
    End Property

    Private Property iTtsVoice As String Implements IConfig.TtsVoice
      Get
        Return Me.TtsVoice
      End Get
      Set(Value As String)
        Me.TtsVoice = Value
      End Set
    End Property

    Private Property iTtsVolume As Integer Implements IConfig.TtsVolume
      Get
        Return Me.TtsVolume
      End Get
      Set(Value As Integer)
        Me.TtsVolume = Value
      End Set
    End Property

#End Region
  End Class
End Namespace