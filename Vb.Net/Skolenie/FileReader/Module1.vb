Imports System.IO

Module Module1

    Private Function WordCount(P As String) As Integer
        Dim SR As StreamReader = Nothing
        Try
            SR = New StreamReader(P)
            Dim Line As String = SR.ReadLine : Dim WC As Integer
            While Line IsNot Nothing
                WC += Line.Split().Count()
                Line = SR.ReadLine
            End While
            Return WC
        Catch e As FileNotFoundException
            Console.WriteLine("Nenasiel som ho")
        Catch e As IOException
            Console.WriteLine("Invalid path")
        Catch e As Exception
            Console.WriteLine(e.Message)
        Finally
            If SR IsNot Nothing Then SR.Close()
        End Try
        Return -1
    End Function

    Sub Main(Args As String())
        Try
            If Args.Length > 1 Then Throw New ArgumentException(String.Format("Prilis vela parametrov: {0}", Args.Length))
            Dim Files As String() = If(Args.Length = 0, Directory.GetFiles("."), Directory.GetFiles(Args(0)))
            Dim Sum As Integer = 0
            For Each F In Files
                Sum += WordCount(F)
            Next
            Console.WriteLine(Sum)
            Console.ReadLine()
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try
    End Sub

End Module
