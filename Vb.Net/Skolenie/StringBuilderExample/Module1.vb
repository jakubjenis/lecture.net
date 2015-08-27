Imports System.Text
Imports System.IO

Module Module1

    Sub Main()

        Dim SB As New StringBuilder()
        Dim SR As New StreamReader("file.txt")
        Dim Line As String = Nothing
        While Not SR.EndOfStream
            Line = SR.ReadLine()
            SB.AppendLine(If(Line.Length < 2, Nothing, Line.Trim().Substring(1, Line.Length - 2)))
        End While
        Console.WriteLine(SB.ToString())

    End Sub


End Module
