Imports System.Data.SqlClient
Imports System.Diagnostics.Metrics
Imports System.IO
Imports System.Net
Imports System.Reflection
Imports System.Security.Policy
Imports System.Windows.Forms.AxHost
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ListView
Imports System.Drawing.Imaging
Imports System.Reflection.Metadata
Public Class LoginAdmin
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form2.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Call callLogin()
        txtUsername.Clear()
        txtPassword.Clear()

    End Sub

    Private Sub Login()

        sqlcmd.CommandText = ("select * from tbl_loginAdmin where Username = '" & txtUsername.Text & "' and Password = '" & txtPassword.Text & "'")
        sqlcmd.Connection = sqlconn

        Dim log As SqlDataReader
        log = sqlcmd.ExecuteReader()

        If log.HasRows Then
            log.Read()
            Admin.Show()
            Me.Hide()

        Else
            MsgBox("Incorrect Username or Password")
        End If


    End Sub

    Private Sub callLogin()
        If sqlconn.State = ConnectionState.Open Then
            sqlconn.Close()
            sqlconn.Open()

            Call Login()

            sqlconn.Close()
        Else
            sqlconn.Open()
            Call Login()
            sqlconn.Close()
        End If
    End Sub

    Private Sub LoginAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sqlserver.connect()
    End Sub

End Class