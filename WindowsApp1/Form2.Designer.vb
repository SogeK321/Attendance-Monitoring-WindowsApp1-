<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Card_No = New System.Windows.Forms.TextBox()
        Me.StudentID = New System.Windows.Forms.TextBox()
        Me.TimeIn = New System.Windows.Forms.TextBox()
        Me.Timeout = New System.Windows.Forms.TextBox()
        Me.StudentName = New System.Windows.Forms.TextBox()
        Me.datenow = New System.Windows.Forms.Label()
        Me.lbl_time = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.IN_status = New System.Windows.Forms.TextBox()
        Me.Out_status = New System.Windows.Forms.TextBox()
        Me.Monitor_ID = New System.Windows.Forms.TextBox()
        Me.Date_Attendance = New System.Windows.Forms.TextBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Imprint MT Shadow", 55.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(289, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1301, 108)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Attendance Monitoring System"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(251, 303)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(173, 69)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Date:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(256, 449)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(181, 69)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Time:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(96, 597)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(329, 69)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Student ID:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(212, 720)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(218, 69)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Arrival:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(113, 833)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(312, 69)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Departure:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(1254, 929)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(411, 69)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Student Name"
        '
        'Card_No
        '
        Me.Card_No.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Card_No.Location = New System.Drawing.Point(370, 106)
        Me.Card_No.Name = "Card_No"
        Me.Card_No.Size = New System.Drawing.Size(497, 75)
        Me.Card_No.TabIndex = 7
        '
        'StudentID
        '
        Me.StudentID.Enabled = False
        Me.StudentID.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StudentID.Location = New System.Drawing.Point(430, 594)
        Me.StudentID.Name = "StudentID"
        Me.StudentID.Size = New System.Drawing.Size(497, 75)
        Me.StudentID.TabIndex = 8
        '
        'TimeIn
        '
        Me.TimeIn.Enabled = False
        Me.TimeIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TimeIn.Location = New System.Drawing.Point(430, 714)
        Me.TimeIn.Name = "TimeIn"
        Me.TimeIn.Size = New System.Drawing.Size(497, 75)
        Me.TimeIn.TabIndex = 9
        '
        'Timeout
        '
        Me.Timeout.Enabled = False
        Me.Timeout.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Timeout.Location = New System.Drawing.Point(430, 833)
        Me.Timeout.Name = "Timeout"
        Me.Timeout.Size = New System.Drawing.Size(497, 75)
        Me.Timeout.TabIndex = 10
        '
        'StudentName
        '
        Me.StudentName.Enabled = False
        Me.StudentName.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StudentName.Location = New System.Drawing.Point(1160, 851)
        Me.StudentName.Name = "StudentName"
        Me.StudentName.Size = New System.Drawing.Size(612, 75)
        Me.StudentName.TabIndex = 11
        '
        'datenow
        '
        Me.datenow.AutoSize = True
        Me.datenow.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.datenow.Location = New System.Drawing.Point(430, 285)
        Me.datenow.Name = "datenow"
        Me.datenow.Size = New System.Drawing.Size(347, 91)
        Me.datenow.TabIndex = 12
        Me.datenow.Text = "00:00:00"
        '
        'lbl_time
        '
        Me.lbl_time.AutoSize = True
        Me.lbl_time.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_time.Location = New System.Drawing.Point(425, 431)
        Me.lbl_time.Name = "lbl_time"
        Me.lbl_time.Size = New System.Drawing.Size(347, 91)
        Me.lbl_time.TabIndex = 13
        Me.lbl_time.Text = "00:00:00"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.ControlDark
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(1160, 328)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(612, 497)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 14
        Me.PictureBox1.TabStop = False
        '
        'Timer1
        '
        '
        'Timer2
        '
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(30, 12)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(269, 242)
        Me.PictureBox2.TabIndex = 15
        Me.PictureBox2.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(1697, 12)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(275, 242)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 16
        Me.PictureBox3.TabStop = False
        '
        'IN_status
        '
        Me.IN_status.Enabled = False
        Me.IN_status.Location = New System.Drawing.Point(514, 615)
        Me.IN_status.Name = "IN_status"
        Me.IN_status.Size = New System.Drawing.Size(100, 22)
        Me.IN_status.TabIndex = 17
        '
        'Out_status
        '
        Me.Out_status.Enabled = False
        Me.Out_status.Location = New System.Drawing.Point(710, 615)
        Me.Out_status.Name = "Out_status"
        Me.Out_status.Size = New System.Drawing.Size(100, 22)
        Me.Out_status.TabIndex = 18
        '
        'Monitor_ID
        '
        Me.Monitor_ID.Enabled = False
        Me.Monitor_ID.Location = New System.Drawing.Point(514, 862)
        Me.Monitor_ID.Name = "Monitor_ID"
        Me.Monitor_ID.Size = New System.Drawing.Size(100, 22)
        Me.Monitor_ID.TabIndex = 19
        '
        'Date_Attendance
        '
        Me.Date_Attendance.Enabled = False
        Me.Date_Attendance.Location = New System.Drawing.Point(710, 862)
        Me.Date_Attendance.Name = "Date_Attendance"
        Me.Date_Attendance.Size = New System.Drawing.Size(100, 22)
        Me.Date_Attendance.TabIndex = 20
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.ClientSize = New System.Drawing.Size(1924, 1004)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lbl_time)
        Me.Controls.Add(Me.datenow)
        Me.Controls.Add(Me.StudentName)
        Me.Controls.Add(Me.Timeout)
        Me.Controls.Add(Me.TimeIn)
        Me.Controls.Add(Me.StudentID)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Date_Attendance)
        Me.Controls.Add(Me.Monitor_ID)
        Me.Controls.Add(Me.Out_status)
        Me.Controls.Add(Me.IN_status)
        Me.Controls.Add(Me.Card_No)
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form2"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Card_No As TextBox
    Friend WithEvents StudentID As TextBox
    Friend WithEvents TimeIn As TextBox
    Friend WithEvents Timeout As TextBox
    Friend WithEvents StudentName As TextBox
    Friend WithEvents datenow As Label
    Friend WithEvents lbl_time As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Timer2 As Timer
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents IN_status As TextBox
    Friend WithEvents Out_status As TextBox
    Friend WithEvents Monitor_ID As TextBox
    Friend WithEvents Date_Attendance As TextBox
End Class
