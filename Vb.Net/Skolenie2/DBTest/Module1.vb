Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Module Module1

    Sub Main()


        Dim conn As New SqlConnection("server=JAKUB-PC\SQLEXPRESS;database=kalendar;user=Skolenie_User;password=bla")
        conn.Open()
        Dim cmd As SqlCommand = conn.CreateCommand()
        cmd.CommandText = "SELECT * FROM Termin WHERE ID=@ID"
        cmd.Parameters.Add(New SqlParameter("@ID", SqlDbType.Int))
        cmd.Parameters("@ID").Value = 1
        cmd.ExecuteNonQuery()

    End Sub

End Module
