Imports System.Data.SqlClient
Imports System.Diagnostics.Metrics
Imports System.IO
Imports System.Net
Imports System.Reflection
Imports System.Security.Policy
Imports System.Windows.Forms.AxHost
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ListView
Imports System.Reflection.Metadata
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Runtime
Imports DocumentFormat.OpenXml.Vml
Imports System.Web

Public Class Form1
    Dim gender As String
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sqlserver.connect()
        Call callLoadDataGrid()

    End Sub

    Private Sub update_records()

        Dim sqlcmd As New SqlClient.SqlCommand
        Dim ms As New MemoryStream()

        PictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
        Dim data As Byte() = ms.GetBuffer
        Dim p As New SqlParameter("@picstudent", SqlDbType.Image)
        p.Value = data
        sqlcmd.Parameters.Add(p)

        strsql = "UPDATE studentdata SET cardno = '" & card_number.Text & "', guardcontact = '" & contact_no.Text & "', studpic = @picstudent WHERE studentID = '" & student_id.Text & "'"
        sqlcmd.CommandText = strsql
        sqlcmd.Connection = sqlconn
        sqlcmd.ExecuteNonQuery()

        student_id.Clear()
        surname.Clear()
        sy.Clear()
        card_number.Clear()
        esc_no.Clear()
        firstname.Clear()
        middle_name.Clear()
        extension_name.Clear()
        male.Checked = False
        female.Checked = False
        place_of_birth.Clear()
        address1.Clear()
        address2.Clear()
        address3.Clear()
        address4.Clear()
        telephone.Clear()
        mobile_no.Clear()
        email.Clear()
        citizenship.Clear()
        religion.Clear()
        fathers_name1.Clear()
        fathers_name2.Clear()
        fathers_name3.Clear()
        fathers_name4.Clear()
        mothers_name1.Clear()
        mothers_name2.Clear()
        mothers_name3.Clear()
        mothers_name4.Clear()
        guardians_name.Clear()
        contact_no.Clear()
        relation.Clear()
        date_of_birth.Value = Date.Today
        PictureBox1.Image = Nothing

    End Sub
    Private Sub updateImage()
        Dim sqlcmd As New SqlClient.SqlCommand

        Dim cardNo As String = card_number.Text + ".jpg"
        Dim folder As String = "C:\Files\"
        strsql = "update studentdata set image = @cardNo where studentID = '" & student_id.Text & "'"
        Using sqlconn As SqlConnection = New SqlConnection("Data Source=DESKTOP-M5O9GP1\SQLEXPRESS;Initial Catalog=src_db; user id = sa; password = 12345678")
            sqlcmd.CommandText = strsql
            sqlcmd.Connection = sqlconn
            sqlcmd.Parameters.AddWithValue("@cardNo", cardNo)
            sqlconn.Open()
            sqlcmd.ExecuteNonQuery()
            sqlconn.Close()
            Dim pathstring As String = System.IO.Path.Combine(folder, cardNo)
            Dim a As Image = PictureBox1.Image
            a.Save(pathstring)
            MsgBox("saved image")

        End Using
    End Sub
    Private Sub callupdateImage()
        If sqlconn.State = ConnectionState.Open Then
            sqlconn.Close()
            sqlconn.Open()

            Call updateImage()

            sqlconn.Close()
        Else
            sqlconn.Open()
            Call updateImage()
            sqlconn.Close()
        End If
    End Sub
    Private Sub callUpdateRecords()
        If sqlconn.State = ConnectionState.Open Then
            sqlconn.Close()
            sqlconn.Open()

            Call update_records()

            sqlconn.Close()
        Else
            sqlconn.Open()
            Call update_records()
            sqlconn.Close()
        End If
    End Sub

    Private Sub male_CheckedChanged(sender As Object, e As EventArgs) Handles male.CheckedChanged
        If male.Checked = True And female.Checked = False Then
            gender = "Male"
        ElseIf female.Checked = True And male.Checked = False Then
            gender = "Female"
        End If
    End Sub

    Private Sub female_CheckedChanged(sender As Object, e As EventArgs) Handles female.CheckedChanged
        If male.Checked = True And female.Checked = False Then
            gender = "Male"
        ElseIf female.Checked = True And male.Checked = False Then
            gender = "Female"
        End If
    End Sub

    Private Sub update_button_Click(sender As Object, e As EventArgs) Handles update_button.Click
        Call callUpdateRecords()
        'Call callupdateImage()
        MsgBox("Record Successfully Updated")

    End Sub

    Private Sub callDeleteRecord()
        If sqlconn.State = ConnectionState.Open Then
            sqlconn.Close()
            sqlconn.Open()

            Call deleteRecord()

            sqlconn.Close()
        Else
            sqlconn.Open()
            Call deleteRecord()
            sqlconn.Close()
        End If
    End Sub

    Private Sub deleteRecord()

        Dim sqlcmd As New SqlClient.SqlCommand
        strsql = "Delete from studentdata where studentID = '" & student_id.Text & "'"
        sqlcmd.CommandText = strsql
        sqlcmd.Connection = sqlconn
        sqlcmd.ExecuteNonQuery()

        MessageBox.Show("Student Data Deleted!")
        sqlconn.Close()
    End Sub

    Private Sub LoadDataInGrid()

        sqlcmd.CommandText = ("select (studentID) as 'Student ID', " &
        "surname as 'Last Name', firstname as 'First Name',mname as 'Middle Name' from studentdata")
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

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        sqlcmd.CommandText = ("select (studentID) as 'Student ID', " &
        "surname as 'Last Name', firstname as 'First Name',mname as 'Middle Name' from studentdata " &
        "where studentID Like '" & txtSearch.Text & "%' or surname Like '" & txtSearch.Text & "%' " &
        "or firstname Like '" & txtSearch.Text & "%' or mname Like '" & txtSearch.Text & "%' ")
        sqlcmd.Connection = sqlconn
        Dim sqlda As New SqlDataAdapter(sqlcmd)
        Dim DS = New DataSet
        sqlda.Fill(DS, "studentdata")
        DataGridView1.DataSource = DS.Tables("studentdata").DefaultView

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        Dim SID As String = DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString


        If sqlconn.State = ConnectionState.Open Then
            sqlconn.Close()
            sqlconn.Open()

            sqlcmd.CommandText = "select studentID FROM studentdata where studentID = '" & SID & "'"
            sqlcmd.Connection = sqlconn

            Dim search As SqlDataReader
            search = sqlcmd.ExecuteReader()

            If search.HasRows Then
                search.Read()


                student_id.Text = search.Item("studentID")
                card_number.Text = search.Item("cardno")
                esc_no.Text = search.Item("ESCNO")
                sy.Text = search.Item("lrn")
                surname.Text = search.Item("surname")
                firstname.Text = search.Item("firstname")
                middle_name.Text = search.Item("mname")
                extension_name.Text = search.Item("ExtName")
                If search.Item("sex") = "Male" Then
                    male.Checked = True
                ElseIf search.Item("sex") = "Female" Then
                    female.Checked = True
                End If
                date_of_birth.Text = search.Item("birthday")
                place_of_birth.Text = search.Item("birthplace")
                address1.Text = search.Item("address3")
                address2.Text = search.Item("address2")
                address3.Text = search.Item("address1")
                address4.Text = search.Item("address")
                telephone.Text = search.Item("telephone")
                mobile_no.Text = search.Item("mobile")
                email.Text = search.Item("email")
                citizenship.Text = search.Item("citizenship")
                religion.Text = search.Item("religion")
                fathers_name1.Text = search.Item("father")
                fathers_name2.Text = search.Item("f_firstname")
                fathers_name3.Text = search.Item("f_mname")
                fathers_name4.Text = search.Item("f_ext")
                mothers_name1.Text = search.Item("mother")
                mothers_name2.Text = search.Item("m_firstname")
                mothers_name3.Text = search.Item("m_mname")
                mothers_name4.Text = search.Item("m_ext")
                guardians_name.Text = search.Item("guardian")
                contact_no.Text = search.Item("guardcontact")
                relation.Text = search.Item("cmbrelation")

            End If

            sqlconn.Close()
        Else
            sqlconn.Open()

            sqlcmd.CommandText = "select * FROM studentdata where studentID = '" & SID & "' "
            sqlcmd.Connection = sqlconn

            Dim search As SqlDataReader
            search = sqlcmd.ExecuteReader()

            If search.HasRows Then
                search.Read()
                student_id.Text = search.Item("studentID")
                card_number.Text = search.Item("cardno").ToString
                esc_no.Text = search.Item("ESCNO")
                sy.Text = search.Item("lrn")
                surname.Text = search.Item("surname")
                firstname.Text = search.Item("firstname")
                middle_name.Text = search.Item("mname")
                extension_name.Text = search.Item("ExtName")
                If search.Item("sex") = "Male" Then
                    male.Checked = True
                ElseIf search.Item("sex") = "Female" Then
                    female.Checked = True
                End If
                date_of_birth.Text = search.Item("birthday")
                place_of_birth.Text = search.Item("birthplace")
                address1.Text = search.Item("address3")
                address2.Text = search.Item("address2")
                address3.Text = search.Item("address1")
                address4.Text = search.Item("address")
                telephone.Text = search.Item("telephone")
                mobile_no.Text = search.Item("mobile")
                email.Text = search.Item("email")
                citizenship.Text = search.Item("citizenship")
                religion.Text = search.Item("religion")
                fathers_name1.Text = search.Item("father")
                fathers_name2.Text = search.Item("f_firstname")
                fathers_name3.Text = search.Item("f_mname")
                fathers_name4.Text = search.Item("f_ext")
                mothers_name1.Text = search.Item("mother")
                mothers_name2.Text = search.Item("m_firstname")
                mothers_name3.Text = search.Item("m_mname")
                mothers_name4.Text = search.Item("m_ext")
                guardians_name.Text = search.Item("guardian")
                contact_no.Text = search.Item("guardcontact")
                relation.Text = search.Item("cmbrelation")

                If Not IsDBNull(search.Item("studpic")) Then
                    Dim data As Byte() = DirectCast(search.Item("studpic"), Byte())
                    Dim ms As New MemoryStream(data)
                    PictureBox1.Image = Image.FromStream(ms)


                Else
                    PictureBox1.Image = Nothing
                End If

            End If

            sqlconn.Close()
        End If
    End Sub
    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Me.Close()
    End Sub

    Private Sub btnImage_Click(sender As Object, e As EventArgs) Handles btnImage.Click

        Dim op As OpenFileDialog = New OpenFileDialog
        If op.ShowDialog = DialogResult.OK Then
            PictureBox1.Image = Image.FromFile(op.FileName)
        End If
    End Sub
End Class
