' NuGardt ESL Wire Plugin Match Reminder
' Copyright (C) 2012-2013 NuGardt Software
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
Imports System.Reflection
Imports System.Windows.Forms
Imports System.Threading
Imports System.Speech.Synthesis
Imports Wire

Namespace ESLWirePlugIn.MatchReminder
  Friend Class Scheduler
    Inherits Disposable

    Private Const DefaultTrayText As String = "ESL Wire Match Reminder"
    Private Shared ReadOnly ConfigPath As String = Assembly.GetExecutingAssembly.Location + ".config.xml"

    Private ReadOnly LockObject As Object

    Friend Settings As Config

    Private WithEvents TrayNotification As NotifyIcon
    Friend WithEvents GI As GameInterface
    Private ReadOnly Plugin As Plugin

    Private ReadOnly QueueReminders As Queue(Of ReminderItem)
    Private ActiveMatchID As Nullable(Of Integer)

    Private WorkerThread As Thread
    Private ReadOnly Speech As SpeechSynthesizer
    Friend ReadOnly ContextMenuStrip As ContextMenuStrip
    Private WithEvents MenuDescription As ToolStripLabel
    Private WithEvents MenuSettings As ToolStripMenuItem
    Private WithEvents MenuDeactivateNotification As ToolStripDropDownButton
    Private WithEvents MenuDeactivateNotification5Minutes As ToolStripMenuItem
    Private WithEvents MenuDeactivateNotification10Minutes As ToolStripMenuItem
    Private WithEvents MenuDeactivateNotification30Minutes As ToolStripMenuItem
    Private WithEvents MenuDeactivateNotificationReactivate As ToolStripMenuItem
    Private WithEvents MenuAbout As ToolStripMenuItem
    Private DisableNotificationsTill As Nullable(Of DateTime)

    Public Sub New(ByVal Plugin As Plugin)
      Me.LockObject = Me.GetType().ToString()

      Me.Plugin = Plugin
      Me.GI = InterfaceFactory.gameInterface()
      Me.MenuDescription = New ToolStripLabel(DefaultTrayText)
      Me.MenuDescription.Enabled = False
      Me.MenuSettings = New ToolStripMenuItem("Settings")
      Me.MenuDeactivateNotification = New ToolStripDropDownButton("Deactivate notifications")
      Me.MenuDeactivateNotification5Minutes = New ToolStripMenuItem("For 5 minutes")
      Me.MenuDeactivateNotification10Minutes = New ToolStripMenuItem("For 10 minutes")
      Me.MenuDeactivateNotification30Minutes = New ToolStripMenuItem("For 30 minutes")
      Me.MenuDeactivateNotificationReactivate = New ToolStripMenuItem("Reactivate")
      Me.MenuDeactivateNotificationReactivate.Enabled = False
      With Me.MenuDeactivateNotification.DropDownItems
        Call .Add(Me.MenuDeactivateNotification5Minutes)
        Call .Add(Me.MenuDeactivateNotification10Minutes)
        Call .Add(Me.MenuDeactivateNotification30Minutes)
        Call .Add(New ToolStripSeparator())
        Call .Add(Me.MenuDeactivateNotificationReactivate)
      End With
      Me.MenuAbout = New ToolStripMenuItem("About")

      Me.ContextMenuStrip = New ContextMenuStrip()
      With Me.ContextMenuStrip.Items
        Call .Add(Me.MenuDescription)
        Call .Add(Me.MenuSettings)
        Call .Add(Me.MenuDeactivateNotification)
        Call .Add(New ToolStripSeparator())
        Call .Add(Me.MenuAbout)
      End With

      Me.TrayNotification = New NotifyIcon()
      With Me.TrayNotification
        .Icon = My.Resources.ICO_MatchReminder
        .Text = DefaultTrayText
        .BalloonTipTitle = DefaultTrayText
        .ContextMenuStrip = Me.ContextMenuStrip
      End With

      Me.Speech = New SpeechSynthesizer()
      Me.QueueReminders = New Queue(Of ReminderItem)()
      Me.ActiveMatchID = Nothing
    End Sub

    Public Function Start(Optional ByRef Ex As Exception = Nothing) As Boolean
      Ex = Nothing

      Try
        If Not Config.Read(ConfigPath, Me.Settings, Ex) Then
          Me.Settings = New Config()
          Call Me.Settings.Reset()
        End If

        AddHandler Me.GI.MatchListUpdated, OnMatchListUpdate
        AddHandler Me.GI.MatchStarted, OnMatchStarted
        AddHandler Me.GI.MatchEnded, OnMatchEnded

        Call Me.iApplyConfig(True, Me.Settings)
      Catch iEx As Exception
        Ex = iEx
      End Try

      Return (Ex Is Nothing)
    End Function

    Private Sub iStart()
      Call Me.OnMatchListUpdate()

      If Me.WorkerThread Is Nothing Then
        Me.WorkerThread = New Thread(AddressOf Me.Work)
        With Me.WorkerThread
          .Name = "com.NuGardt.ESLWirePlugin.MatchReminder"
          .IsBackground = True

          Call .Start()
        End With
      End If
    End Sub

    Protected Overrides Sub iDispose1()
      Do Until Me.WorkerThread Is Nothing
        Call Thread.Sleep(10)
      Loop

      If Me.GI IsNot Nothing Then
        SyncLock Me.LockObject
          RemoveHandler Me.GI.MatchListUpdated, OnMatchListUpdate
          RemoveHandler Me.GI.MatchStarted, OnMatchStarted
          RemoveHandler Me.GI.MatchEnded, OnMatchEnded

          Me.GI = Nothing
        End SyncLock
      End If

      Me.TrayNotification.Visible = False
      If Me.TrayNotification IsNot Nothing Then
        Call Me.TrayNotification.Dispose()
        Me.TrayNotification = Nothing
      End If

      Call Config.Write(ConfigPath, Me.Settings)
    End Sub

    Private Sub Work()
      Dim tSleep As Integer = 0
      Dim JustNow As DateTime
      Dim NextMatchMessage As String = Nothing
      Dim Reminder As ReminderItem

      Call Trace.WriteLine("Starting worker.")

      Try
        Do While Me.TestNotDisposed() AndAlso Me.Settings.EnableNotifications
          JustNow = Now

          If Not Me.DisableNotificationsTill.HasValue Then
            SyncLock Me.LockObject
              If Me.QueueReminders.Count > 0 Then
                If Me.QueueReminders.Peek().IsExpired(JustNow) Then
                  Reminder = Me.QueueReminders.Dequeue()

                  Call Me.ShowNotification(JustNow, Reminder)

                  NextMatchMessage = String.Format("Next match in {0}.", FormatTimeSpan(Reminder.Match.Time - JustNow))
                Else
                  NextMatchMessage = String.Format("Next match in {0}.", FormatTimeSpan(Me.QueueReminders.Peek.Match.Time - JustNow))
                End If
              End If

              If String.IsNullOrEmpty(NextMatchMessage) Then
                Call Me.SetTrayNotificationText(DefaultTrayText)
              Else
                Call Me.SetTrayNotificationText(NextMatchMessage)
              End If
              NextMatchMessage = Nothing
            End SyncLock
          ElseIf Me.DisableNotificationsTill.Value < JustNow Then
            Me.DisableNotificationsTill = Nothing
            Call Me.MatchListUpdate()

            Me.MenuDeactivateNotificationReactivate.Enabled = False
            Call Me.SayEvent("Notifications resumed.")
          End If

          'Wait for 500 miliseconds but quickly notice if the plugin is disposing.
          Do Until tSleep >= 500
            Call Thread.Sleep(100)
            tSleep += 100

            If Not Me.TestNotDisposed() Then Exit Do
          Loop
          tSleep = 0
        Loop
      Catch iEx As Exception
        Call Trace.WriteLine(iEx)
      End Try

      Call Trace.WriteLine("Worker ended.")

      Me.WorkerThread = Nothing
    End Sub

    Friend Sub ShowNotification(ByVal JustNow As DateTime,
                                ByVal Reminder As ReminderItem)

      If IsActiveMatch(Reminder.Match.ID) Then
        Dim Message As String

        Message = Reminder.Message.Replace("$timetomatch$", FormatTimeSpan(Reminder.Match.Time - JustNow))

        If Me.Settings.EnableInGameNotification AndAlso Reminder.ShowInGame Then Call Me.GI.showInGameNotification(Message, DefaultTrayText, Reminder.NotificationDurationInSeconds * 1000)
        If Me.Settings.EnableBalloonNotification AndAlso Reminder.ShowBalloon Then Call Me.TrayNotification.ShowBalloonTip(Reminder.NotificationDurationInSeconds * 1000, Me.TrayNotification.BalloonTipTitle, Message, ToolTipIcon.Info)
        If Me.Settings.EnableVoiceAnnouncement AndAlso Reminder.VoiceAnnounce AndAlso (Me.Speech.State = SynthesizerState.Ready) Then Call Me.Speech.SpeakAsync(FormatForVoice(Message))
      End If
    End Sub

    Private Shared Function FormatForVoice(ByVal Message As String) As String
      'Stupid roman numeral to number convert0r^^
      ' "StarCraft II" -> "StarCraft 2"
      ' ** Used for voice output
      Dim dictFormat As New Dictionary(Of String, String)

      Call dictFormat.Add(" II ", "2")
      Call dictFormat.Add(" III ", "3")
      Call dictFormat.Add(" IV ", "4")
      Call dictFormat.Add(" V ", "5")
      Call dictFormat.Add(" VI ", "6")
      Call dictFormat.Add(" VII ", "7")
      Call dictFormat.Add(" VIII ", "8")
      Call dictFormat.Add(" IX ", "9")
      Call dictFormat.Add(" X ", "10")
      Call dictFormat.Add(" XI ", "11")
      Call dictFormat.Add(" XII ", "12")
      Call dictFormat.Add(" XIII ", "13")
      Call dictFormat.Add(" XIV ", "14")
      Call dictFormat.Add(" XV ", "15")

      Return DictReplace(Message, dictFormat)
    End Function

    Private Sub SetTrayNotificationText(ByVal Message As String)
      Try
        If Not String.IsNullOrEmpty(Message) Then
          If Message.Length <= 63 Then
            Me.TrayNotification.Text = Message
          Else
            Me.TrayNotification.Text = Message.Substring(0, 63)
          End If
        End If
      Catch
        '-
      End Try
    End Sub

    Private Const DayInSeconds As Int32 = 24 * 60 * 60
    Private Const HourInSeconds As Int32 = 60 * 60
    Private Const MinuteInSeconds As Int32 = 60

    Private Shared Function FormatTimeSpan(ByVal TS As TimeSpan) As String
      Dim Erg As String = String.Empty
      Dim TotalSeconds As Int64 = Convert.ToInt64(TS.TotalSeconds)
      Dim tDay As Int64
      Dim tHour As Int64
      Dim tMinute As Int64
      Dim tSecond As Int64

      tDay = TotalSeconds \ DayInSeconds
      tHour = (TotalSeconds - (tDay * DayInSeconds)) \ HourInSeconds
      tMinute = (TotalSeconds - (tDay * DayInSeconds) - (tHour * HourInSeconds)) \ MinuteInSeconds
      tSecond = (TotalSeconds - (tDay * DayInSeconds) - (tHour * HourInSeconds) - (tMinute * MinuteInSeconds))

      If TotalSeconds > DayInSeconds Then
        If tDay = 1 Then
          Erg += String.Format("{0} day ", tDay)
        Else
          Erg += String.Format("{0} days ", tDay)
        End If
      ElseIf TotalSeconds > HourInSeconds Then
        If tHour <> 0 Then
          If tHour = 1 Then
            Erg += String.Format("{0} hour ", tHour)
          Else
            Erg += String.Format("{0} hours ", tHour)
          End If
        End If
      End If

      If tMinute <> 0 Then
        If tMinute = 1 Then
          Erg += String.Format("{0} minute ", tMinute)
        Else
          Erg += String.Format("{0} minutes ", tMinute)
        End If
      End If

      If tSecond <> 0 Then
        If tSecond = 1 Then
          Erg += String.Format("{0} second", tSecond)
        Else
          Erg += String.Format("{0} seconds", tSecond)
        End If
      End If

      If String.IsNullOrEmpty(Erg) Then Erg = "now"

      Return Erg.Trim
    End Function

    Private ReadOnly OnMatchListUpdate As GameInterface.MatchListUpdatedHandler = AddressOf Me.MatchListUpdate

    Private Sub MatchListUpdate()
      Dim tMatch As Match = Nothing
      Dim tReminders As New List(Of ReminderItem)

      With Me.GI.matches.GetEnumerator()
        Call .Reset()

        Do While .MoveNext()
          If Match.ToMatch(DirectCast(.Current, IDictionary), tMatch) Then Call tReminders.AddRange(Me.GenerateMatchReminders(tMatch))
        Loop
      End With

      Call tReminders.Sort(AddressOf ReminderItem.CompareByAnnounce)

      SyncLock Me.LockObject
        Call Me.QueueReminders.Clear()

        With tReminders.GetEnumerator()
          Do While .MoveNext()
            Call Me.QueueReminders.Enqueue(.Current)
          Loop

          Call .Dispose()
        End With
      End SyncLock
    End Sub

    Public Function FormatMessage(ByVal Match As Match,
                                  ByVal MessageFormat As String,
                                  Optional ByVal ProcessTimeRemaining As Boolean = False) As String
      Dim dictFormat As New Dictionary(Of String, String)

      If Not dictFormat.ContainsKey("$aequitasId$") Then Call dictFormat.Add("$aequitasId$", Match.AequitasId)
      If Not dictFormat.ContainsKey("$gameid$") Then Call dictFormat.Add("$gameid$", Match.GameId.ToString())
      If Not dictFormat.ContainsKey("$gametitle$") Then Call dictFormat.Add("$gametitle$", Match.GameTitle)
      If Not dictFormat.ContainsKey("$id$") Then Call dictFormat.Add("$id$", Match.ID.ToString())
      If Not dictFormat.ContainsKey("$leaguecountry$") Then Call dictFormat.Add("$leaguecountry$", Match.LeagueCountry)
      If Not dictFormat.ContainsKey("$leagueid$") Then Call dictFormat.Add("$leagueid$", Match.LeagueId.ToString())
      If Not dictFormat.ContainsKey("$leaguename$") Then Call dictFormat.Add("$leaguename$", Match.LeagueName)
      If Not dictFormat.ContainsKey("$mode$") Then Call dictFormat.Add("$mode$", Match.Mode)
      If Not dictFormat.ContainsKey("$name$") Then Call dictFormat.Add("$name$", Match.Name)
      If Not dictFormat.ContainsKey("$time$") Then Call dictFormat.Add("$time$", Match.Time.ToString())
      If Not dictFormat.ContainsKey("$uri$") Then Call dictFormat.Add("$uri$", Match.Uri)

      If ProcessTimeRemaining AndAlso Not dictFormat.ContainsKey("$timetomatch$") Then Call dictFormat.Add("$timetomatch$", FormatTimeSpan(Match.Time - Now))

      Return DictReplace(MessageFormat, dictFormat)
    End Function

    Private Function GenerateMatchReminders(ByVal Match As Match) As IEnumerable(Of ReminderItem)
      Dim JustNow As DateTime = Now
      Dim Erg As New List(Of ReminderItem)

      SyncLock Me.LockObject
        With Me.Settings.Notifications.GetEnumerator()
          Do While .MoveNext()
            If Match.Time.AddSeconds(0 - .Current.NotifyTimeBeforeMatch) > JustNow Then Call Erg.Add(New ReminderItem(Match, Match.Time.AddSeconds(0 - .Current.NotifyTimeBeforeMatch), .Current.NotificationDuration, FormatMessage(Match, .Current.MessageFormat), .Current.ShowInGameNotification, .Current.ShowBaloonNotification, .Current.VoiceAnnounce))
          Loop

          Call .Dispose()
        End With
      End SyncLock

      Return Erg
    End Function

    Private Shared Function DictReplace(ByVal Format As String,
                                        ByVal DictValues As IEnumerable(Of KeyValuePair(Of String, String))) As String
      With DictValues.GetEnumerator()
        Call .Reset()

        Do While .MoveNext()
          Format = Format.Replace(.Current.Key, .Current.Value)
        Loop

        Call .Dispose()
      End With

      Return Format
    End Function

    Private ReadOnly OnMatchStarted As GameInterface.MatchStartedHandler = AddressOf Me.MatchStarted

    Private Sub MatchStarted(ByVal MatchID As Integer,
                             ByVal MatchMediaPath As String)
      SyncLock Me.LockObject
        Me.ActiveMatchID = MatchID
      End SyncLock
    End Sub

    Private ReadOnly OnMatchEnded As GameInterface.MatchEndedHandler = AddressOf Me.MatchEnded

    Private Sub MatchEnded(ByVal MatchID As Integer)
      SyncLock Me.LockObject
        Me.ActiveMatchID = Nothing
      End SyncLock
    End Sub

    Private Function IsActiveMatch(ByVal MatchID As Integer) As Boolean
      SyncLock Me.LockObject
        Return Me.ActiveMatchID.HasValue = False OrElse Me.ActiveMatchID.Value <> MatchID
      End SyncLock
    End Function

    Friend Sub SayEvent(ByVal Message As String)
      If Me.Settings.EnableVoiceAnnouncement Then
        Call Me.Speech.SpeakAsyncCancelAll()
        Call Me.Speech.SpeakAsync(Message)
      End If
    End Sub

    Public Sub ApplyConfig(ByVal Config As Config)
      SyncLock Me.LockObject
        Call Me.iApplyConfig(False, Config)

        Call Config.CopyTo(Me.Settings)

        Call Config.Write(ConfigPath, Me.Settings)

        Call Me.SayEvent("Settings saved.")
      End SyncLock
    End Sub

    Private Sub iApplyConfig(ByVal IsStartUp As Boolean,
                             ByVal Config As Config)
      Me.TrayNotification.Visible = Config.ShowTrayIcon

      With Me.Speech
        .Rate = Config.TtsRate
        .Volume = Config.TtsVolume

        Try
          Call .SelectVoice(Config.TtsVoice)
        Catch
          Call .SelectVoice(.GetInstalledVoices.Item(0).VoiceInfo.Name)
          Config.TtsVoice = .Voice.Name
        End Try
      End With

      If (Not Me.Settings.EnableNotifications OrElse IsStartUp) AndAlso Config.EnableNotifications Then Call Me.iStart()
    End Sub

    Public ReadOnly Property ListNotificationSettings() As List(Of NotificationSetting)
      Get
        SyncLock Me.LockObject
          Return New List(Of NotificationSetting)(Me.Settings.Notifications)
        End SyncLock
      End Get
    End Property

    Private Sub mnuSettings_Click(Sender As Object,
                                  e As EventArgs) Handles MenuSettings.Click
      Call Me.Plugin.OpenSettings()
    End Sub

    Private Sub mnuAbout_Click(Sender As Object,
                               e As EventArgs) Handles MenuAbout.Click
      Call Me.Plugin.OpenAbout()
    End Sub

    Private Sub mnuDisableNotification5Minutes_Click(Sender As Object,
                                                     e As EventArgs) Handles MenuDeactivateNotification5Minutes.Click
      Me.DisableNotificationsTill = Now.AddMinutes(5)
      Me.MenuDeactivateNotificationReactivate.Enabled = True
      Call Trace.WriteLine("Notifications will recomence at " + Me.DisableNotificationsTill.Value.ToString())

      Call Me.SayEvent("Notifications deactivated for 5 minutes.")
    End Sub

    Private Sub mnuDisableNotification10Minutes_Click(Sender As Object,
                                                      e As EventArgs) Handles MenuDeactivateNotification10Minutes.Click
      Me.DisableNotificationsTill = Now.AddMinutes(10)
      Me.MenuDeactivateNotificationReactivate.Enabled = True
      Call Trace.WriteLine("Notifications will recomence at " + Me.DisableNotificationsTill.Value.ToString())

      Call Me.SayEvent("Notifications deactivated for 10 minutes.")
    End Sub

    Private Sub mnuDisableNotification30Minutes_Click(Sender As Object,
                                                      e As EventArgs) Handles MenuDeactivateNotification30Minutes.Click
      Me.DisableNotificationsTill = Now.AddMinutes(30)
      Me.MenuDeactivateNotificationReactivate.Enabled = True
      Call Trace.WriteLine("Notifications will recomence at " + Me.DisableNotificationsTill.Value.ToString())

      Call Me.SayEvent("Notifications deactivated for 30 minutes.")
    End Sub

    Private Sub mnuDisableNotificationReenable_Click(Sender As Object,
                                                     e As EventArgs) Handles MenuDeactivateNotificationReactivate.Click
      If Me.DisableNotificationsTill.HasValue AndAlso Me.Settings.EnableVoiceAnnouncement Then
        Me.MenuDeactivateNotificationReactivate.Enabled = False
        Call Me.SayEvent("Notifications re-activated.")
      End If

      Me.DisableNotificationsTill = Nothing
    End Sub
  End Class
End Namespace