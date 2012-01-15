Imports System.ComponentModel

Namespace ESLWirePlugIn.MatchReminder
  <DebuggerStepThrough()>
  Public MustInherit Class Disposable
    Implements IDisposable

    Private m_IsDisposed As Boolean

    Private m_IsDisposing As Boolean

#Region "Event WillDispose"

    Public Event WillDispose(ByVal Sender As Object,
                             ByVal e As EventArgs) Implements IDisposable.WillDispose

    Protected Overloads Sub OnWillDispose(ByVal e As EventArgs)
      RaiseEvent WillDispose(Me, e)
    End Sub

    Protected Overloads Sub OnWillDispose()
      RaiseEvent WillDispose(Me, New EventArgs)
    End Sub

#End Region

#Region "Event Disposed"

    Public Event Disposed(ByVal Sender As Object,
                          ByVal e As EventArgs) Implements IDisposable.Disposed

    Protected Overloads Sub OnDisposed(ByVal e As EventArgs)
      RaiseEvent Disposed(Me, e)
    End Sub

    Protected Overloads Sub OnDisposed()
      RaiseEvent Disposed(Me, New EventArgs)
    End Sub

#End Region

    Protected Sub New()
      '-
    End Sub

    Public Sub Dispose() Implements System.IDisposable.Dispose
      Call Me.iDispose()

      Call GC.SuppressFinalize(Me)
    End Sub

    <Browsable(False)> _
    <EditorBrowsable(EditorBrowsableState.Never)>
    Protected Sub iDispose()
      Dim Ex As Exception = Nothing
      If Me.TestNotDisposed(Ex) Then
        Me.m_IsDisposing = True
        Try
          Call Me.OnWillDispose()
        Catch iEx As Exception
#If DEBUG Then
          Trace.WriteLine(iEx, "OnWillDispose")
#End If
        End Try

        Try
          Call Me.iDispose1()
        Catch iEx As Exception
#If DEBUG Then
          Trace.WriteLine(iEx, "iiDispose")
#End If
        End Try

        Me.m_IsDisposed = True
        Try
          Call Me.OnDisposed()
        Catch iEx As Exception
#If DEBUG Then
          Trace.WriteLine(iEx, "OnDisposed")
#End If
        End Try
        Me.m_IsDisposing = False
#If DEBUG Then
      Else
        Trace.WriteLine(Ex)
#End If
      End If
    End Sub

    Protected MustOverride Sub iDispose1()

    Public ReadOnly Property IsDisposed() As Boolean Implements IDisposable.IsDisposed
      Get
        Return Me.m_IsDisposed
      End Get
    End Property

    Public ReadOnly Property IsDisposing() As Boolean Implements IDisposable.IsDisposing
      Get
        Return Me.m_IsDisposing
      End Get
    End Property

    Protected Overloads Function TestNotDisposed(ByRef Ex As Exception) As Boolean
      Return Me.iTestNotDisposed(False, Ex)
    End Function

    Protected Overloads Function TestNotDisposed(ByVal ThrowError As Boolean,
                                                 Optional ByRef Ex As Exception = Nothing) As Boolean
      Return Me.iTestNotDisposed(ThrowError, Ex)
    End Function

    Private Function iTestNotDisposed(ByVal ThrowError As Boolean,
                                      Optional ByRef Ex As Exception = Nothing) As Boolean
      Ex = Nothing

      If Me.m_IsDisposed Then
        If ThrowError Then
          Ex = New ObjectDisposedException(Me.GetType.ToString())
        Else
          Ex = New ObjectDisposedException(Me.GetType.ToString(), (New StackTrace(2)).ToString)
        End If
      ElseIf Me.m_IsDisposing Then
        If ThrowError Then
          Ex = New Exception(String.Format("{0} is disposing", Me.GetType.ToString()))
        Else
          Ex = New Exception(String.Format("{0} is disposing while {1}", Me.GetType.ToString(), (New StackTrace(2)).ToString))
        End If
      End If

      If ThrowError AndAlso (Ex IsNot Nothing) Then Throw Ex
      Return (Ex Is Nothing)
    End Function
  End Class
End Namespace