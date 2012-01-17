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
Imports System.Windows.Forms

Namespace ESLWirePlugIn.MatchReminder
  Public Class About
    Inherits Form

    Private ReadOnly Plugin As Plugin

    Public Sub New(ByVal Plugin As Plugin)
      Call MyBase.New()

      ' Dieser Aufruf ist für den Designer erforderlich.
      Call Me.InitializeComponent()

      ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
      Me.Icon = My.Resources.ICO_MatchReminder

      Me.Plugin = Plugin
    End Sub

    Private Sub cmdOk_Click(Sender As Object,
                            e As EventArgs) Handles cmdOk.Click
      Call Me.Close()
    End Sub

    Private Sub lblLink_LinkClicked(Sender As Object,
                                    e As LinkLabelLinkClickedEventArgs) Handles lblLink.LinkClicked
      Call Process.Start(Me.lblLink.Text)
    End Sub

    Private Sub About_FormClosing(Sender As Object,
                                  e As FormClosingEventArgs) Handles Me.FormClosing
      Call Me.Plugin.AboutFormClose()
    End Sub

    Private Sub lblLicense_LinkClicked(Sender As Object,
                                       e As LinkLabelLinkClickedEventArgs) Handles lblLicense.LinkClicked
      Call Process.Start(Me.lblLicense.Text)
    End Sub
  End Class
End Namespace