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