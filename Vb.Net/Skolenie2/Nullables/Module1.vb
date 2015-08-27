
Public Interface Test
    Function Foo() As Boolean

End Interface

Public Structure MyDateTime

    Private year, month, day As Integer

    Public Sub New(Y As Integer, M As Integer, D As Integer)
        year = Y
        month = M
        day = D
    End Sub

End Structure

Module Module1

    Sub Main()

        Dim D As New Date()
        Dim N As MyDateTime = New MyDateTime(2012, 1, 1)
        N = New MyDateTime(2011, 2, 2)

    End Sub

End Module
