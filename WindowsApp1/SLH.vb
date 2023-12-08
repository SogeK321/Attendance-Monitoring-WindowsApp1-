Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports ClosedXML.Excel
Imports ClosedXML.Excel.Drawings
Imports DocumentFormat.OpenXml.Wordprocessing
Imports Microsoft.Office.Interop


Public Class SLH

    Dim excelFile As Excel.Application


    Private Sub SLH_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sqlserver.connect()

        Call callloadpage()
        Call callloadlabel()

        SaveFileDialog1.Filter = "Excel Documents|*.xlsx"

    End Sub
    Private Sub loadpage()
        Call txtid()
        sqlcmd.CommandText = ("select (Date_Monitor) as Date, (Time_In) as Arrival, " &
        "(Time_Out) as Departure, (Time_In_Status) as 'Time In Status', " &
        "(Time_Out_Status)as 'Time Out Status' from tb_InOut where studentID = '" & TextBox1.Text & "'")
        sqlcmd.Connection = sqlconn

        Dim DS As New DataSet
        Dim sqlda As New SqlDataAdapter(sqlcmd)
        sqlda.Fill(DS, "tb_InOut")
        DataGridView1.DataSource = DS
        DataGridView1.DataMember = "tb_InOut"
    End Sub
    Private Sub callloadpage()
        If sqlconn.State = ConnectionState.Open Then
            sqlconn.Close()

            sqlconn.Open()

            Call loadpage()
            sqlconn.Close()

        Else
            sqlconn.Open()

            Call loadpage()
            sqlconn.Close()
        End If
    End Sub

    Private Sub callloadlabel()
        If sqlconn.State = ConnectionState.Open Then
            sqlconn.Close()

            sqlconn.Open()
            Call labelload()

            sqlconn.Close()

        Else
            sqlconn.Open()
            Call labelload()

            sqlconn.Close()
        End If
    End Sub
    Private Sub txtid()
        TextBox1.Text = StudentLists.TextBox2.Text
    End Sub
    Private Sub labelload()
        Call txtid()
        sqlcmd.CommandText = "select * FROM studentdata where studentID = '" & TextBox1.Text & "'"
        sqlcmd.Connection = sqlconn

        Dim search As SqlDataReader
        search = sqlcmd.ExecuteReader()

        If search.HasRows Then
            search.Read()
            lblid.Text = search.Item("studentID")
            lblgender.Text = search.Item("sex")
            Dim firstname As String = search.Item("firstname")
            Dim lname As String = search.Item("surname")
            Dim mname As String = search.Item("mname")
            lblname.Text = lname + ", " + firstname + " " + mname
            Dim address1 As String = search.Item("address")
            Dim address2 As String = search.Item("address1")
            Dim address3 As String = search.Item("address2")
            Dim address4 As String = search.Item("address3")
            lbladdress.Text = address1 + ", " + address2 + ", " + address3 + ", " + address4
            lbldep.Text = search.Item("lrn")
            lblcard.Text = search.Item("cardno").ToString
            lblemail.Text = search.Item("email")
            lblcontact.Text = search.Item("guardcontact")
        End If
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Me.Close()
    End Sub

    Public Function ExcelColName(ByVal Col As Integer) As String
        If Col < 0 And Col > 256 Then
            MsgBox("Invalid Argument", MsgBoxStyle.Critical)
            Return Nothing
            Exit Function
        End If
        Dim i As Int16
        Dim r As Int16
        Dim S As String
        If Col <= 26 Then
            S = Chr(Col + 64)
        Else
            r = Col Mod 26
            i = System.Math.Floor(Col / 26)
            If r = 0 Then
                r = 26
                i = i - 1
            End If
            S = Chr(i + 64) & Chr(r + 64)
        End If
        ExcelColName = S
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        excelFile = New Excel.Application
        Dim wb = excelFile.Workbooks.Add

        Try
            Dim row As Integer = 7
            With excelFile
                .Cells(1, 1) = "Student Name"
                .Cells(2, 1) = "Gender"
                .Cells(3, 1) = "Address"
                .Cells(4, 2) = lbldep.Text
                .Cells(1, 2) = lblname.Text
                .Cells(2, 2) = lblgender.Text
                .Cells(3, 2) = lbladdress.Text
                .Cells(4, 1) = "LRN"
                .Cells(1, 3) = "Student Id"
                .Cells(2, 3) = "Card Number"
                .Cells(3, 3) = "E-Mail"
                .Cells(4, 3) = "Guardian's Contact"
                .Cells(1, 4) = lblid.Text
                .Cells(2, 4) = lblcard.Text
                .Cells(3, 4) = lblemail.Text
                .Cells(4, 4) = lblcontact.Text
                .Cells(6, 1) = "Date"
                .Cells(6, 2) = "Arrival"
                .Cells(6, 3) = "Departure"
                .Cells(6, 4) = "Time in Status"
                .Cells(6, 5) = "Time out Status"
                For ctremp = 0 To DataGridView1.RowCount - 1
                    .Cells(row, 1) = DataGridView1.Rows(ctremp).Cells(0).Value
                    .Cells(row, 2) = DataGridView1.Rows(ctremp).Cells(1).Value
                    .Cells(row, 3) = DataGridView1.Rows(ctremp).Cells(2).Value
                    .Cells(row, 4) = DataGridView1.Rows(ctremp).Cells(3).Value
                    .Cells(row, 5) = DataGridView1.Rows(ctremp).Cells(4).Value
                    row = row + 1
                Next
            End With

            If SaveFileDialog1.ShowDialog = DialogResult.OK Then
                wb.SaveAs2(SaveFileDialog1.FileName)
                MessageBox.Show("Saved")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            wb.Saved() = True
            excelFile.Quit()
            wb = Nothing
            excelFile = Nothing


        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call callprint()
    End Sub

    Private Sub callprint()
        If sqlconn.State = ConnectionState.Open Then
            sqlconn.Close()
            sqlconn.Open()

            Call print_registration()

            sqlconn.Close()
        Else
            sqlconn.Open()
            Call print_registration()
            sqlconn.Close()
        End If
    End Sub

    Private Sub print_registration()

        Dim sqlQRY1 As String = "select * FROM tb_InOut where studentID = '" & TextBox1.Text & "'"
        Dim sqlQRY3 As String = "select * FROM studentdata where studentID = '" & TextBox1.Text & "'"



        Dim cmdExec1 As SqlCommand = New SqlCommand(sqlQRY1, sqlconn)
        Dim cmdexec3 As SqlCommand = New SqlCommand(sqlQRY3, sqlconn)


        'create data adapter

        Dim da1 As SqlDataAdapter = New SqlDataAdapter(sqlQRY1, sqlconn)
        Dim da3 As SqlDataAdapter = New SqlDataAdapter(sqlQRY3, sqlconn)

        'create dataset
        Dim ds As DataSet = New DataSet

        'fill dataset
        da1.Fill(ds, "tb_InOut")
        da3.Fill(ds, "studentdata")

        'Dim Report As PrintReportt = New PrintReportt

        Dim mReport As CrystalReport1 = New CrystalReport1
        PrintReportt.CrystalReportViewer1.ReportSource = Nothing
        'mReport.SetDataSource(ds)
        mReport.Database.Tables("studentdata").SetDataSource(ds)
        mReport.Database.Tables("tb_InOut").SetDataSource(ds)

        'PrintReportt.CrystalReportViewer1.ReportSource = Nothing
        PrintReportt.CrystalReportViewer1.ReportSource = mReport

        PrintReportt.Show()
        'Dim pname As String = "prnName"
        'Dim pprname As String = "paperName"

        'Dim i As Integer
        'Dim doctoprint As New System.Drawing.Printing.PrintDocument()
        'doctoprint.PrinterSettings.PrinterName = pname
        'Dim rawKind As Integer
        'For i = 0 To doctoprint.PrinterSettings.PaperSizes.Count - 1
        '    If doctoprint.PrinterSettings.PaperSizes(i).PaperName = pprname Then
        '        rawKind = CInt(doctoprint.PrinterSettings.PaperSizes(i).GetType().GetField("kind", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic).GetValue(doctoprint.PrinterSettings.PaperSizes(i)))
        '        Exit For
        '    End If
        'Next
        'mReport.PrintOptions.PaperSize = CType(rawKind, CrystalDecisions.Shared.PaperSize) '
        'Report.CrystalReportViewer1.ReportSource = mReport
        'mReport.PrintToPrinter(1, False, 0, 0)


        'Report.CrystalReportViewer1.ReportSource = mReport

        'Report.ShowDialog()
    End Sub
End Class