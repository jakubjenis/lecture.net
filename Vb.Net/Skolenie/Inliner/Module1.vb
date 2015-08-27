Option Strict On

Imports System.IO
Imports System.Text

Module Module1

    Sub Main()

        Dim SR As New StreamReader("file.txt"), L As New List(Of String), Max As Integer = 0
        Dim PocetMedzier As Integer = 0, Tmp As Integer = 0, Modulo As Integer = 0, SB As New StringBuilder()

        While Not SR.EndOfStream
            L.Add(SR.ReadLine.Trim())
            Max = If(L(L.Count - 1).Length > Max, L(L.Count - 1).Length, Max)
        End While

        For Each Line As String In L
            Dim SplitLine As String() = Line.Split()
            If SplitLine.Length <= 1 Then Continue For
            'Vypocitaj pocet medzier
            PocetMedzier = Max - Line.Length + (SplitLine.Length - 1)
            Tmp = CInt(Math.Floor(PocetMedzier / (SplitLine.Length - 1)))
            'Napln medzery
            Modulo = PocetMedzier Mod (SplitLine.Length - 1)
            Dim tmpModulo = Modulo
            For I As Integer = 0 To SplitLine.Length - 1
                SB.Append(SplitLine(I))
                'ak mas zvysne medzery, tak napis medzeru naviac
                If I < SplitLine.Length - 1 Then
                    If Modulo > 0 Then
                        SB.Append(" ")
                        Modulo -= 1
                    End If
                    For J As Integer = 0 To Tmp - 1
                        SB.Append(" ")
                    Next
                End If
            Next
            ' SB.Append(" " & PocetMedzier & " " & Tmp & " " & tmpModulo)
            SB.AppendLine()
        Next

            Console.WriteLine(SB)
            Console.ReadLine()

    End Sub

End Module
