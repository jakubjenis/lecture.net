Module StringFunctions

    Public Function IsEmpty(S As String) As Boolean
        Return S Is Nothing OrElse S = ""
    End Function

    Public Function isnotempty(S As String) As Boolean
        Return Not IsEmpty(S)
    End Function

End Module
