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
  Public Interface IConfig
    Property Notifications As List(Of NotificationSetting)

    Property EnableNotifications As Boolean

    Property EnableVoiceAnnouncement As Boolean

    Property EnableBalloonNotification As Boolean

    Property EnableInGameNotification As Boolean

    Property ShowTrayIcon As Boolean

    Property TtsVolume As Int32

    Property TtsRate As Int32

    Property TtsVoice As String
  End Interface
End Namespace