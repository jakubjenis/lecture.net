Module Module1

    Interface IPorovnatelny(Of T)
        Function JeVacsiAko(P2 As T) As Boolean
    End Interface

    Interface IVypisatelny
        Function Vypis() As String
    End Interface

    Class Animal
        Implements IPorovnatelny(Of Animal), IComparable(Of Animal), IVypisatelny

        Private fVyska As Integer, fJmeno As String

        Public Sub New(Jmeno As String, Vyska As Integer)
            fVyska = Vyska : fJmeno = Jmeno
        End Sub

        Public Function JeVacsiAko(P2 As Animal) As Boolean Implements IPorovnatelny(Of Animal).JeVacsiAko
            Return fVyska > P2.Vyska
        End Function

#Region "Properties"

        Public Property Vyska As Integer
            Get
                Return fVyska
            End Get
            Set(value As Integer)
                fVyska = value
            End Set
        End Property

        Public Property Jmeno As String
            Get
                Return fJmeno
            End Get
            Set(value As String)
                fJmeno = value
            End Set
        End Property

#End Region

        Public Function CompareTo(other As Animal) As Integer Implements System.IComparable(Of Animal).CompareTo
            If fVyska > other.Vyska Then
                Return -1
            ElseIf fVyska < other.Vyska Then
                Return 1
            Else
                Return 0
            End If
        End Function

        Public Overrides Function ToString() As String
            Return Jmeno & " " & fVyska.ToString()
        End Function

        Public Function Vypis() As String Implements IVypisatelny.Vypis
            Return fVyska.ToString()
        End Function
    End Class

    Class Zoznam(Of T As {IPorovnatelny(Of T), IComparable(Of T), IVypisatelny})
        Dim Pole(1) As T
        Dim TmpPole As T()
        Dim I As Integer = 0 : Dim Tmp As T

        Public Sub Add(H As T)
            If I = Pole.Length Then
                TmpPole = New T(Pole.Length * 2) {}
                For Index As Integer = 0 To Pole.Length - 1
                    TmpPole(Index) = Pole(Index)
                Next
                Pole = TmpPole : TmpPole = Nothing
            End If
            Pole(I) = H
            I += 1
        End Sub

        Public Sub Swap(ByRef P1 As T, ByRef P2 As T)
            Tmp = P1 : P1 = P2 : P2 = Tmp
        End Sub

        Public Sub Sort()
            'BubbleSort
            ' JePrvyVacsiPrvky(o1 as T, o2 as T) == >
            For J As Integer = 0 To I - 2
                For K As Integer = 0 To I - 2
                    If Pole(K).JeVacsiAko(Pole(K + 1)) Then
                        Swap(Pole(K), Pole(K + 1))
                    End If
                Next
            Next
        End Sub

        Public Sub Vypis()
            For Index As Integer = 0 To I - 1
                Console.WriteLine(Pole(Index).Vypis)
            Next
            Dim L As List(Of String)
        End Sub

    End Class

    Sub Main()
        Dim S As New Zoznam(Of Animal)
        S.Add(New Animal("zirafa", 5103)) : S.Add(New Animal("slon", 2817))
        S.Add(New Animal("tiger", 1200)) : S.Add(New Animal("opica", 251))
        S.Sort()
        S.Vypis()
        Console.ReadLine()
    End Sub

End Module
