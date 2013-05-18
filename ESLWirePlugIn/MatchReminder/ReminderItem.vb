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
  Friend Class ReminderItem
    Implements IComparable(Of ReminderItem)
    Public ReadOnly Match As Match
    Public ReadOnly Annouce As DateTime
    Public ReadOnly NotificationDurationInSeconds As Integer
    Public ReadOnly Message As String

    Public ReadOnly ShowInGame As Boolean
    Public ReadOnly ShowBalloon As Boolean
    Public ReadOnly VoiceAnnounce As Boolean

#Region "Compare"

    Public Function CompareTo(Other As ReminderItem) As Integer Implements IComparable(Of ReminderItem).CompareTo
      Return CompareByAnnounce(Me, Other)
    End Function

    Public Shared Function CompareByAnnounce(ByVal X As ReminderItem,
                                             ByVal Y As ReminderItem) As Integer
      Dim Erg As Integer = 0

      If (X IsNot Nothing) Then
        If (Y IsNot Nothing) Then
          Erg = X.Annouce.CompareTo(Y.Annouce)
        Else
          Erg = 1
        End If
      ElseIf (Y IsNot Nothing) Then
        Erg = - 1
      End If

      Return Erg
    End Function

#End Region

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
  End Class
End Namespace