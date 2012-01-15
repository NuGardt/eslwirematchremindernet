Imports System.Windows.Forms

Namespace ESLWirePlugIn.MatchReminder
  Public Class About
    Inherits Form

    Private Sub cmdOk_Click(Sender As Object,
                            e As EventArgs) Handles cmdOk.Click
      Call Me.Close()
    End Sub
  End Class
End Namespace