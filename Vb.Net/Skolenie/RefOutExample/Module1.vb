Module Module1

    Public Sub Foo(ByVal i As Integer)
        i += 1
    End Sub

    Public Sub Bar(ByRef i As Integer)
        i += 1

    End Sub

    Public Sub FooRef(ByVal Pole As Integer())
        Pole(1) = New Integer()
    End Sub

    Public Sub BarRef(ByRef Pole As Integer())
        Pole(2) = New Integer()
    End Sub

    Sub Main()
        'Dim Value As Integer = 1
        'Dim Pole As Integer() = Nothing

        'Foo(Value)
        'Console.WriteLine(Value)

        'Bar(Value)
        'Console.WriteLine(Value)


        Dim S As String = "kk"
        Dim i As Integer

        Console.WriteLine(If(Integer.TryParse(S, i), i, "chyba, nie je to cislo"))


        Console.ReadLine()

    End Sub

End Module
