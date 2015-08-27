Module Module1

    Public Enum Smer As Integer
        Hore
        Dole
        Vlavo
        Vpravo
    End Enum

    Sub Main()

        Dim Smer As Smer = Smer.Hore
        Dim Key As ConsoleKeyInfo

        Dim x, y As Integer
        x = 1 : y = 1

        Console.Write("X")

        While (True)

            Key = Console.ReadKey()

            Select Case Key.KeyChar
                Case "i" : If y > 0 Then y -= 1
                Case "k" : If y < Console.WindowHeight - 1 Then y += 1
                Case "l" : If x < Console.WindowWidth - 1 Then x += 1
                Case "j" : If x > 0 Then x -= 1
            End Select

            Console.Clear()
            Console.SetCursorPosition(x, y)

            Console.Write("X")

        End While

    End Sub

End Module
