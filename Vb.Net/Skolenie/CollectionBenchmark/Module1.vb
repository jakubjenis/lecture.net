Module Module1

    Sub Main()

        Dim PocetPrvkov = 1000
        Dim PocetPristupov = 2000000
        Dim Rozsah = 20000

        Dim L As New List(Of Integer)
        Dim SS As New SortedSet(Of Integer)
        Dim T As New Stopwatch

        Randomize()
        Dim R As New Random

        Console.WriteLine("Zacinam pridavat do Listu")
        T.Restart()
        For I As Integer = 0 To PocetPrvkov
            L.Add(R.Next(Rozsah))
        Next
        T.Stop()
        Console.WriteLine("Koniec pridavania do Listu. Cas: {0}", T.ElapsedMilliseconds)


        Console.WriteLine("Zacinam pridavat do SortedSet")
        T.Restart()
        For I As Integer = 0 To PocetPrvkov
            SS.Add(R.Next(Rozsah))
        Next
        T.Stop()
        Console.WriteLine("Koniec pridavania do SortedSetu. Cas: {0}", T.ElapsedMilliseconds)

        Console.WriteLine()
        Console.WriteLine("Zacinam Find v Liste")
        T.Restart()
        For I As Integer = 0 To PocetPristupov
            L.Contains(R.Next(Rozsah))
        Next
        T.Stop()
        Console.WriteLine("Koniec Find v Liste. Cas: {0}", T.ElapsedMilliseconds)

        Console.WriteLine("Zacinam Find v SortedSete")
        T.Restart()
        For I As Integer = 0 To PocetPristupov
            SS.Contains(R.Next(Rozsah))
        Next
        T.Stop()
        Console.WriteLine("Koniec Find v SortedSete. Cas: {0}", T.ElapsedMilliseconds)

        Dim tmp As Integer

        Console.WriteLine()
        Console.WriteLine("Zacinam Random access v Liste")
        T.Restart()
        For I As Integer = 0 To PocetPristupov
            tmp = L(R.Next(PocetPrvkov))
        Next
        T.Stop()
        Console.WriteLine("Koniec Random access v Liste. Cas: {0}", T.ElapsedMilliseconds)

        Console.WriteLine("Zacinam Random access v SortedSete")
        T.Restart()
        For I As Integer = 0 To PocetPristupov
            tmp = SS(R.Next(PocetPrvkov))
        Next
        T.Stop()
        Console.WriteLine("Koniec Random access v SortedSete. Cas: {0}", T.ElapsedMilliseconds)



        Console.ReadLine()
    End Sub

End Module
