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
Imports System.Windows.Forms
Imports System.Speech.Synthesis
Imports System.Drawing

Namespace ESLWirePlugIn.MatchReminder
  Friend Class Settings
    Inherits Form

    Private ReadOnly Plugin As Plugin
    Private ReadOnly Scheduler As Scheduler
    Private ReadOnly List As List(Of NotificationSetting)
    Private WithEvents Speech As SpeechSynthesizer
    Private IsClosing As Boolean

    Public Sub New(ByVal Plugin As Plugin,
                   ByVal Scheduler As Scheduler)
      Call MyBase.new()

      ' Dieser Aufruf ist für den Designer erforderlich.
      Call Me.InitializeComponent()
      Me.Icon = My.Resources.ICO_MatchReminder
      Me.Text = String.Format(Me.Tag.ToString(), "NuGardt ESL Wire Plugin Match Reminder")

      ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
      Me.Plugin = Plugin
      Me.Scheduler = Scheduler

      Me.IsClosing = False
      Me.List = New List(Of NotificationSetting)
      Me.Speech = New SpeechSynthesizer()
    End Sub

    Public Shadows Sub Close(ByVal IsClosing As Boolean)
      Me.IsClosing = IsClosing
      Call MyBase.Close()
    End Sub

    Private Sub SettingsFormClosing(Sender As Object,
                                    e As FormClosingEventArgs) Handles Me.FormClosing
      If IsClosing OrElse (MsgBox("Are you sure you want to discard all settings?", vbQuestion Or vbYesNoCancel) = vbYes) Then
        Call Me.Speech.Dispose()
        Call Me.Plugin.SettingsFormClose()
      Else
        e.Cancel = True
        Me.IsClosing = False
      End If
    End Sub

    Private Sub SettingsLoad(Sender As Object,
                             e As EventArgs) Handles Me.Load
      With Me.Speech.GetInstalledVoices().GetEnumerator()
        Call .Reset()

        Do While .MoveNext()
          Call Me.comVoices.Items.Add(.Current.VoiceInfo.Name)
        Loop

        Call .Dispose()
      End With
    End Sub

    Private Sub SettingsShown(Sender As Object,
                              e As EventArgs) Handles Me.Shown
      Me.rtfLegend.Rtf = Me.rtfLegend.Text
      Call Me.List.AddRange(Me.Scheduler.ListNotificationSettings)
      With Me.Scheduler.Settings
        Me.barRate.Value = .TtsRate
        Me.barVolume.Value = .TtsVolume
        Me.comVoices.Text = .TtsVoice

        Me.chkEnableBalloonNotifications.Checked = .EnableBalloonNotification
        Me.chkEnableInGameNotifications.Checked = .EnableInGameNotification
        Me.chkEnableNotifications.Checked = .EnableNotifications
        Me.chkShowTrayIcon.Checked = .ShowTrayIcon
        Me.chkVoiceAnnouncements.Checked = .EnableVoiceAnnouncement
      End With

      Try
        Call Me.Speech.SelectVoice(Me.comVoices.Text)
      Catch iEx As Exception
        Call Me.Speech.SelectVoice(Me.Speech.GetInstalledVoices.Item(0).VoiceInfo.Name)
      End Try

      Me.grdView.RowCount = Me.List.Count
    End Sub

    Private Sub ViewCellContentClick(Sender As Object,
                                     e As DataGridViewCellEventArgs) Handles grdView.CellContentClick
      Select Case e.RowIndex
        Case 0 To Me.List.Count - 1
          Dim Item As NotificationSetting = Me.List.Item(e.RowIndex)

          Select Case e.ColumnIndex
            Case Me.colDelete.Index
              Call Me.List.RemoveAt(e.RowIndex)
              Me.grdView.RowCount = Me.List.Count
              Call Me.grdView.Invalidate()
            Case Me.colTest.Index
              Dim Match As Match = Nothing

              With Me.Scheduler.GI.matches.GetEnumerator
                Call .Reset()

                Do While .MoveNext()
                  If Match.ToMatch(DirectCast(.Current, IDictionary), Match) Then
                    Exit Do
                  End If
                Loop
              End With

              If Match Is Nothing Then
                Match = New Match()
                With Match
                  .AequitasId = "123"
                  .GameId = 687
                  .GameTitle = "StarCraft II"
                  .ID = 1337
                  .LeagueCountry = "eu"
                  .LeagueId = 1
                  .LeagueName = "StarCraft II 1on1 Amateur Series"
                  .Mode = "player"
                  .Name = "vs. OomJan"
                  .Uri = "http://www.esl.eu"
                End With
              End If

              Match.Time = Now.AddSeconds(Item.NotifyTimeBeforeMatch)

              Call Me.Scheduler.ShowNotification(Now, New ReminderItem(Match, Now, Item.NotificationDuration, Scheduler.FormatMessage(Match, Item.MessageFormat), Item.ShowInGameNotification, Item.ShowBaloonNotification, Item.VoiceAnnounce))
          End Select
      End Select
    End Sub

    Private Sub ViewCellValueNeeded(Sender As Object,
                                    e As DataGridViewCellValueEventArgs) Handles grdView.CellValueNeeded
      Select Case e.RowIndex
        Case 0 To Me.List.Count - 1
          Dim Item As NotificationSetting = Me.List.Item(e.RowIndex)

          If e.RowIndex <> 0 Then
            Dim Color As Color = Me.grdView.DefaultCellStyle.BackColor

            Dim ItemBefore As NotificationSetting = Me.List.Item(e.RowIndex - 1)
            If ItemBefore.NotifyTimeBeforeMatch = Item.NotifyTimeBeforeMatch AndAlso (ItemBefore.ShowBaloonNotification = Item.ShowBaloonNotification OrElse ItemBefore.ShowInGameNotification = Item.ShowInGameNotification OrElse ItemBefore.VoiceAnnounce = Item.VoiceAnnounce) Then
              Color = Color.Red
            ElseIf ItemBefore.NotifyTimeBeforeMatch + ItemBefore.NotificationDuration > Item.NotifyTimeBeforeMatch AndAlso (ItemBefore.ShowBaloonNotification = Item.ShowBaloonNotification OrElse ItemBefore.ShowInGameNotification = Item.ShowInGameNotification OrElse ItemBefore.VoiceAnnounce = Item.VoiceAnnounce) Then
              Color = Color.Orange
            End If

            Dim c As DataGridViewCell = Me.grdView.Item(e.ColumnIndex, e.RowIndex)
            If TypeOf c Is DataGridViewTextBoxCell Then
              With DirectCast(c, DataGridViewTextBoxCell)
                .Style.BackColor = Color
              End With
            ElseIf TypeOf c Is DataGridViewCheckBoxCell Then
              With DirectCast(c, DataGridViewCheckBoxCell)
                .Style.BackColor = Color
              End With
            End If
          End If

          Select Case e.ColumnIndex
            Case Me.colNotficationPrior.Index
              e.Value = TimeSpan.FromSeconds(Item.NotifyTimeBeforeMatch)
            Case Me.colNotificationDuration.Index
              e.Value = TimeSpan.FromSeconds(Item.NotificationDuration)
            Case Me.colNotifyWithBaloon.Index
              e.Value = Item.ShowBaloonNotification
            Case Me.colNotifyInGame.Index
              e.Value = Item.ShowInGameNotification
            Case Me.colVoiceAnnounce.Index
              e.Value = Item.VoiceAnnounce
            Case Me.colNotificationFormat.Index
              e.Value = Item.MessageFormat
          End Select
      End Select
    End Sub

    Private Sub ViewCellValuePushed(Sender As Object,
                                    e As DataGridViewCellValueEventArgs) Handles grdView.CellValuePushed
      Select Case e.RowIndex
        Case 0 To Me.List.Count - 1
          Dim Item As NotificationSetting = Me.List.Item(e.RowIndex)

          Select Case e.ColumnIndex
            Case Me.colNotficationPrior.Index
              Dim tTime As TimeSpan
              Call TimeSpan.TryParse(e.Value.ToString(), tTime)
              If tTime >= NotificationSetting.MinPriorTime AndAlso tTime <= NotificationSetting.MaxPriorTime Then Item.NotifyTimeBeforeMatch = Convert.ToInt32(tTime.TotalSeconds)
            Case Me.colNotificationDuration.Index
              Dim tTime As TimeSpan
              Call TimeSpan.TryParse(e.Value.ToString(), tTime)
              If tTime >= NotificationSetting.MinNotificationDurationTime AndAlso tTime <= NotificationSetting.MaxNotificationDurationTime Then Item.NotificationDuration = Convert.ToInt32(tTime.TotalSeconds)
            Case Me.colNotifyWithBaloon.Index
              Call Boolean.TryParse(e.Value.ToString(), Item.ShowBaloonNotification)
            Case Me.colNotifyInGame.Index
              Call Boolean.TryParse(e.Value.ToString(), Item.ShowInGameNotification)
            Case Me.colVoiceAnnounce.Index
              Call Boolean.TryParse(e.Value.ToString(), Item.VoiceAnnounce)
            Case Me.colNotificationFormat.Index
              If e.Value.ToString().Length > 1024 Then e.Value = e.Value.ToString().Substring(0, 1024)
              Item.MessageFormat = e.Value.ToString()
          End Select

          Call Me.List.Sort(AddressOf NotificationSetting.CompareByNotifyBeforeMatch)
          Call Me.grdView.Invalidate()
      End Select
    End Sub

    Private Sub NewRowClick(Sender As Object,
                            e As EventArgs) Handles cmdNewRow.Click
      Dim Item = New NotificationSetting

      If Me.List.Count <> 0 Then
        Item.NotifyTimeBeforeMatch = Me.List.Item(Me.List.Count - 1).NotifyTimeBeforeMatch + 60
      End If

      Call Me.List.Add(Item)
      Call Me.List.Sort(AddressOf NotificationSetting.CompareByNotifyBeforeMatch)
      Me.grdView.RowCount = Me.List.Count
    End Sub

    Private Sub ApplyClick(Sender As Object,
                           e As EventArgs) Handles cmdApply.Click
      Dim Config As New Config

      With Config
        .Notifications = Me.List

        .EnableNotifications = Me.chkEnableNotifications.Checked
        .EnableVoiceAnnouncement = Me.chkVoiceAnnouncements.Checked
        .EnableBalloonNotification = Me.chkEnableBalloonNotifications.Checked
        .EnableInGameNotification = Me.chkEnableInGameNotifications.Checked
        .ShowTrayIcon = Me.chkShowTrayIcon.Checked
        .TtsVolume = Me.barVolume.Value
        .TtsRate = Me.barRate.Value
        .TtsVoice = Me.comVoices.Text
      End With

      Call Me.Scheduler.ApplyConfig(Config)
      Call Me.Close(True)
    End Sub

    Private Sub BarRateScroll(Sender As Object,
                              e As EventArgs) Handles barRate.Scroll
      Me.Speech.Rate = Me.barRate.Value
    End Sub

    Private Sub BarVolumeScroll(Sender As Object,
                                e As EventArgs) Handles barVolume.Scroll
      Me.Speech.Volume = Me.barVolume.Value
    End Sub

    Private Sub DiscardClick(Sender As Object,
                             e As EventArgs) Handles cmdDiscard.Click
      Call Me.Scheduler.SayEvent("Settings discarded.")
      Call Me.Close(True)
    End Sub
  End Class
End Namespace