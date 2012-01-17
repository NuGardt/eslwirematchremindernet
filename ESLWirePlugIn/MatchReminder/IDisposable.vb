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
  Public Interface IDisposable
    Inherits System.IDisposable

    Event WillDispose(ByVal Sender As Object,
                      ByVal e As EventArgs)

    Event Disposed(ByVal Sender As Object,
                   ByVal e As EventArgs)

    ReadOnly Property IsDisposed() As Boolean

    ReadOnly Property IsDisposing() As Boolean
  End Interface
End Namespace