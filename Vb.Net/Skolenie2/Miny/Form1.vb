Option Strict On
Public Class frmMiny

    'Po GameOver zobrazit vsetky miny, zmiznu po redraw 
    'Po kliknuti na 0 zobrazit maximalne okolie
    'Pridaj obrazok, usmievavy pri vyhre, smutny pri prehre, neutral pri hre

    'Modifikacia klikania: kliknutie lavym tlacitkom na cervene oznacene tlacitko by malo
    'zrusit oznacenie, nie overovat minu :)

    Private Sub Form1_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Plan.Redraw(Me)
    End Sub

    Public Sub Mine_Click(Sender As Object, E As MouseEventArgs)
        Dim B As Button = DirectCast(Sender, Button), BI As ButtonInfo = DirectCast(B.Tag, ButtonInfo)
        Dim L As Label
        If E.Button = MouseButtons.Left Then
            If BI.IsMine Then
                MsgBox("Game over") : Plan.Redraw(Me)
            Else
                ' pnlMines.Controls.Remove(B)
                B.Parent = Nothing
                L = New Label With {.TextAlign = ContentAlignment.MiddleCenter, .Size = New Size(Plan.ButtonWidth, Plan.ButtonWidth), .Parent = pnlMines, .Text = BI.Obsah.ToString(), .Location = New Point(BI.X * Plan.ButtonWidth, BI.Y * Plan.ButtonWidth)}
            End If
        ElseIf E.Button = MouseButtons.Right Then
            If Plan.MinesMarked = Plan.MineCount AndAlso Not BI.IsMarked Then Return 'ak si na nule, neoznacuj
            Plan.MinesMarked += If(BI.IsMarked, -1, 1) : lblMinesLeft.Text = (Plan.MineCount - Plan.MinesMarked).ToString
            B.BackColor = If(BI.IsMarked, Color.Transparent, Color.Red) : BI.IsMarked = Not BI.IsMarked
        End If
        'Uspesny koniec hry
        If Plan.MinesMarked = Plan.MineCount AndAlso pnlMines.Controls.OfType(Of Button).Count = Plan.MineCount Then
            MsgBox("Vyhrali ste")
        End If
    End Sub

    Private Sub BtnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        Plan.Redraw(Me)
    End Sub

End Class
