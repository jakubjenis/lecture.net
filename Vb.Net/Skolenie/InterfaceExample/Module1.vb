Module Module1

    'PriznajFarbu() - vrati farbu objektu

    Public Interface IFarebny
        Sub PriznajFarbu()
        Sub ZmenFarbu()
    End Interface

    Public Enum Pohlavie As Integer
        Muz
        Zena
    End Enum

    Class Osoba
        Protected fVyska, fVaha, fVek As Integer
        Protected fJmeno As String

        Public Property Jmeno As String
            Get
                Return fJmeno
            End Get
            Set(value As String)
                If value.Length > 0 AndAlso value.Length < 50 Then
                    fJmeno = value
                Else
                    Throw New ArgumentException("Dlzka mena je mimo")
                End If
            End Set
        End Property

    End Class

    Class Predmet
        Implements IFarebny

        Protected Dlzka, Sirka, Vyska As Integer

        Public Overridable Sub PriznajFarbu() Implements IFarebny.PriznajFarbu
            Console.WriteLine("Priznavam, som objekt")
        End Sub

        Public Sub ZmenFarbu() Implements IFarebny.ZmenFarbu

        End Sub
    End Class

    Class Muz
        Inherits Osoba
        Implements IFarebny

        Public ReadOnly Property Pohlavie As Pohlavie
            Get
                Return Pohlavie.Muz
            End Get
        End Property

        Public Sub PriznajFarbu() Implements IFarebny.PriznajFarbu
            Console.WriteLine("Priznavam, som muz")
        End Sub

        Public Sub ZmenFarbu() Implements IFarebny.ZmenFarbu

        End Sub
    End Class

    Class Zena
        Inherits Osoba

        Public ReadOnly Property Pohlavie As Pohlavie
            Get
                Return Pohlavie.Zena
            End Get
        End Property

    End Class

    Class Stol
        Inherits Predmet

        Public Overrides Sub PriznajFarbu()
            Console.WriteLine("Priznavam, som STOOOOL")
        End Sub

    End Class

    Class Tabula
        Inherits Predmet

    End Class

    Sub Main()
        Dim L As New List(Of IFarebny)

        L.Add(New Muz)
        L.Add(New Tabula)
        L.Add(New Stol)

        For Each X In L
            X.PriznajFarbu()
        Next
        Dim F As IFarebny = New Stol()


        Dim T As New ArrayList
        T.Add(New Muz)
        T.Add(New Zena)
        T.Add(New Stol)

        For Each X In T
            Dim typee As Type = X.GetType
        Next

    End Sub

End Module
