Imports System.Data.SqlClient
Imports System.Web.UI.WebControls

Public Class StudentLists
    Private Sub lists_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sqlserver.connect()

        callLoadDataGrid()

    End Sub


    Private Sub LoadDataInGrid()

        sqlcmd.CommandText = ("select (studentID) as 'Student ID', (cardno) as 'Card Number', " &
        "CONCAT(surname,', ',firstname,' ',mname) as 'Student Name',(sex) as Gender,(email) as Email, " &
        "(guardcontact) as 'Guardian Contact Number' from studentdata")
        sqlcmd.Connection = sqlconn

        Dim DS As New DataSet

        Dim sqlda As New SqlDataAdapter(sqlcmd)
        sqlda.Fill(DS, "studentdata")
        DataGridView1.DataSource = DS
        DataGridView1.DataMember = "studentdata"


    End Sub

    Private Sub callLoadDataGrid()
        If sqlconn.State = ConnectionState.Open Then
            sqlconn.Close()
            sqlconn.Open()

            Call LoadDataInGrid()

            sqlconn.Close()
        Else
            sqlconn.Open()
            Call LoadDataInGrid()
            sqlconn.Close()
        End If
    End Sub



    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        sqlcmd.CommandText = ("select (studentID) as 'Student ID', (cardno) as 'Card Number' , CONCAT(surname,', ',firstname,' ',mname)" &
        "as 'Student Name' , (sex) as Gender , (email) as Email , (guardcontact) as" &
        "'Guardian Contact Number' from studentdata where studentID Like '" & TextBox1.Text & "%' or CONCAT(surname+ ' ' +firstname,mname) Like '" & TextBox1.Text & "%'")
        sqlcmd.Connection = sqlconn

        Dim sqlda As New SqlDataAdapter(sqlcmd)
        Dim DS = New DataSet
        sqlda.Fill(DS, "studentdata")
        DataGridView1.DataSource = DS.Tables("studentdata").DefaultView

    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Me.Close()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SLH.Show()
    End Sub
End Class