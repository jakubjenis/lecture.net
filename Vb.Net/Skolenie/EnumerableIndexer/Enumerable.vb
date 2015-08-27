Imports System.Collections

Module Enumerable

    Class Person

    End Class

    Class MyList(Of T)
        Implements IEnumerable(Of T)

        Private fList As List(Of T)

        Public Function GetEnumerator() As System.Collections.Generic.IEnumerator(Of T) Implements IEnumerable(Of T).GetEnumerator
            Return New MyListEnum(Of T)(fList)
        End Function

        Public Function GetEnumerator1() As System.Collections.IEnumerator Implements IEnumerable.GetEnumerator
            Return GetEnumerator()
        End Function
    End Class

    Class MyListEnum(Of T)
        Implements IEnumerator(Of T)

        Private fList As List(Of T)
        Private fPosition As Integer = -1

        Public Sub New(fPeople As List(Of T))
            fList = fPeople
        End Sub

        Public ReadOnly Property Current As T Implements IEnumerator(Of T).Current
            Get
                Try
                    Return fList(fPosition)
                Catch ex As IndexOutOfRangeException
                    Throw New InvalidOperationException()
                End Try
            End Get
        End Property

        Public ReadOnly Property Current1 As Object Implements IEnumerator.Current
            Get
                Return Current()
            End Get
        End Property

        Public Function MoveNext() As Boolean Implements IEnumerator.MoveNext
            fPosition += 1
            Return fPosition > fList.Count
        End Function

        Public Sub Reset() Implements IEnumerator.Reset
            fPosition = 0
        End Sub

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: dispose managed state (managed objects).
                End If

                ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
                ' TODO: set large fields to null.
            End If
            Me.disposedValue = True
        End Sub

        ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
        'Protected Overrides Sub Finalize()
        '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        '    Dispose(False)
        '    MyBase.Finalize()
        'End Sub

        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class


    Sub Main()

    End Sub

End Module
