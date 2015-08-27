Option Strict On

Module Module1

    Dim D As Direction = Direction.Right

    Public Enum Direction As Byte
        Up
        Right
        Down
        Left
    End Enum

    Class Element
        Private Const MaxX As Integer = 79
        Private Const MaxY As Integer = 19
        Private Const MinX As Integer = 2
        Private Const MinY As Integer = 2
        Private fX, fY As Integer
        Private fNext, fPrevious As Element
        Private Shared fHead, fTail As Element
        Private Shared RewardX, RewardY As Integer
        Private Shared R As New Random
        Private Shared JustAte As Boolean

        Public Sub New(X As Integer, Y As Integer)
            fX = X : fY = Y
        End Sub

        Public Sub Draw(Optional isHead As Boolean = False)
            Console.SetCursorPosition(fX, fY)
            Console.Write(If(isHead, "o"c, "x"c))
        End Sub

#Region "Shared"

        Public Shared Sub CreateSnake()
            Randomize()
            GenerateReward()
            fHead = New Element(R.Next(30, 50), R.Next(10, 15))
            fTail = fHead
        End Sub

        Public Shared Sub Update()
            Move() : JustAte = False
            If fHead.X = RewardX AndAlso fHead.Y = RewardY Then
                JustAte = True
                GenerateReward()
            End If
        End Sub

        Public Shared Sub DrawAll()
            Dim Akt As Element = fHead
            While Akt IsNot Nothing
                Akt.Draw(fHead Is Akt)
                Akt = Akt.fNext
            End While
            Console.SetCursorPosition(RewardX, RewardY)
            Console.Write("*")
        End Sub

        Private Shared Sub GenerateReward()
            RewardX = R.Next(MinX, MaxX) : RewardY = R.Next(MinY, MaxY)
        End Sub

        Private Shared Sub Move()
            Dim ExX As Integer = fTail.X, ExY As Integer = fTail.Y
            fTail.X = fHead.X : fTail.Y = fHead.Y
            Select Case D
                Case Direction.Up : fHead.Y -= 1
                Case Direction.Right : fHead.X += 1
                Case Direction.Down : fHead.Y += 1
                Case Direction.Left : fHead.X -= 1
            End Select
            Dim ExTail, Second As Element
            If fHead IsNot fTail Then
                ExTail = fTail : Second = fHead.fNext
                If Second IsNot ExTail Then fTail = fTail.fPrevious
                ExTail.fPrevious = fHead
                Second.fPrevious = ExTail
                ExTail.fNext = Second
                fHead.fNext = ExTail
                fTail.fNext = Nothing
            End If
            If JustAte Then
                Dim E As New Element(ExX, ExY)
                fTail.fNext = E
                E.fPrevious = fTail
                fTail = E
            End If
        End Sub

#End Region

#Region "Properties"

        Public Property X As Integer
            Get
                Return fX
            End Get
            Set(value As Integer)
                fX = value
            End Set
        End Property

        Public Property Y As Integer
            Get
                Return fY
            End Get
            Set(value As Integer)
                fY = value
            End Set
        End Property

#End Region

    End Class

    Class Keyboard
        Public Shared Sub Update()
            Dim Key As ConsoleKey
            Key = Console.ReadKey().Key
            Select Case Key
                Case ConsoleKey.LeftArrow : If Not D = Direction.Right Then D = Direction.Left
                Case ConsoleKey.RightArrow : If Not D = Direction.Left Then D = Direction.Right
                Case ConsoleKey.UpArrow : If Not D = Direction.Down Then D = Direction.Up
                Case ConsoleKey.DownArrow : If Not D = Direction.Up Then D = Direction.Down
            End Select
        End Sub
    End Class

    Sub Main()

        Dim Clock As New Stopwatch : Clock.Start()

        Console.CursorVisible = False
        Element.CreateSnake()
        While True
            If Console.KeyAvailable Then Keyboard.Update()
            If Clock.ElapsedMilliseconds > 100 Then
                Console.Clear()
                Element.Update()
                Element.DrawAll()
                Clock.Restart()
            End If
        End While

    End Sub

End Module
