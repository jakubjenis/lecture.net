Module Module1

    Class Item

        Private fValue As Integer
        Private fNext As Item

        Public Sub New(V As Integer)
            fValue = V
        End Sub

        Public Property [Next] As Item
            Get
                Return fnext
            End Get
            Set(value As Item)
                fNext = value
            End Set
        End Property

        Public ReadOnly Property Value As Integer
            Get
                Return fValue
            End Get
        End Property

    End Class

    Class Circle

        Private fFirst As Item = Nothing 'prvy pridany prvok, koren kruhu
        Private fLast As Item = Nothing ' naposledy pridany prvok

        Public Sub Add(I As Integer)
            'Pridanie prveho prvku
            If fFirst Is Nothing Then fFirst = New Item(I) : fLast = fFirst : fFirst.Next = fFirst : Return
            'Pridanie nteho (n>1) prvku
            Dim Akt As New Item(I)
            Akt.Next = fFirst : fLast.Next = Akt : fLast = Akt
        End Sub

        Public Sub Vypis()

            'poznam prvy prvok
            'vypis ho
            'posun sa na dalsi, pokial nenarazim na prvy prvok
            'vypis ho
            'posun sa
            'atd
            If fFirst Is Nothing Then Return
            Dim Akt As Item = fFirst
            Console.WriteLine(Akt.Value)
            Akt = Akt.Next
            While Akt IsNot fFirst
                Console.WriteLine(Akt.Value)
                Akt = Akt.Next
            End While

        End Sub

    End Class

    Sub Main()
        Dim Prvky As Integer() = {4, 6, 8, 1, 3, 5}
        Dim Z As New Circle
        For Each P In Prvky
            Z.Add(P)
        Next

        Z.Vypis()
        Console.ReadLine()
    End Sub

End Module
