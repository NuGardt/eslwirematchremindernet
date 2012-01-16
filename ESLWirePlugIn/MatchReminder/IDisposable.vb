﻿'
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