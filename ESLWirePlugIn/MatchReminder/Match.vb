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
  Friend Class Match
    'aequitasId - : System.String
    'gameId - 687: System.Int32
    'gameTitle - StarCraft II: System.String
    'id - 25056092: System.Int32
    'leagueCountry - eu: System.String
    'leagueId - 1: System.Int32
    'leagueName - StarCraft II 1on1 Amateur Series: System.String
    'mode - player: System.String
    'name - vs. DreZkaTT: System.String
    'time - 2012-01-13T19:00:00: System.String
    'uri - http://www.esl.eu/eu/sc2/1on1/eas/match/25056092/: System.String

    Private Shared ReadOnly AequitasIdHash As Integer = "aequitasId".ToLower().GetHashCode()
    Private Shared ReadOnly GameIdHash As Integer = "gameId".ToLower().GetHashCode()
    Private Shared ReadOnly GameTitleHash As Integer = "gameTitle".ToLower().GetHashCode()
    Private Shared ReadOnly IDHash As Integer = "id".ToLower().GetHashCode()
    Private Shared ReadOnly LeagueCountryHash As Integer = "leagueCountry".ToLower().GetHashCode()
    Private Shared ReadOnly LeagueIDHash As Integer = "leagueId".ToLower().GetHashCode()
    Private Shared ReadOnly LeagueNameHash As Integer = "leagueName".ToLower().GetHashCode()
    Private Shared ReadOnly ModeHash As Integer = "mode".ToLower().GetHashCode()
    Private Shared ReadOnly NameHash As Integer = "name".ToLower().GetHashCode()
    Private Shared ReadOnly TimeHash As Integer = "time".ToLower().GetHashCode()
    Private Shared ReadOnly UriHash As Integer = "uri".ToLower().GetHashCode()

    Public AequitasId As String
    Public GameId As Integer
    Public GameTitle As String
    Public ID As Integer
    Public LeagueCountry As String
    Public LeagueId As Integer
    Public LeagueName As String
    Public Mode As String
    Public Name As String
    Public Time As DateTime
    Public Uri As String

    Public Sub New()
      Me.AequitasId = Nothing
      Me.GameId = Nothing
      Me.GameTitle = Nothing
      Me.ID = Nothing
      Me.LeagueCountry = Nothing
      Me.LeagueId = Nothing
      Me.LeagueName = Nothing
      Me.Mode = Nothing
      Me.Name = Nothing
      Me.Time = Nothing
      Me.Uri = Nothing
    End Sub

    Public Shared Function ToMatch(ByVal Dictionary As IDictionary,
                                   ByRef Match As Match,
                                   Optional ByRef Ex As Exception = Nothing) As Boolean
      Match = Nothing
      Ex = Nothing

      If Dictionary Is Nothing Then
        Ex = New ArgumentNullException("Dictionary")
      Else
        Match = New Match()

        With Dictionary.GetEnumerator()
          Call .Reset()

          Do While .MoveNext()
            Select Case .Key.ToString().ToLower.GetHashCode()
              Case AequitasIdHash
                Match.AequitasId = .Value.ToString()
              Case GameIdHash
                Call Integer.TryParse(.Value.ToString(), Match.GameId)
              Case GameTitleHash
                Match.GameTitle = .Value.ToString()
              Case IDHash
                Call Integer.TryParse(.Value.ToString(), Match.ID)
              Case LeagueCountryHash
                Match.LeagueCountry = .Value.ToString()
              Case LeagueIDHash
                Call Integer.TryParse(.Value.ToString(), Match.LeagueId)
              Case LeagueNameHash
                Match.LeagueName = .Value.ToString()
              Case ModeHash
                Match.Mode = .Value.ToString()
              Case NameHash
                Match.Name = .Value.ToString()
              Case TimeHash
                Call Date.TryParse(.Value.ToString(), Match.Time)
              Case UriHash
                Match.Uri = .Value.ToString()
            End Select
          Loop
        End With
      End If

      Return ((Ex Is Nothing) AndAlso (Match IsNot Nothing))
    End Function
  End Class
End Namespace