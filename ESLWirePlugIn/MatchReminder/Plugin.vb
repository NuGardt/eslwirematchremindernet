'
' Copyright (C) 2012 NuGardt Software
' http://www.nugardt.com
'
' This Program is free software; you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation; either version 2, or (at your option)
' any later version.
'
' This Program is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
' GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License
' along with NuGardt ESL Wire Plugin Match Reminder; see the file COPYING. If not, write to
' the Free Software Foundation, 675 Mass Ave, Cambridge, MA 02139, USA.
' http://www.gnu.org/copyleft/gpl.html
'
Namespace ESLWirePlugIn.MatchReminder
  Public Class Plugin
    Inherits Wire.Plugin

    Private Scheduler As Scheduler
    Private SettingsForm As Settings
    Private AboutForm As About

    ''' <summary>
    ''' Start point.
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub Init()
      Me.SettingsForm = Nothing
      Me.AboutForm = Nothing

      Call Me.setTooltip("Match Reminder")
      Call Me.setIcon(My.Resources.ICO_MatchReminder.ToBitmap())

      Me.Scheduler = New Scheduler(Me)
      Call Me.Scheduler.Start()
    End Sub

    ''' <summary>
    ''' End point.
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub OnExit()
      If Me.Scheduler IsNot Nothing Then Call Me.Scheduler.Dispose()
      If Me.SettingsForm IsNot Nothing Then
        Call Me.SettingsForm.Close(True)
        Me.SettingsForm = Nothing
      End If
      If Me.AboutForm IsNot Nothing Then
        Call Me.AboutForm.Close()
        Me.AboutForm = Nothing
      End If
    End Sub

    Public Overrides Sub IconClicked(X As Integer,
                                     Y As Integer,
                                     Button As MouseButton)
      Call Me.Scheduler.ContextMenuStrip.Show(X, Y)
    End Sub

    Public Sub OpenSettings()
      If Me.SettingsForm IsNot Nothing Then
        Call Me.SettingsForm.Show()
      Else
        Me.SettingsForm = New Settings(Me, Me.Scheduler)
        Call Me.SettingsForm.Show()
      End If
    End Sub

    Public Sub SettingsFormClose()
      If Me.SettingsForm IsNot Nothing Then
        Call Me.SettingsForm.Dispose()
        Me.SettingsForm = Nothing
      End If
    End Sub

    Public Sub OpenAbout()
      If Me.AboutForm IsNot Nothing Then
        Call Me.AboutForm.Show()
      Else
        Me.AboutForm = New About(Me)
        Call Me.AboutForm.Show()
      End If
    End Sub

    Public Sub AboutFormClose()
      If Me.AboutForm IsNot Nothing Then
        Call Me.AboutForm.Dispose()
        Me.AboutForm = Nothing
      End If
    End Sub

    Public Overrides ReadOnly Property Author As String
      Get
        Return "Kevin 'OomJan' Gardthausen"
      End Get
    End Property

    Public Overrides ReadOnly Property Title As String
      Get
        Return "Match Reminder"
      End Get
    End Property

    Public Overrides ReadOnly Property Version As String
      Get
        Return My.Application.Info.Version.ToString()
      End Get
    End Property
  End Class
End Namespace