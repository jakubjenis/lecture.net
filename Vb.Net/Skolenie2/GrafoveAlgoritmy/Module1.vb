Option Strict On

Imports System.Text

Module Module1

    'popisuje jedno mesto
    Class Node

        Private fName As String
        Private fNodes As New SortedList(Of String, Node) 'ak som v meste, su to SUSEDIA !!!
        Private fParent As Node

        Public Sub New(Name As String)
            fName = Name
            fParent = Me
        End Sub

        Public Function BFS(Start As String, Ciel As String) As Integer
            'F reprezentuje frontu miest, v ktorych sa momentalne nachadzame
            'Hladame cestu zo Startu do Ciela => F na zaciatku obsahuje iba mesto Start
            'V kazdom kroku sa pozri na vrchol Fronty, odstran ho,  a pridaj na koniec fronty 
            'susedov, v ktorych sme este neboli (inak nam to nikdy nezastavi !!!)
            'Toto vzdy skonci prazdnou frontou

            'Chcem navrhnut strukturu S, ktora nam bude indikovat pre kazdy vrchol dlzku minimalnej cesty
            'Na zatiatku obsahuje S same nekonecne(maximalna mozne) dlzky pre kazde mesto
            'Pri vytahovani prvkov z fronty F, sa pozerame do struktury S 
            'Ak je v S-ku na pozicii vytahovaneho prvku nekonecno, este sme tam neboli
            ' => nastav tam cislo (vzdialenost vytahovaneho prvku + 1)
            'Inak porovnaj, ci je tam mensie cislo, ako by sme chceli zapisat - ak nie, tak ho prepis

            'Ked je fronta prazdna, tak sa pozri do struktury S, ci je tam nekonecno 
            'Ak nie, vypis minimalnu cestu

            Dim F As New Queue(Of Node)
            Dim S As New SortedList(Of String, Integer)
            Dim Akt As Node

            F.Enqueue(fNodes(Start)) 'fNodes(Start) - pozri sa do mapy, a najdi Node Start
            For Each Mesto As KeyValuePair(Of String, Node) In fNodes
                S.Add(Mesto.Key, -1)
            Next
            S(Start) = 0

            'ALGORITMUS BFS
            While F.Count > 0
                Akt = F.Dequeue()
                For Each Sused As KeyValuePair(Of String, Node) In Akt.fNodes
                    If S(Sused.Key) = -1 Then
                        F.Enqueue(Sused.Value) 'Pridaj suseda do fronty
                        S(Sused.Key) = S(Akt.fName) + 1
                    End If
                Next
            End While

            Return S(Ciel)

        End Function

        'Prida nove mesto do mapy a vytvori suseda
        Public Sub Add(Nazov As String)
            If fParent.Nodes.ContainsKey(Nazov) Then
                If fParent isnot Me then fNodes.Add(Nazov, fParent.Nodes(Nazov))
                Else
                    Dim N As New Node(Nazov) 'vytvor mesto
                    If Me IsNot fParent Then fParent.Nodes.Add(Nazov, N) 'Ak vytvaram suseda, tak pridaj aj do mapy
                    Me.fNodes.Add(Nazov, N)
                    N.fParent = fParent
                End If
        End Sub

        Public Overloads Sub Remove(Nazov As String)
            fNodes.Remove(Nazov)
        End Sub

        Public Overloads Sub Remove(Node As Node)
            If fNodes.ContainsValue(Node) Then fNodes.RemoveAt(fNodes.IndexOfValue(Node))
        End Sub

        Public Overrides Function ToString() As String
            Dim SB As New StringBuilder()
            'ak si na mape, vypis vsetky mesta
            If Me Is fParent Then
                For Each Mesto As KeyValuePair(Of String, Node) In fNodes
                    SB.AppendLine(VypisMesto(Mesto.Value))
                Next
            Else
                'inak vypis len seba
                Return VypisMesto(Me)
            End If
            Return SB.ToString()
        End Function

        Private Function VypisMesto(Mesto As Node) As String
            Dim SB As New StringBuilder()
            SB.Append(Mesto.fName) : SB.Append(": ")
            For Each Sused As KeyValuePair(Of String, Node) In Mesto.fNodes
                SB.Append(Sused.Value.Name) : SB.Append(", ")
            Next
            Return SB.ToString()
        End Function

#Region "Properties"

        Public ReadOnly Property Nodes As SortedList(Of String, Node)
            Get
                Return fNodes
            End Get
        End Property

        Default Public ReadOnly Property Item(Index As String) As Node
            Get
                Return fNodes(Index)
            End Get
        End Property

        Public Property Name As String
            Get
                Return fName
            End Get
            Set(value As String)
                fName = value
            End Set
        End Property

#End Region

    End Class


    Sub Main()

        Dim Mapa As New Node("Slovensko")

        Dim Mesta()() As String = {
                                     New String() {"BA", "NR", "TN"},
                                     New String() {"NR", "TN", "BB", "BA", "KE"},
                                     New String() {"BB", "PP", "NR"},
                                     New String() {"TN", "NR", "BA"},
                                     New String() {"PP", "BB", "KE"},
                                     New String() {"KE", "PP"}
                                  }

        For Each Susedia As String() In Mesta
            'Pridat mesto
            Mapa.Add(Susedia(0))
            'Pridat susedov
            For Each Mesto In Susedia
                If Not Mesto = Susedia(0) Then Mapa(Susedia(0)).Add(Mesto)
            Next
        Next
        Console.WriteLine(Mapa.BFS("BA", "PP"))
        Console.ReadLine()
    End Sub

End Module
