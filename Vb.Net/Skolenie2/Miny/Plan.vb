Option Strict On

Public Class Plan
    Private Shared fButtonRowCount As Integer = 5
    Private Shared fMineCount As Integer = 10
    Private Shared fTable(fButtonRowCount - 1, fButtonRowCount - 1) As Integer
    Private Shared fMinesMarked As Integer = 0
    Private Shared fButtonWidth As Integer = 30

    Public Shared Sub Redraw(DrawForm As frmMiny)
        GenerateMines() : Draw(DrawForm)
    End Sub

    ''' <summary>
    ''' Vygeneruje poziciu min, a spocita cisla na plane
    ''' </summary>
    ''' <remarks>volat iba na zaciatku a pri novej hre</remarks>
    Private Shared Sub GenerateMines()
        Dim MinesLeft As Integer = fMineCount, X, Y As Integer, R As New Random
        Array.Clear(fTable, 0, fButtonRowCount * fButtonRowCount)
        Randomize()
        While MinesLeft > 0
            X = R.Next(fButtonRowCount) : Y = R.Next(fButtonRowCount)
            If fTable(X, Y) > -1 Then fTable(X, Y) = -1 : MinesLeft -= 1
        End While

        'Spocitaj cisla
        Dim C As Integer
        For I As Integer = 0 To fButtonRowCount - 1
            For J As Integer = 0 To fButtonRowCount - 1
                If fTable(J, I) = -1 Then Continue For
                'Spocitaj miny v okoli
                C = 0
                If J > 0 AndAlso I > 0 AndAlso fTable(J - 1, I - 1) = -1 Then C += 1
                If J > 0 AndAlso fTable(J - 1, I) = -1 Then C += 1
                If J > 0 AndAlso I < fButtonRowCount - 1 AndAlso fTable(J - 1, I + 1) = -1 Then C += 1
                If I < fButtonRowCount - 1 AndAlso fTable(J, I + 1) = -1 Then C += 1
                If I > 0 AndAlso fTable(J, I - 1) = -1 Then C += 1
                If J < fButtonRowCount - 1 AndAlso I > 0 AndAlso fTable(J + 1, I - 1) = -1 Then C += 1
                If J < fButtonRowCount - 1 AndAlso fTable(J + 1, I) = -1 Then C += 1
                If J < fButtonRowCount - 1 AndAlso I < fButtonRowCount - 1 AndAlso fTable(J + 1, I + 1) = -1 Then C += 1
                fTable(J, I) = C
            Next
        Next

    End Sub

    ''' <summary>
    ''' Nakresli hraciu plochu
    ''' </summary>
    ''' <param name="F">instancia formulara na ktory kreslim</param>
    ''' <remarks></remarks>
    Private Shared Sub Draw(F As frmMiny)
        Dim B As Button : F.lblMinesLeft.Text = fMineCount.ToString()
        F.Size = New Size(fButtonRowCount * fButtonWidth + 12, fButtonRowCount * fButtonWidth + 85)
        F.pnlMines.Size = New Size(fButtonRowCount * fButtonWidth, fButtonRowCount * fButtonWidth)
        F.pnlMines.Controls.Clear()
        For I As Integer = 0 To fButtonRowCount - 1
            For J As Integer = 0 To fButtonRowCount - 1
                B = New Button With {.Parent = F.pnlMines, .Size = New Size(fButtonWidth + 1, fButtonWidth + 1), .Top = I * fButtonWidth, .Left = J * fButtonWidth}
                B.Tag = New ButtonInfo(J, I, fTable(J, I), False) ': B.Text = fTable(J, I).ToString
                AddHandler B.MouseDown, AddressOf F.Mine_Click
            Next
        Next
    End Sub

    Public Shared Property MinesMarked As Integer
        Get
            Return fMinesMarked
        End Get
        Set(value As Integer)
            If value <= fMineCount Then
                fMinesMarked = value
            Else
                Throw New Exception("WTF")
            End If
        End Set
    End Property

    Private Sub HandleButton()

    End Sub

    Public Shared Property MineCount As Integer
        Get
            Return fMineCount
        End Get
        Set(value As Integer)
            fMineCount = value
        End Set
    End Property

    Public Shared ReadOnly Property ButtonWidth As Integer
        Get
            Return fButtonWidth
        End Get
    End Property

End Class

Class ButtonInfo

    Private fX, fY, fObsah As Integer
    Private fIsMarked As Boolean

    Public Sub New(X As Integer, Y As Integer, O As Integer, M As Boolean)
        fX = X : fY = Y : fObsah = O : fIsMarked = M
    End Sub

    Public ReadOnly Property X As Integer
        Get
            Return fX
        End Get
    End Property

    Public ReadOnly Property Y As Integer
        Get
            Return fY
        End Get
    End Property

    Public ReadOnly Property Obsah As Integer
        Get
            Return fObsah
        End Get
    End Property

    Public Property IsMarked As Boolean
        Get
            Return fIsMarked
        End Get
        Set(value As Boolean)
            fIsMarked = value
        End Set
    End Property

    Public ReadOnly Property IsMine As Boolean
        Get
            Return fObsah = -1
        End Get
    End Property


End Class
