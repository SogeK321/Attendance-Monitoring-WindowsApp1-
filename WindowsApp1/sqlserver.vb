Imports System.Data.SqlClient
Module sqlserver

    Public sqlconn As New SqlConnection

    Public sqlcmd As New SqlCommand

    Public sqldr As SqlDataReader

    Public strsql As String

    Public sqlda As New SqlDataAdapter

    Sub connect()
        If sqlconn.State = ConnectionState.Open Then sqlconn.Close()

        sqlconn.ConnectionString = "Data Source=DESKTOP-M5O9GP1\SQLEXPRESS;Initial Catalog=src_db; user id = sa; password = 12345678"

        sqlconn.Open()
    End Sub

End Module
