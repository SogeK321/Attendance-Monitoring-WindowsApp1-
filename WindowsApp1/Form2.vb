Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows.Forms.Design
Imports Microsoft.Office.Interop.Excel

Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sqlserver.connect()
        Card_No.Focus()

        Dim todaysdate As String = String.Format("{0:M/dd/yyyy}", DateTime.Now)
        datenow.Text = todaysdate
        'Timer2.Interval = 5000
        Timer2.Enabled = True

        Timer1.Enabled = True

    End Sub
    Private Sub Student_Record()
        Dim student_firstname As String
        Dim student_lastname As String



        sqlcmd.CommandText = "select * FROM studentdata where cardno = '" & Card_No.Text & "'"
        sqlcmd.Connection = sqlconn

        Dim search As SqlDataReader
        search = sqlcmd.ExecuteReader()

        If search.HasRows Then
            search.Read()
            StudentID.Clear()
            StudentName.Clear()

            StudentID.Text = search.Item("studentID")
            student_firstname = search.Item("firstname")
            student_lastname = search.Item("surname")
            StudentName.Text = student_firstname + " " + student_lastname

            If StudentID.Text = String.Empty = False Then

                StudentID.Text = search.Item("studentID")
                student_firstname = search.Item("firstname")
                student_lastname = search.Item("surname")
                StudentName.Text = student_firstname + " " + student_lastname

                If sqlconn.State = ConnectionState.Open Then
                    sqlconn.Close()
                    sqlconn.Open()

                    Call validate_log()
                    sqlconn.Close()
                Else
                    sqlconn.Open()
                    Call validate_log()
                    sqlconn.Close()
                End If

            Else
            End If

        Else
        End If

    End Sub
    Private Sub Call_Verify_Attendance()

        If Date_Attendance.Text = datenow.Text And IN_status.Text = "IN" And Out_status.Text = "" And Monitor_ID.Text = String.Empty = False Then

            If sqlconn.State = ConnectionState.Open Then
                sqlconn.Close()

                sqlconn.Open()
                Call updateTimeOut()
                sqlconn.Close()

            Else
                sqlconn.Open()
                Call updateTimeOut()
                sqlconn.Close()
            End If

        ElseIf Date_Attendance.Text = datenow.Text And IN_status.Text = "IN" And Out_status.Text = "OUT" Then
            If sqlconn.State = ConnectionState.Open Then
                sqlconn.Close()

                sqlconn.Open()
                Call saveTimeIn()
                sqlconn.Close()

            Else
                sqlconn.Open()
                Call saveTimeIn()
                sqlconn.Close()
            End If

        Else


        End If

    End Sub
    Private Sub validate_log()

        sqlcmd.CommandText = "select TOP 1 * FROM tb_InOut where Card_No = '" & Card_No.Text & "' ORDER BY MonitorID DESC"
        sqlcmd.Connection = sqlconn

        Dim search_attendance As SqlDataReader
        search_attendance = sqlcmd.ExecuteReader()

        If search_attendance.HasRows Then
            search_attendance.Read()

            IN_status.Text = search_attendance.Item("Time_In_Status")
            Out_status.Text = search_attendance.Item("Time_Out_Status")
            Date_Attendance.Text = search_attendance.Item("Date_Monitor")
            Monitor_ID.Text = search_attendance.Item("MonitorID")


            Call Call_Verify_Attendance()

            Card_No.Clear()


        Else
            Call callsaveTimeIn()

            Card_No.Clear()
        End If


    End Sub
    Private Sub Card_No_TextChanged(sender As Object, e As EventArgs) Handles Card_No.TextChanged

        If sqlconn.State = ConnectionState.Open Then
            sqlconn.Close()
            sqlconn.Open()

            Call Student_Record()
            sqlconn.Close()
        Else
            sqlconn.Open()
            Call Student_Record()
            sqlconn.Close()
        End If


    End Sub
    Private Sub saveTimeIn()
        Timeout.Clear()
        Dim sqlcmd As New SqlClient.SqlCommand

        Dim outStatus As String = ""

        strsql = " INSERT into tb_InOut ([Time_In],[Time_Out],[Card_No],[Student_Name],[studentID],[Date_Monitor],[Time_In_Status],[Time_Out_Status]) " &
        "values ('" & lbl_time.Text & "', '" & Timeout.Text & "','" & Card_No.Text & "','" & StudentName.Text & "', '" & StudentID.Text & "','" & datenow.Text & "', '" & "IN" & "', '" & outStatus & "') "

        sqlcmd.CommandText = strsql
        sqlcmd.Connection = sqlconn
        sqlcmd.ExecuteNonQuery()
        TimeIn.Text = lbl_time.Text

        sqlcmd.CommandText = "select * FROM studentdata where cardno = '" & Card_No.Text & "'"
        sqlcmd.Connection = sqlconn

        Dim UserData As SqlDataReader
        UserData = sqlcmd.ExecuteReader()
        If UserData.HasRows Then
            UserData.Read()
            If Not IsDBNull(UserData.Item("studpic")) Then
                Dim data As Byte() = DirectCast(UserData.Item("studpic"), Byte())
                Dim ms As New MemoryStream(data)
                PictureBox1.Image = Image.FromStream(ms)
            Else
                PictureBox1.Image = Nothing
            End If


            Dim fullnname As String
            Dim firstname As String
            Dim lname As String
            firstname = UserData.Item("firstname")
            lname = UserData.Item("surname")
            fullnname = firstname + " " + lname
            Try
                SMS.API.SendSingleMessage(UserData.Item("guardcontact"), "SRC ATTENDANCE ALERT!" & vbCrLf & "Your child" + " " + fullnname + " " + "has ARRIVED at the school premises safely. " & vbCrLf & " TIME IN: '" & lbl_time.Text & "'")

            Catch exception As Exception
                MessageBox.Show(exception.Message, "!Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            End Try
        End If

        UserData.Close()
        sqlconn.Close()

    End Sub

    Private Sub updateTimeOut()

        Dim sqlcmd As New SqlClient.SqlCommand
        Dim OutStatus As String = "OUT"

        strsql = "UPDATE tb_InOut SET Time_Out_Status = '" & OutStatus & "', Time_Out = '" & lbl_time.Text & "' WHERE MonitorID = '" & Monitor_ID.Text & "' AND studentID = '" & StudentID.Text & "' AND Date_Monitor = '" & datenow.Text & "'"
        sqlcmd.CommandText = strsql
        sqlcmd.Connection = sqlconn
        sqlcmd.ExecuteNonQuery()


        sqlcmd.CommandText = "select TOP 1 * FROM tb_InOut where Card_No = '" & Card_No.Text & "' ORDER BY MonitorID DESC"
        sqlcmd.Connection = sqlconn

        Dim search_attendance2 As SqlDataReader
        search_attendance2 = sqlcmd.ExecuteReader()
        If search_attendance2.HasRows Then
            search_attendance2.Read()
            TimeIn.Text = search_attendance2.Item("Time_In")
            Timeout.Text = lbl_time.Text
        End If
        search_attendance2.Close()

        sqlcmd.CommandText = "select * FROM studentdata where cardno = '" & Card_No.Text & "'"
        sqlcmd.Connection = sqlconn

        Dim UserData As SqlDataReader
        UserData = sqlcmd.ExecuteReader()
        If UserData.HasRows Then
            UserData.Read()

            If Not IsDBNull(UserData.Item("studpic")) Then
                Dim data As Byte() = DirectCast(UserData.Item("studpic"), Byte())
                Dim ms As New MemoryStream(data)
                PictureBox1.Image = Image.FromStream(ms)
            Else
                PictureBox1.Image = Nothing
            End If

            Dim fullnname As String
            Dim firstname As String
            Dim lname As String
            firstname = UserData.Item("firstname")
            lname = UserData.Item("surname")
            fullnname = firstname + " " + lname
            Try
                SMS.API.SendSingleMessage(UserData.Item("guardcontact"), "SRC ATTENDANCE ALERT!" & vbCrLf & "Your child" + " " + fullnname + " " + "has DEPARTED the school premises." & vbCrLf & "TIME OUT: '" & lbl_time.Text & "'")

            Catch exception As Exception
                MessageBox.Show(exception.Message, "!Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            End Try

        End If

        UserData.Close()
        sqlconn.Close()

    End Sub

    Private Sub callsaveTimeIn()
        If sqlconn.State = ConnectionState.Open Then
            sqlconn.Close()

            sqlconn.Open()
            Call saveTimeIn()
            sqlconn.Close()

        Else
            sqlconn.Open()
            Call saveTimeIn()
            sqlconn.Close()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        lbl_time.Text = TimeOfDay.ToString("T")

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        'StudentID.Text = ""
        'TimeIn.Text = ""
        'Timeout.Text = ""
        'StudentName.Text = ""
        'PictureBox1.Image = Nothing


    End Sub
End Class