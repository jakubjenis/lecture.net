Module Module1

    Sub Main()

        Dim TelZoznam As New SortedList(Of String, String)

        TelZoznam.Add("Jozko", "starahodnota")
        If Not TelZoznam.ContainsKey("Jozko") Then TelZoznam.Add("Jozko", "Hodnota")
        TelZoznam("Jozko") = "novahodnota"
        TelZoznam.Add("Janko", "+421758295")

        If TelZoznam.ContainsValue("Hodnota") Then Console.WriteLine("Obsahuje Hodnota")

        'If TelZoznam.ContainsKey("Jozko") Then Console.WriteLine(TelZoznam("Jozko"))

        For Each Item As KeyValuePair(Of String, String) In TelZoznam
            Console.WriteLine(Item.Key & " " & Item.Value)
        Next

        Dim Slovnik As New Dictionary(Of String, String)
        Slovnik.Add("Ahoj", "Hello")



    End Sub

End Module
