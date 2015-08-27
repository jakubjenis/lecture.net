Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlTypes

Public Class Form1



    Private Sub Form1_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Dim conn As New SqlConnection("server=JAKUB-PC\SQLEXPRESS;database=kalendar;user=Skolenie_User;password=bla")
        conn.Open()
        Dim cmd As SqlCommand = conn.CreateCommand()
        cmd.CommandText = "SELECT * FROM Termin WHERE ID=@ID"
        cmd.Parameters.Add(New SqlParameter("@ID", SqlDbType.Int))
        cmd.Parameters("@ID").Value = 1
        cmd.ExecuteNonQuery()


    End Sub
End Class
