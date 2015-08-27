Module Structures

    Public Structure ComplexNumber
        Private Real As Decimal
        Private Complex As Decimal

        Public Sub New(R As Decimal, C As Decimal)
            Real = R
            Complex = C
        End Sub

        Public Overrides Function toString() As String
            Return "R: " & Real.ToString() & " I: " & Complex.ToString()
        End Function

    End Structure

End Module
