Public Class Form1
    'DEFINICIA EVENTU

    'V ramci triedy Button, definicia Eventu Click
    Public Delegate Sub Btn_Click(Sender As Object, E As EventArgs)
    Public Event ClickMe As Btn_Click

    'Jednoduchsie
    Public Event VytvorItem()

    Public Sub New()
        InitializeComponent()
        'AddHandler naviaze na tomto riadku kodu obsluhu udalosti VytvorItem na objekte Me na metodu Ctreate_Item
        AddHandler Me.VytvorItem, AddressOf Create_Item
    End Sub

    'Handles strazi udalost Click, tlacitka btnAddItem
    Private Sub btnAddItem_Click(sender As System.Object, e As System.EventArgs) Handles btnAddItem.Click
        'VYVOLANIE EVENTU
        RaiseEvent VytvorItem()
    End Sub

    Private Sub Create_Item()
        MsgBox("Hi")
    End Sub

End Class
