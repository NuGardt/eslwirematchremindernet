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

Namespace ESLWirePlugIn.MatchReminder
  <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
  Partial Class About

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
      Me.panBout = New System.Windows.Forms.TableLayoutPanel()
      Me.lblLogo = New System.Windows.Forms.Label()
      Me.cmdOk = New System.Windows.Forms.Button()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.lblLinkInfo = New System.Windows.Forms.Label()
      Me.lblLink = New System.Windows.Forms.LinkLabel()
      Me.lblLicense = New System.Windows.Forms.LinkLabel()
      Me.lblLicenseInfo = New System.Windows.Forms.Label()
      Me.panBout.SuspendLayout()
      Me.SuspendLayout()
      '
      'panBout
      '
      Me.panBout.ColumnCount = 4
      Me.panBout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
      Me.panBout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
      Me.panBout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
      Me.panBout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
      Me.panBout.Controls.Add(Me.lblLogo, 0, 1)
      Me.panBout.Controls.Add(Me.cmdOk, 2, 6)
      Me.panBout.Controls.Add(Me.Label1, 1, 1)
      Me.panBout.Controls.Add(Me.Label2, 1, 2)
      Me.panBout.Controls.Add(Me.Label3, 0, 3)
      Me.panBout.Controls.Add(Me.Label4, 1, 3)
      Me.panBout.Controls.Add(Me.lblLinkInfo, 0, 4)
      Me.panBout.Controls.Add(Me.lblLink, 1, 4)
      Me.panBout.Controls.Add(Me.lblLicense, 1, 5)
      Me.panBout.Controls.Add(Me.lblLicenseInfo, 0, 5)
      Me.panBout.Dock = System.Windows.Forms.DockStyle.Fill
      Me.panBout.Location = New System.Drawing.Point(0, 0)
      Me.panBout.Name = "panBout"
      Me.panBout.RowCount = 9
      Me.panBout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
      Me.panBout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
      Me.panBout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
      Me.panBout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
      Me.panBout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
      Me.panBout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
      Me.panBout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
      Me.panBout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
      Me.panBout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
      Me.panBout.Size = New System.Drawing.Size(319, 205)
      Me.panBout.TabIndex = 0
      '
      'lblLogo
      '
      Me.lblLogo.Dock = System.Windows.Forms.DockStyle.Fill
      Me.lblLogo.Image = Global.NuGardt.My.Resources.Resources.PNG_MatchReminder
      Me.lblLogo.Location = New System.Drawing.Point(3, 26)
      Me.lblLogo.Name = "lblLogo"
      Me.lblLogo.Size = New System.Drawing.Size(100, 50)
      Me.lblLogo.TabIndex = 1
      '
      'cmdOk
      '
      Me.cmdOk.Dock = System.Windows.Forms.DockStyle.Fill
      Me.cmdOk.Location = New System.Drawing.Point(215, 183)
      Me.cmdOk.Name = "cmdOk"
      Me.cmdOk.Size = New System.Drawing.Size(100, 20)
      Me.cmdOk.TabIndex = 0
      Me.cmdOk.Text = "Ok"
      Me.cmdOk.UseVisualStyleBackColor = True
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.panBout.SetColumnSpan(Me.Label1, 2)
      Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.Location = New System.Drawing.Point(109, 26)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(206, 50)
      Me.Label1.TabIndex = 3
      Me.Label1.Text = "ESL Wire Plugin Match Reminder"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.panBout.SetColumnSpan(Me.Label2, 2)
      Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
      Me.Label2.Location = New System.Drawing.Point(109, 76)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(206, 26)
      Me.Label2.TabIndex = 4
      Me.Label2.Text = "2012 NuGardt Software"
      Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
      Me.Label3.Location = New System.Drawing.Point(3, 102)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(100, 26)
      Me.Label3.TabIndex = 5
      Me.Label3.Text = "Author"
      Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.panBout.SetColumnSpan(Me.Label4, 2)
      Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
      Me.Label4.Location = New System.Drawing.Point(109, 102)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(206, 26)
      Me.Label4.TabIndex = 6
      Me.Label4.Text = "Kevin 'OomJan' Gardthausen"
      Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblLinkInfo
      '
      Me.lblLinkInfo.AutoSize = True
      Me.lblLinkInfo.Dock = System.Windows.Forms.DockStyle.Fill
      Me.lblLinkInfo.Location = New System.Drawing.Point(3, 128)
      Me.lblLinkInfo.Name = "lblLinkInfo"
      Me.lblLinkInfo.Size = New System.Drawing.Size(100, 26)
      Me.lblLinkInfo.TabIndex = 7
      Me.lblLinkInfo.Text = "Link"
      Me.lblLinkInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblLink
      '
      Me.lblLink.AutoSize = True
      Me.panBout.SetColumnSpan(Me.lblLink, 2)
      Me.lblLink.Dock = System.Windows.Forms.DockStyle.Fill
      Me.lblLink.Location = New System.Drawing.Point(109, 128)
      Me.lblLink.Name = "lblLink"
      Me.lblLink.Size = New System.Drawing.Size(206, 26)
      Me.lblLink.TabIndex = 11
      Me.lblLink.TabStop = True
      Me.lblLink.Text = "http://code.google.com/p/eslwirematchremindernet/"
      Me.lblLink.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblLicense
      '
      Me.lblLicense.AutoSize = True
      Me.panBout.SetColumnSpan(Me.lblLicense, 2)
      Me.lblLicense.Dock = System.Windows.Forms.DockStyle.Fill
      Me.lblLicense.Location = New System.Drawing.Point(109, 154)
      Me.lblLicense.Name = "lblLicense"
      Me.lblLicense.Size = New System.Drawing.Size(206, 26)
      Me.lblLicense.TabIndex = 12
      Me.lblLicense.TabStop = True
      Me.lblLicense.Text = "http://www.gnu.org/licenses/gpl.html"
      Me.lblLicense.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblLicenseInfo
      '
      Me.lblLicenseInfo.AutoSize = True
      Me.lblLicenseInfo.Dock = System.Windows.Forms.DockStyle.Fill
      Me.lblLicenseInfo.Location = New System.Drawing.Point(3, 154)
      Me.lblLicenseInfo.Name = "lblLicenseInfo"
      Me.lblLicenseInfo.Size = New System.Drawing.Size(100, 26)
      Me.lblLicenseInfo.TabIndex = 13
      Me.lblLicenseInfo.Text = "License"
      Me.lblLicenseInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'About
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(319, 205)
      Me.Controls.Add(Me.panBout)
      Me.Name = "About"
      Me.Text = "About"
      Me.panBout.ResumeLayout(False)
      Me.panBout.PerformLayout()
      Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panBout As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents lblLogo As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblLinkInfo As System.Windows.Forms.Label
    Friend WithEvents lblLink As System.Windows.Forms.LinkLabel
    Friend WithEvents lblLicense As System.Windows.Forms.LinkLabel
    Friend WithEvents lblLicenseInfo As System.Windows.Forms.Label
  End Class
End Namespace