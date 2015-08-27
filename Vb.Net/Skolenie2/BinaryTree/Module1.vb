Module Module1

    Class Node

        Private fValue As Integer
        Private fLeft, fRight As Node

        Public Sub New(V As Integer)
            fValue = V
        End Sub

        Public ReadOnly Property Value As Integer
            Get
                Return fValue
            End Get
        End Property

        Public Property Left As Node
            Get
                Return fLeft
            End Get
            Set(value As Node)
                fLeft = value
            End Set
        End Property

        Public Property Right As Node
            Get
                Return fRight
            End Get
            Set(value As Node)
                fRight = value
            End Set
        End Property

    End Class

    Class Tree
        Private fRoot As Node = Nothing

        Public Sub Add(I As Integer)
            If fRoot Is Nothing Then fRoot = New Node(I) : Return
            Dim Akt As Node = fRoot
            While True
                If I >= Akt.Value Then
                    If Akt.Right Is Nothing Then
                        Akt.Right = New Node(I) : Exit While
                    Else
                        Akt = Akt.Right
                    End If
                Else
                    If Akt.Left Is Nothing Then
                        Akt.Left = New Node(I) : Exit While
                    Else
                        Akt = Akt.Left
                    End If
                End If
            End While
        End Sub

        Public Sub Vypis()
            VypisPodstrom(fRoot)
        End Sub

        Private Sub VypisPodstrom(Akt As Node) 'Akt je koren vypisovaneho podstromu
            If Akt Is Nothing Then Return
            'VypisLavyPodstrom
            VypisPodstrom(Akt.Left)
            'VypisSeba
            Console.WriteLine(Akt.Value)
            'VypisPravyPodstrom
            VypisPodstrom(Akt.Right)
        End Sub

        Public Function Find(I As Integer) As Node
            'Posuvaj sa vlavo/vpravo az pokial nenarazis na hladany prvok,
            'alebo na koniec
            Dim Akt As Node = fRoot
            While Akt IsNot Nothing
                If Akt.Value = I Then Exit While
                If I > Akt.Value Then
                    Akt = Akt.Right
                Else
                    Akt = Akt.Left
                End If
            End While
            Return Akt
        End Function

    End Class

    Sub Main()

        Dim Tmp As Integer() = {3, 1, 5, 6, 7, 2, 4, 5}
        Dim Strom As New Tree()
        For Each I As Integer In Tmp
            Strom.Add(I)
        Next
        Strom.Vypis()
        If Strom.Find(4) IsNot Nothing Then Console.WriteLine("4 tam je")
        If Strom.Find(10) IsNot Nothing Then Console.WriteLine("10 tam je")
    End Sub

End Module
