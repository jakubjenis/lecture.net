Option Strict On

Module Module1

    Class Jedlo
        Implements IComparable(Of Jedlo)

        Private fCena As Integer
        Private fNazov As String
        'nazov, cena
        'popis, priprava, recept...


        Public Sub New(C As Integer, N As String)
            fCena = C : fNazov = N
        End Sub

        Public Function CompareTo(other As Jedlo) As Integer Implements System.IComparable(Of Jedlo).CompareTo
            Return fCena.CompareTo(other.fCena)
        End Function

        Public ReadOnly Property Nazov As String
            Get
                Return fNazov
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return fNazov
        End Function

    End Class

    Class Node(Of T)
        Private fValue As T
        Private fLeft, fRight As Node(Of T)
        Private fPosition As Integer

        Public Sub New(V As T)
            fValue = V
        End Sub

        Public ReadOnly Property Value As T
            Get
                Return fValue
            End Get
        End Property

        Public Property Left As Node(Of T)
            Get
                Return fLeft
            End Get
            Set(value As Node(Of T))
                fLeft = value
            End Set
        End Property

        Public Property Right As Node(Of T)
            Get
                Return fRight
            End Get
            Set(value As Node(Of T))
                fRight = value
            End Set
        End Property

        Public Property Position As Integer
            Get
                Return fPosition
            End Get
            Set(value As Integer)
                fPosition = value
            End Set
        End Property

    End Class

    Class Tree(Of T As IComparable(Of T))
        Implements IEnumerable(Of Node(Of T)) 'Node(of T) preto, lebo prehcadzame prvky takeho typu

        Private fRoot As Node(Of T) = Nothing

        Public Sub Add(I As T)
            If fRoot Is Nothing Then fRoot = New Node(Of T)(I) : Return
            Dim Akt As Node(Of T) = fRoot
            While True
                If I.CompareTo(Akt.Value) >= 0 Then
                    If Akt.Right Is Nothing Then
                        Akt.Right = New Node(Of T)(I) : Exit While
                    Else
                        Akt = Akt.Right
                    End If
                Else
                    If Akt.Left Is Nothing Then
                        Akt.Left = New Node(Of T)(I) : Exit While
                    Else
                        Akt = Akt.Left
                    End If
                End If
            End While
        End Sub

        Public Sub Vypis()
            VypisPodstrom(fRoot)
        End Sub

        Public Sub ConsoleVypis()
            If fRoot Is Nothing Then Return
            Dim F As New Queue(Of Node(Of T)), TmpF As New Queue(Of Node(Of T)), Tmp As Queue(Of Node(Of T))
            Dim Akt As Node(Of T), H As Integer = 0, W As Integer = 0
            'chod riadok po riadku a vypisuj
            For I As Integer = 0 To 1
                Akt = fRoot : F.Enqueue(fRoot)
                Do
                    'Prejdi frontu F, vypis, vymaz, pridaj potomkov
                    While F.Count > 0
                        Akt = F.Dequeue
                        If Akt.Left IsNot Nothing Then
                            TmpF.Enqueue(Akt.Left)
                            Akt.Left.Position = Akt.Position - W
                        End If
                        If Akt.Right IsNot Nothing Then
                            TmpF.Enqueue(Akt.Right)
                            Akt.Right.Position = Akt.Position + W
                        End If
                        If I = 1 Then
                            Console.SetCursorPosition(Akt.Position, Console.CursorTop) : Console.Write("{0} ", Akt.Value)
                            If Akt.Left IsNot Nothing Then Console.SetCursorPosition(Akt.Position - (W \ 2), Console.CursorTop + 1) : Console.Write("/"c)
                            If Akt.Right IsNot Nothing Then Console.SetCursorPosition(Akt.Position + (W \ 2), Console.CursorTop + If(Akt.Left Is Nothing, 1, 0)) : Console.Write("\"c)
                            If Akt.Left IsNot Nothing OrElse Akt.Right IsNot Nothing Then Console.SetCursorPosition(0, Console.CursorTop - 1)
                        End If
                    End While
                    W = W \ 2
                    If I = 1 Then Console.WriteLine() : Console.WriteLine()
                    'posun sa o uroven nizsie
                    Tmp = F : F = TmpF : TmpF = Tmp
                    If I = 0 Then H += 1
                Loop Until F.Count = 0
                W = CInt(Math.Pow(2, H - 1)) 'aktualna medzera mezdi prvkami
                fRoot.Position = W * 2
            Next
        End Sub

        Private Sub VypisPodstrom(Akt As Node(Of T))
            If Akt Is Nothing Then Return
            VypisPodstrom(Akt.Left)
            Console.WriteLine(Akt.Value)
            VypisPodstrom(Akt.Right)
        End Sub

        Public Function Find(I As T) As Node(Of T)
            Dim Akt As Node(Of T) = fRoot
            While Akt IsNot Nothing
                If Akt.Value.CompareTo(I) = 0 Then Exit While
                If I.CompareTo(Akt.Value) > 0 Then
                    Akt = Akt.Right
                Else
                    Akt = Akt.Left
                End If
            End While
            Return Akt
        End Function

#Region "IEnumerable"

        Public Function GetEnumerator() As System.Collections.Generic.IEnumerator(Of Node(Of T)) Implements System.Collections.Generic.IEnumerable(Of Node(Of T)).GetEnumerator
            Return New TreeEnumerator(Of T)(fRoot)
        End Function

        Public Function GetEnumerator1() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return GetEnumerator()
        End Function

#End Region

    End Class

    Class TreeEnumerator(Of T)
        Implements IEnumerator(Of Node(Of T)) 'lebo prechadzame prvky Node(of T)

        Private fRoot As Node(Of T) = Nothing
        Private fAkt As Node(Of T) = Nothing

        Public Sub New(R As Node(Of T))
            fRoot = R : fAkt = R
        End Sub

        Public ReadOnly Property Current As Node(Of T) Implements System.Collections.Generic.IEnumerator(Of Node(Of T)).Current
            Get
                Return fAkt
            End Get
        End Property

        Public ReadOnly Property Current1 As Object Implements System.Collections.IEnumerator.Current
            Get
                Return Current
            End Get
        End Property

        Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext

        End Function

        Public Sub Reset() Implements System.Collections.IEnumerator.Reset
            fAkt = fRoot
        End Sub

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: dispose managed state (managed objects).
                End If

                ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
                ' TODO: set large fields to null.
            End If
            Me.disposedValue = True
        End Sub

        ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
        'Protected Overrides Sub Finalize()
        '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        '    Dispose(False)
        '    MyBase.Finalize()
        'End Sub

        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class

    Sub Main()

        Dim Tmp As Integer() = {3, 1, 5, 6, 7, 2, 4, 5}
        Dim Strom As New Tree(Of Integer)
        Dim S As New SortedSet(Of Jedlo)
        For Each ST As Jedlo In S

        Next
        For Each I As Integer In Tmp
            Strom.Add(I)
        Next
        Strom.ConsoleVypis()

        'For Each I As Integer In Strom

        'Next

        'for each I as integer in Strom



        'next

        'If Strom.Find(4) IsNot Nothing Then Console.WriteLine("4 tam je")
        'If Strom.Find(10) IsNot Nothing Then Console.WriteLine("10 tam je")

        'Dim Tmp2 As String() = {"adam", "Jozko", "jurko", "jozko", "ferko"}
        'Dim Strom2 As New Tree(Of String)
        'For Each S As String In Tmp2
        '    Strom2.Add(S)
        'Next
        'Strom2.Vypis()

        'Dim Strom3 As New Tree(Of Jedlo)
        'Strom3.Add(New Jedlo(3, "Rezen"))
        'Strom3.Add(New Jedlo(2, "Nakyp"))
        'Strom3.Add(New Jedlo(1, "Buchta"))
        'Strom3.Vypis()

        Console.ReadLine()

    End Sub

End Module
