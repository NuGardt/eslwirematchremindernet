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

Namespace ESLWirePlugIn.MatchReminder
  <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
  Partial Class Settings
    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      Try
        If disposing AndAlso components IsNot Nothing Then
          components.Dispose()
        End If
      Finally
        MyBase.Dispose(disposing)
      End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
      Me.grdView = New System.Windows.Forms.DataGridView()
      Me.colDelete = New System.Windows.Forms.DataGridViewButtonColumn()
      Me.colNotficationPrior = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.colNotificationDuration = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.colNotifyInGame = New System.Windows.Forms.DataGridViewCheckBoxColumn()
      Me.colNotifyWithBaloon = New System.Windows.Forms.DataGridViewCheckBoxColumn()
      Me.colVoiceAnnounce = New System.Windows.Forms.DataGridViewCheckBoxColumn()
      Me.colTest = New System.Windows.Forms.DataGridViewButtonColumn()
      Me.colNotificationFormat = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.panMain = New System.Windows.Forms.TableLayoutPanel()
      Me.cmdDiscard = New System.Windows.Forms.Button()
      Me.cmdApply = New System.Windows.Forms.Button()
      Me.panTTSOptions = New System.Windows.Forms.GroupBox()
      Me.panTextToSpeechContents = New System.Windows.Forms.TableLayoutPanel()
      Me.barVolume = New System.Windows.Forms.TrackBar()
      Me.comVoices = New System.Windows.Forms.ComboBox()
      Me.barRate = New System.Windows.Forms.TrackBar()
      Me.lblVoice = New System.Windows.Forms.Label()
      Me.lblRate = New System.Windows.Forms.Label()
      Me.lblVolume = New System.Windows.Forms.Label()
      Me.lblRateSlower = New System.Windows.Forms.Label()
      Me.lblRateFaster = New System.Windows.Forms.Label()
      Me.lblVolumeSofter = New System.Windows.Forms.Label()
      Me.lblVolumeLouder = New System.Windows.Forms.Label()
      Me.panGlobalOptions = New System.Windows.Forms.GroupBox()
      Me.panGlocalOptionsContents = New System.Windows.Forms.TableLayoutPanel()
      Me.chkEnableNotifications = New System.Windows.Forms.CheckBox()
      Me.chkEnableInGameNotifications = New System.Windows.Forms.CheckBox()
      Me.chkEnableBalloonNotifications = New System.Windows.Forms.CheckBox()
      Me.chkVoiceAnnouncements = New System.Windows.Forms.CheckBox()
      Me.chkShowTrayIcon = New System.Windows.Forms.CheckBox()
      Me.cmdNewRow = New System.Windows.Forms.Button()
      Me.panLegend = New System.Windows.Forms.GroupBox()
      Me.rtfLegend = New System.Windows.Forms.RichTextBox()
      CType(Me.grdView, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.panMain.SuspendLayout()
      Me.panTTSOptions.SuspendLayout()
      Me.panTextToSpeechContents.SuspendLayout()
      CType(Me.barVolume, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.barRate, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.panGlobalOptions.SuspendLayout()
      Me.panGlocalOptionsContents.SuspendLayout()
      Me.panLegend.SuspendLayout()
      Me.SuspendLayout()
      '
      'grdView
      '
      Me.grdView.AllowUserToAddRows = False
      Me.grdView.AllowUserToResizeRows = False
      Me.grdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.grdView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDelete, Me.colNotficationPrior, Me.colNotificationDuration, Me.colNotifyInGame, Me.colNotifyWithBaloon, Me.colVoiceAnnounce, Me.colTest, Me.colNotificationFormat})
      Me.panMain.SetColumnSpan(Me.grdView, 6)
      Me.grdView.Dock = System.Windows.Forms.DockStyle.Fill
      Me.grdView.Location = New System.Drawing.Point(3, 29)
      Me.grdView.MultiSelect = False
      Me.grdView.Name = "grdView"
      Me.grdView.Size = New System.Drawing.Size(1143, 252)
      Me.grdView.TabIndex = 0
      Me.grdView.VirtualMode = True
      '
      'colDelete
      '
      Me.colDelete.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.colDelete.Frozen = True
      Me.colDelete.HeaderText = "Delete"
      Me.colDelete.Name = "colDelete"
      Me.colDelete.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
      Me.colDelete.Text = "Delete"
      Me.colDelete.ToolTipText = "Delete"
      Me.colDelete.UseColumnTextForButtonValue = True
      '
      'colNotficationPrior
      '
      Me.colNotficationPrior.HeaderText = "Notify prior to Match"
      Me.colNotficationPrior.Name = "colNotficationPrior"
      Me.colNotficationPrior.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
      '
      'colNotificationDuration
      '
      Me.colNotificationDuration.HeaderText = "Notification duration"
      Me.colNotificationDuration.Name = "colNotificationDuration"
      Me.colNotificationDuration.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
      '
      'colNotifyInGame
      '
      Me.colNotifyInGame.HeaderText = "Show in game"
      Me.colNotifyInGame.Name = "colNotifyInGame"
      '
      'colNotifyWithBaloon
      '
      Me.colNotifyWithBaloon.HeaderText = "Show balloon"
      Me.colNotifyWithBaloon.Name = "colNotifyWithBaloon"
      '
      'colVoiceAnnounce
      '
      Me.colVoiceAnnounce.HeaderText = "Voice announce"
      Me.colVoiceAnnounce.Name = "colVoiceAnnounce"
      Me.colVoiceAnnounce.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
      '
      'colTest
      '
      Me.colTest.HeaderText = "Test"
      Me.colTest.Name = "colTest"
      Me.colTest.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
      Me.colTest.Text = "Test"
      Me.colTest.ToolTipText = "Test"
      Me.colTest.UseColumnTextForButtonValue = True
      '
      'colNotificationFormat
      '
      Me.colNotificationFormat.HeaderText = "Format"
      Me.colNotificationFormat.Name = "colNotificationFormat"
      Me.colNotificationFormat.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
      Me.colNotificationFormat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
      Me.colNotificationFormat.Width = 400
      '
      'panMain
      '
      Me.panMain.ColumnCount = 6
      Me.panMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
      Me.panMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 224.0!))
      Me.panMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 330.0!))
      Me.panMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
      Me.panMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
      Me.panMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
      Me.panMain.Controls.Add(Me.cmdDiscard, 5, 3)
      Me.panMain.Controls.Add(Me.cmdApply, 4, 3)
      Me.panMain.Controls.Add(Me.grdView, 0, 1)
      Me.panMain.Controls.Add(Me.panTTSOptions, 2, 2)
      Me.panMain.Controls.Add(Me.panGlobalOptions, 0, 2)
      Me.panMain.Controls.Add(Me.cmdNewRow, 0, 0)
      Me.panMain.Controls.Add(Me.panLegend, 3, 2)
      Me.panMain.Dock = System.Windows.Forms.DockStyle.Fill
      Me.panMain.Location = New System.Drawing.Point(0, 0)
      Me.panMain.Margin = New System.Windows.Forms.Padding(0)
      Me.panMain.Name = "panMain"
      Me.panMain.RowCount = 4
      Me.panMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
      Me.panMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
      Me.panMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 132.0!))
      Me.panMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
      Me.panMain.Size = New System.Drawing.Size(1149, 442)
      Me.panMain.TabIndex = 1
      '
      'cmdDiscard
      '
      Me.cmdDiscard.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.cmdDiscard.Location = New System.Drawing.Point(1043, 416)
      Me.cmdDiscard.Margin = New System.Windows.Forms.Padding(0, 0, 3, 3)
      Me.cmdDiscard.Name = "cmdDiscard"
      Me.cmdDiscard.Size = New System.Drawing.Size(103, 23)
      Me.cmdDiscard.TabIndex = 3
      Me.cmdDiscard.Text = "Dis&card"
      Me.cmdDiscard.UseVisualStyleBackColor = False
      '
      'cmdApply
      '
      Me.cmdApply.Location = New System.Drawing.Point(940, 416)
      Me.cmdApply.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
      Me.cmdApply.Name = "cmdApply"
      Me.cmdApply.Size = New System.Drawing.Size(100, 23)
      Me.cmdApply.TabIndex = 2
      Me.cmdApply.Text = "&Apply"
      Me.cmdApply.UseVisualStyleBackColor = True
      '
      'panTTSOptions
      '
      Me.panTTSOptions.Controls.Add(Me.panTextToSpeechContents)
      Me.panTTSOptions.Location = New System.Drawing.Point(333, 287)
      Me.panTTSOptions.Name = "panTTSOptions"
      Me.panMain.SetRowSpan(Me.panTTSOptions, 2)
      Me.panTTSOptions.Size = New System.Drawing.Size(324, 149)
      Me.panTTSOptions.TabIndex = 0
      Me.panTTSOptions.TabStop = False
      Me.panTTSOptions.Text = "Text-To-Speech Options"
      '
      'panTextToSpeechContents
      '
      Me.panTextToSpeechContents.ColumnCount = 4
      Me.panTextToSpeechContents.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
      Me.panTextToSpeechContents.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
      Me.panTextToSpeechContents.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
      Me.panTextToSpeechContents.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
      Me.panTextToSpeechContents.Controls.Add(Me.barVolume, 1, 3)
      Me.panTextToSpeechContents.Controls.Add(Me.comVoices, 1, 0)
      Me.panTextToSpeechContents.Controls.Add(Me.barRate, 1, 1)
      Me.panTextToSpeechContents.Controls.Add(Me.lblVoice, 0, 0)
      Me.panTextToSpeechContents.Controls.Add(Me.lblRate, 0, 1)
      Me.panTextToSpeechContents.Controls.Add(Me.lblVolume, 0, 3)
      Me.panTextToSpeechContents.Controls.Add(Me.lblRateSlower, 1, 2)
      Me.panTextToSpeechContents.Controls.Add(Me.lblRateFaster, 2, 2)
      Me.panTextToSpeechContents.Controls.Add(Me.lblVolumeSofter, 1, 4)
      Me.panTextToSpeechContents.Controls.Add(Me.lblVolumeLouder, 2, 4)
      Me.panTextToSpeechContents.Dock = System.Windows.Forms.DockStyle.Fill
      Me.panTextToSpeechContents.Location = New System.Drawing.Point(3, 16)
      Me.panTextToSpeechContents.Name = "panTextToSpeechContents"
      Me.panTextToSpeechContents.RowCount = 6
      Me.panTextToSpeechContents.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
      Me.panTextToSpeechContents.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
      Me.panTextToSpeechContents.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
      Me.panTextToSpeechContents.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
      Me.panTextToSpeechContents.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
      Me.panTextToSpeechContents.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
      Me.panTextToSpeechContents.Size = New System.Drawing.Size(318, 130)
      Me.panTextToSpeechContents.TabIndex = 1
      '
      'barVolume
      '
      Me.panTextToSpeechContents.SetColumnSpan(Me.barVolume, 2)
      Me.barVolume.Dock = System.Windows.Forms.DockStyle.Fill
      Me.barVolume.LargeChange = 15
      Me.barVolume.Location = New System.Drawing.Point(109, 81)
      Me.barVolume.Maximum = 100
      Me.barVolume.Name = "barVolume"
      Me.barVolume.Size = New System.Drawing.Size(206, 20)
      Me.barVolume.SmallChange = 10
      Me.barVolume.TabIndex = 2
      Me.barVolume.TickFrequency = 5
      Me.barVolume.Value = 100
      '
      'comVoices
      '
      Me.panTextToSpeechContents.SetColumnSpan(Me.comVoices, 2)
      Me.comVoices.Dock = System.Windows.Forms.DockStyle.Fill
      Me.comVoices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.comVoices.FormattingEnabled = True
      Me.comVoices.Location = New System.Drawing.Point(109, 3)
      Me.comVoices.Name = "comVoices"
      Me.comVoices.Size = New System.Drawing.Size(206, 21)
      Me.comVoices.TabIndex = 0
      '
      'barRate
      '
      Me.panTextToSpeechContents.SetColumnSpan(Me.barRate, 2)
      Me.barRate.Dock = System.Windows.Forms.DockStyle.Fill
      Me.barRate.LargeChange = 1
      Me.barRate.Location = New System.Drawing.Point(109, 29)
      Me.barRate.Minimum = -10
      Me.barRate.Name = "barRate"
      Me.barRate.Size = New System.Drawing.Size(206, 20)
      Me.barRate.SmallChange = 2
      Me.barRate.TabIndex = 1
      Me.barRate.Value = -1
      '
      'lblVoice
      '
      Me.lblVoice.AutoSize = True
      Me.lblVoice.Dock = System.Windows.Forms.DockStyle.Fill
      Me.lblVoice.Location = New System.Drawing.Point(3, 0)
      Me.lblVoice.Name = "lblVoice"
      Me.lblVoice.Size = New System.Drawing.Size(100, 26)
      Me.lblVoice.TabIndex = 3
      Me.lblVoice.Text = "Voice"
      Me.lblVoice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblRate
      '
      Me.lblRate.AutoSize = True
      Me.lblRate.Dock = System.Windows.Forms.DockStyle.Fill
      Me.lblRate.Location = New System.Drawing.Point(3, 26)
      Me.lblRate.Name = "lblRate"
      Me.lblRate.Size = New System.Drawing.Size(100, 26)
      Me.lblRate.TabIndex = 4
      Me.lblRate.Text = "Rate"
      Me.lblRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblVolume
      '
      Me.lblVolume.AutoSize = True
      Me.lblVolume.Dock = System.Windows.Forms.DockStyle.Fill
      Me.lblVolume.Location = New System.Drawing.Point(3, 78)
      Me.lblVolume.Name = "lblVolume"
      Me.lblVolume.Size = New System.Drawing.Size(100, 26)
      Me.lblVolume.TabIndex = 5
      Me.lblVolume.Text = "Volume"
      Me.lblVolume.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblRateSlower
      '
      Me.lblRateSlower.AutoSize = True
      Me.lblRateSlower.Dock = System.Windows.Forms.DockStyle.Fill
      Me.lblRateSlower.Location = New System.Drawing.Point(109, 52)
      Me.lblRateSlower.Name = "lblRateSlower"
      Me.lblRateSlower.Size = New System.Drawing.Size(100, 26)
      Me.lblRateSlower.TabIndex = 6
      Me.lblRateSlower.Text = "Slower"
      '
      'lblRateFaster
      '
      Me.lblRateFaster.AutoSize = True
      Me.lblRateFaster.Dock = System.Windows.Forms.DockStyle.Fill
      Me.lblRateFaster.Location = New System.Drawing.Point(215, 52)
      Me.lblRateFaster.Name = "lblRateFaster"
      Me.lblRateFaster.Size = New System.Drawing.Size(100, 26)
      Me.lblRateFaster.TabIndex = 7
      Me.lblRateFaster.Text = "Faster"
      Me.lblRateFaster.TextAlign = System.Drawing.ContentAlignment.TopRight
      '
      'lblVolumeSofter
      '
      Me.lblVolumeSofter.AutoSize = True
      Me.lblVolumeSofter.Dock = System.Windows.Forms.DockStyle.Fill
      Me.lblVolumeSofter.Location = New System.Drawing.Point(109, 104)
      Me.lblVolumeSofter.Name = "lblVolumeSofter"
      Me.lblVolumeSofter.Size = New System.Drawing.Size(100, 26)
      Me.lblVolumeSofter.TabIndex = 8
      Me.lblVolumeSofter.Text = "Softer"
      '
      'lblVolumeLouder
      '
      Me.lblVolumeLouder.AutoSize = True
      Me.lblVolumeLouder.Dock = System.Windows.Forms.DockStyle.Fill
      Me.lblVolumeLouder.Location = New System.Drawing.Point(215, 104)
      Me.lblVolumeLouder.Name = "lblVolumeLouder"
      Me.lblVolumeLouder.Size = New System.Drawing.Size(100, 26)
      Me.lblVolumeLouder.TabIndex = 9
      Me.lblVolumeLouder.Text = "Louder"
      Me.lblVolumeLouder.TextAlign = System.Drawing.ContentAlignment.TopRight
      '
      'panGlobalOptions
      '
      Me.panMain.SetColumnSpan(Me.panGlobalOptions, 2)
      Me.panGlobalOptions.Controls.Add(Me.panGlocalOptionsContents)
      Me.panGlobalOptions.Location = New System.Drawing.Point(3, 287)
      Me.panGlobalOptions.Name = "panGlobalOptions"
      Me.panMain.SetRowSpan(Me.panGlobalOptions, 2)
      Me.panGlobalOptions.Size = New System.Drawing.Size(319, 149)
      Me.panGlobalOptions.TabIndex = 1
      Me.panGlobalOptions.TabStop = False
      Me.panGlobalOptions.Text = "Global Options"
      '
      'panGlocalOptionsContents
      '
      Me.panGlocalOptionsContents.ColumnCount = 3
      Me.panGlocalOptionsContents.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
      Me.panGlocalOptionsContents.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
      Me.panGlocalOptionsContents.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
      Me.panGlocalOptionsContents.Controls.Add(Me.chkEnableNotifications, 0, 0)
      Me.panGlocalOptionsContents.Controls.Add(Me.chkEnableInGameNotifications, 0, 1)
      Me.panGlocalOptionsContents.Controls.Add(Me.chkEnableBalloonNotifications, 0, 2)
      Me.panGlocalOptionsContents.Controls.Add(Me.chkVoiceAnnouncements, 0, 3)
      Me.panGlocalOptionsContents.Controls.Add(Me.chkShowTrayIcon, 0, 4)
      Me.panGlocalOptionsContents.Dock = System.Windows.Forms.DockStyle.Fill
      Me.panGlocalOptionsContents.Location = New System.Drawing.Point(3, 16)
      Me.panGlocalOptionsContents.Name = "panGlocalOptionsContents"
      Me.panGlocalOptionsContents.RowCount = 6
      Me.panGlocalOptionsContents.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
      Me.panGlocalOptionsContents.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
      Me.panGlocalOptionsContents.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
      Me.panGlocalOptionsContents.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
      Me.panGlocalOptionsContents.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
      Me.panGlocalOptionsContents.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
      Me.panGlocalOptionsContents.Size = New System.Drawing.Size(313, 130)
      Me.panGlocalOptionsContents.TabIndex = 0
      '
      'chkEnableNotifications
      '
      Me.chkEnableNotifications.AutoSize = True
      Me.panGlocalOptionsContents.SetColumnSpan(Me.chkEnableNotifications, 3)
      Me.chkEnableNotifications.Dock = System.Windows.Forms.DockStyle.Fill
      Me.chkEnableNotifications.Location = New System.Drawing.Point(3, 3)
      Me.chkEnableNotifications.Name = "chkEnableNotifications"
      Me.chkEnableNotifications.Size = New System.Drawing.Size(307, 20)
      Me.chkEnableNotifications.TabIndex = 0
      Me.chkEnableNotifications.Text = "Notifications"
      Me.chkEnableNotifications.UseVisualStyleBackColor = True
      '
      'chkEnableInGameNotifications
      '
      Me.chkEnableInGameNotifications.AutoSize = True
      Me.panGlocalOptionsContents.SetColumnSpan(Me.chkEnableInGameNotifications, 3)
      Me.chkEnableInGameNotifications.Dock = System.Windows.Forms.DockStyle.Fill
      Me.chkEnableInGameNotifications.Location = New System.Drawing.Point(3, 29)
      Me.chkEnableInGameNotifications.Name = "chkEnableInGameNotifications"
      Me.chkEnableInGameNotifications.Size = New System.Drawing.Size(307, 20)
      Me.chkEnableInGameNotifications.TabIndex = 1
      Me.chkEnableInGameNotifications.Text = "In game notfication"
      Me.chkEnableInGameNotifications.UseVisualStyleBackColor = True
      '
      'chkEnableBalloonNotifications
      '
      Me.chkEnableBalloonNotifications.AutoSize = True
      Me.panGlocalOptionsContents.SetColumnSpan(Me.chkEnableBalloonNotifications, 3)
      Me.chkEnableBalloonNotifications.Dock = System.Windows.Forms.DockStyle.Fill
      Me.chkEnableBalloonNotifications.Location = New System.Drawing.Point(3, 55)
      Me.chkEnableBalloonNotifications.Name = "chkEnableBalloonNotifications"
      Me.chkEnableBalloonNotifications.Size = New System.Drawing.Size(307, 20)
      Me.chkEnableBalloonNotifications.TabIndex = 2
      Me.chkEnableBalloonNotifications.Text = "Balloon notification"
      Me.chkEnableBalloonNotifications.UseVisualStyleBackColor = True
      '
      'chkVoiceAnnouncements
      '
      Me.chkVoiceAnnouncements.AutoSize = True
      Me.panGlocalOptionsContents.SetColumnSpan(Me.chkVoiceAnnouncements, 3)
      Me.chkVoiceAnnouncements.Dock = System.Windows.Forms.DockStyle.Fill
      Me.chkVoiceAnnouncements.Location = New System.Drawing.Point(3, 81)
      Me.chkVoiceAnnouncements.Name = "chkVoiceAnnouncements"
      Me.chkVoiceAnnouncements.Size = New System.Drawing.Size(307, 20)
      Me.chkVoiceAnnouncements.TabIndex = 3
      Me.chkVoiceAnnouncements.Text = "Voice announcements"
      Me.chkVoiceAnnouncements.UseVisualStyleBackColor = True
      '
      'chkShowTrayIcon
      '
      Me.chkShowTrayIcon.AutoSize = True
      Me.panGlocalOptionsContents.SetColumnSpan(Me.chkShowTrayIcon, 3)
      Me.chkShowTrayIcon.Dock = System.Windows.Forms.DockStyle.Fill
      Me.chkShowTrayIcon.Location = New System.Drawing.Point(3, 107)
      Me.chkShowTrayIcon.Name = "chkShowTrayIcon"
      Me.chkShowTrayIcon.Size = New System.Drawing.Size(307, 20)
      Me.chkShowTrayIcon.TabIndex = 4
      Me.chkShowTrayIcon.Text = "Show tray icon (required for balloon notifications)"
      Me.chkShowTrayIcon.UseVisualStyleBackColor = True
      '
      'cmdNewRow
      '
      Me.cmdNewRow.Dock = System.Windows.Forms.DockStyle.Fill
      Me.cmdNewRow.Location = New System.Drawing.Point(3, 3)
      Me.cmdNewRow.Margin = New System.Windows.Forms.Padding(3, 3, 0, 0)
      Me.cmdNewRow.Name = "cmdNewRow"
      Me.cmdNewRow.Size = New System.Drawing.Size(103, 23)
      Me.cmdNewRow.TabIndex = 1
      Me.cmdNewRow.Text = "&New"
      Me.cmdNewRow.UseVisualStyleBackColor = True
      '
      'panLegend
      '
      Me.panLegend.Controls.Add(Me.rtfLegend)
      Me.panLegend.Dock = System.Windows.Forms.DockStyle.Fill
      Me.panLegend.Location = New System.Drawing.Point(663, 287)
      Me.panLegend.Name = "panLegend"
      Me.panMain.SetRowSpan(Me.panLegend, 2)
      Me.panLegend.Size = New System.Drawing.Size(271, 152)
      Me.panLegend.TabIndex = 4
      Me.panLegend.TabStop = False
      Me.panLegend.Text = "Legend"
      '
      'rtfLegend
      '
      Me.rtfLegend.Dock = System.Windows.Forms.DockStyle.Fill
      Me.rtfLegend.Location = New System.Drawing.Point(3, 16)
      Me.rtfLegend.Name = "rtfLegend"
      Me.rtfLegend.ReadOnly = True
      Me.rtfLegend.Size = New System.Drawing.Size(265, 133)
      Me.rtfLegend.TabIndex = 5
      Me.rtfLegend.Text = ""
      '
      'Settings
      '
      Me.AcceptButton = Me.cmdApply
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.cmdDiscard
      Me.ClientSize = New System.Drawing.Size(1149, 442)
      Me.Controls.Add(Me.panMain)
      Me.MinimizeBox = False
      Me.Name = "Settings"
      Me.Tag = "{0} - Settings"
      CType(Me.grdView, System.ComponentModel.ISupportInitialize).EndInit()
      Me.panMain.ResumeLayout(False)
      Me.panTTSOptions.ResumeLayout(False)
      Me.panTextToSpeechContents.ResumeLayout(False)
      Me.panTextToSpeechContents.PerformLayout()
      CType(Me.barVolume, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.barRate, System.ComponentModel.ISupportInitialize).EndInit()
      Me.panGlobalOptions.ResumeLayout(False)
      Me.panGlocalOptionsContents.ResumeLayout(False)
      Me.panGlocalOptionsContents.PerformLayout()
      Me.panLegend.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdView As System.Windows.Forms.DataGridView
    Friend WithEvents panMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cmdNewRow As System.Windows.Forms.Button
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents panGlobalOptions As System.Windows.Forms.GroupBox
    Friend WithEvents panGlocalOptionsContents As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents chkEnableNotifications As System.Windows.Forms.CheckBox
    Friend WithEvents chkEnableInGameNotifications As System.Windows.Forms.CheckBox
    Friend WithEvents chkEnableBalloonNotifications As System.Windows.Forms.CheckBox
    Friend WithEvents chkVoiceAnnouncements As System.Windows.Forms.CheckBox
    Friend WithEvents chkShowTrayIcon As System.Windows.Forms.CheckBox
    Friend WithEvents panTTSOptions As System.Windows.Forms.GroupBox
    Friend WithEvents panTextToSpeechContents As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents barVolume As System.Windows.Forms.TrackBar
    Friend WithEvents comVoices As System.Windows.Forms.ComboBox
    Friend WithEvents barRate As System.Windows.Forms.TrackBar
    Friend WithEvents lblVoice As System.Windows.Forms.Label
    Friend WithEvents lblRate As System.Windows.Forms.Label
    Friend WithEvents lblVolume As System.Windows.Forms.Label
    Friend WithEvents lblRateSlower As System.Windows.Forms.Label
    Friend WithEvents lblRateFaster As System.Windows.Forms.Label
    Friend WithEvents lblVolumeSofter As System.Windows.Forms.Label
    Friend WithEvents lblVolumeLouder As System.Windows.Forms.Label
    Friend WithEvents cmdDiscard As System.Windows.Forms.Button
    Friend WithEvents panLegend As System.Windows.Forms.GroupBox
    Friend WithEvents rtfLegend As System.Windows.Forms.RichTextBox
    Friend WithEvents colDelete As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents colNotficationPrior As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNotificationDuration As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNotifyInGame As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colNotifyWithBaloon As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colVoiceAnnounce As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colTest As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents colNotificationFormat As System.Windows.Forms.DataGridViewTextBoxColumn
  End Class
End Namespace