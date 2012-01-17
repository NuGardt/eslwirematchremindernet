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