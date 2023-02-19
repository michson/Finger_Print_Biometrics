

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.lblmessage = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.bttExit = New System.Windows.Forms.Button
        Me.txtsurname = New System.Windows.Forms.TextBox
        Me.txtfirst = New System.Windows.Forms.TextBox
        Me.txtnumber = New System.Windows.Forms.TextBox
        Me.txtemail = New System.Windows.Forms.TextBox
        Me.bttRegister = New System.Windows.Forms.Button
        Me.bttLoad = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.AxGrFingerXCtrl1 = New AxGrFingerXLib.AxGrFingerXCtrl
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtstatus = New System.Windows.Forms.ComboBox
        Me.txtsex = New System.Windows.Forms.ComboBox
        Me.txtaddress = New System.Windows.Forms.TextBox
        Me.txtorigin = New System.Windows.Forms.TextBox
        Me.txtqualification = New System.Windows.Forms.TextBox
        Me.txtinstitution = New System.Windows.Forms.TextBox
        Me.txtmiddle = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblpicture = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.chkyes = New System.Windows.Forms.CheckBox
        Me.chkno = New System.Windows.Forms.CheckBox
        CType(Me.AxGrFingerXCtrl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblmessage
        '
        Me.lblmessage.AutoSize = True
        Me.lblmessage.BackColor = System.Drawing.Color.Transparent
        Me.lblmessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmessage.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblmessage.Location = New System.Drawing.Point(156, 15)
        Me.lblmessage.Name = "lblmessage"
        Me.lblmessage.Size = New System.Drawing.Size(415, 20)
        Me.lblmessage.TabIndex = 1
        Me.lblmessage.Text = "Please, place your  thumb on the fingerprint reader"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "SURNAME"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "LAST NAME"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "PHONENUMBER"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 129)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "EMAIL ADDRESS"
        '
        'bttExit
        '
        Me.bttExit.BackColor = System.Drawing.Color.Silver
        Me.bttExit.Location = New System.Drawing.Point(532, 406)
        Me.bttExit.Name = "bttExit"
        Me.bttExit.Size = New System.Drawing.Size(141, 45)
        Me.bttExit.TabIndex = 6
        Me.bttExit.Text = "&EXIT PROJECT"
        Me.bttExit.UseVisualStyleBackColor = False
        '
        'txtsurname
        '
        Me.txtsurname.Location = New System.Drawing.Point(182, 19)
        Me.txtsurname.Name = "txtsurname"
        Me.txtsurname.Size = New System.Drawing.Size(153, 20)
        Me.txtsurname.TabIndex = 7
        '
        'txtfirst
        '
        Me.txtfirst.Location = New System.Drawing.Point(181, 47)
        Me.txtfirst.Name = "txtfirst"
        Me.txtfirst.Size = New System.Drawing.Size(153, 20)
        Me.txtfirst.TabIndex = 8
        '
        'txtnumber
        '
        Me.txtnumber.Location = New System.Drawing.Point(181, 103)
        Me.txtnumber.Name = "txtnumber"
        Me.txtnumber.Size = New System.Drawing.Size(153, 20)
        Me.txtnumber.TabIndex = 10
        '
        'txtemail
        '
        Me.txtemail.Location = New System.Drawing.Point(181, 130)
        Me.txtemail.Name = "txtemail"
        Me.txtemail.Size = New System.Drawing.Size(153, 20)
        Me.txtemail.TabIndex = 11
        '
        'bttRegister
        '
        Me.bttRegister.BackColor = System.Drawing.Color.Silver
        Me.bttRegister.Location = New System.Drawing.Point(377, 406)
        Me.bttRegister.Name = "bttRegister"
        Me.bttRegister.Size = New System.Drawing.Size(145, 45)
        Me.bttRegister.TabIndex = 19
        Me.bttRegister.Text = "&REGISTER"
        Me.bttRegister.UseVisualStyleBackColor = False
        '
        'bttLoad
        '
        Me.bttLoad.BackColor = System.Drawing.Color.Silver
        Me.bttLoad.Location = New System.Drawing.Point(208, 201)
        Me.bttLoad.Name = "bttLoad"
        Me.bttLoad.Size = New System.Drawing.Size(111, 34)
        Me.bttLoad.TabIndex = 18
        Me.bttLoad.Text = "&Load Pic"
        Me.bttLoad.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label5.Location = New System.Drawing.Point(198, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(128, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "ARE YOU THE ONE?"
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(44, 241)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(237, 212)
        Me.ListBox1.TabIndex = 15
        '
        'Timer1
        '
        Me.Timer1.Interval = 10000
        '
        'AxGrFingerXCtrl1
        '
        Me.AxGrFingerXCtrl1.Enabled = True
        Me.AxGrFingerXCtrl1.Location = New System.Drawing.Point(21, 8)
        Me.AxGrFingerXCtrl1.Name = "AxGrFingerXCtrl1"
        Me.AxGrFingerXCtrl1.OcxState = CType(resources.GetObject("AxGrFingerXCtrl1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxGrFingerXCtrl1.Size = New System.Drawing.Size(32, 32)
        Me.AxGrFingerXCtrl1.TabIndex = 16
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label6.Location = New System.Drawing.Point(35, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = " Your Scan finger"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtstatus)
        Me.GroupBox1.Controls.Add(Me.txtsex)
        Me.GroupBox1.Controls.Add(Me.txtaddress)
        Me.GroupBox1.Controls.Add(Me.txtorigin)
        Me.GroupBox1.Controls.Add(Me.txtqualification)
        Me.GroupBox1.Controls.Add(Me.txtinstitution)
        Me.GroupBox1.Controls.Add(Me.txtmiddle)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtsurname)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtfirst)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtnumber)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtemail)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GroupBox1.Location = New System.Drawing.Point(340, 46)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(344, 325)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "PERSONAL DATA"
        '
        'txtstatus
        '
        Me.txtstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtstatus.FormattingEnabled = True
        Me.txtstatus.Location = New System.Drawing.Point(180, 185)
        Me.txtstatus.Name = "txtstatus"
        Me.txtstatus.Size = New System.Drawing.Size(154, 21)
        Me.txtstatus.TabIndex = 19
        '
        'txtsex
        '
        Me.txtsex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtsex.FormattingEnabled = True
        Me.txtsex.Location = New System.Drawing.Point(181, 157)
        Me.txtsex.Name = "txtsex"
        Me.txtsex.Size = New System.Drawing.Size(153, 21)
        Me.txtsex.TabIndex = 18
        '
        'txtaddress
        '
        Me.txtaddress.Location = New System.Drawing.Point(180, 295)
        Me.txtaddress.Name = "txtaddress"
        Me.txtaddress.Size = New System.Drawing.Size(153, 20)
        Me.txtaddress.TabIndex = 17
        '
        'txtorigin
        '
        Me.txtorigin.Location = New System.Drawing.Point(180, 268)
        Me.txtorigin.Name = "txtorigin"
        Me.txtorigin.Size = New System.Drawing.Size(153, 20)
        Me.txtorigin.TabIndex = 16
        '
        'txtqualification
        '
        Me.txtqualification.Location = New System.Drawing.Point(180, 242)
        Me.txtqualification.Name = "txtqualification"
        Me.txtqualification.Size = New System.Drawing.Size(153, 20)
        Me.txtqualification.TabIndex = 15
        '
        'txtinstitution
        '
        Me.txtinstitution.Location = New System.Drawing.Point(180, 213)
        Me.txtinstitution.Name = "txtinstitution"
        Me.txtinstitution.Size = New System.Drawing.Size(153, 20)
        Me.txtinstitution.TabIndex = 14
        '
        'txtmiddle
        '
        Me.txtmiddle.Location = New System.Drawing.Point(181, 75)
        Me.txtmiddle.Name = "txtmiddle"
        Me.txtmiddle.Size = New System.Drawing.Size(153, 20)
        Me.txtmiddle.TabIndex = 9
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(21, 185)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(114, 13)
        Me.Label13.TabIndex = 17
        Me.Label13.Text = "MARITAL STATUS"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(21, 157)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(31, 13)
        Me.Label12.TabIndex = 16
        Me.Label12.Text = "SEX"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(21, 213)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(87, 13)
        Me.Label11.TabIndex = 15
        Me.Label11.Text = "OCCUPATION"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(20, 297)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(152, 13)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "RESIDENTIAL ADDRESS"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(20, 268)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(115, 13)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "STATE OF ORIGIN"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(21, 242)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(101, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "QUALIFICATION"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(21, 47)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "FIRSTNAME"
        '
        'lblpicture
        '
        Me.lblpicture.AutoSize = True
        Me.lblpicture.Location = New System.Drawing.Point(35, 269)
        Me.lblpicture.Name = "lblpicture"
        Me.lblpicture.Size = New System.Drawing.Size(0, 13)
        Me.lblpicture.TabIndex = 20
        Me.lblpicture.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox2.Location = New System.Drawing.Point(190, 69)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(144, 126)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 11
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = Global.myproject.My.Resources.Resources.fingerprintreader
        Me.PictureBox1.Location = New System.Drawing.Point(38, 69)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(143, 149)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'chkyes
        '
        Me.chkyes.AutoSize = True
        Me.chkyes.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.chkyes.Location = New System.Drawing.Point(584, 23)
        Me.chkyes.Name = "chkyes"
        Me.chkyes.Size = New System.Drawing.Size(50, 17)
        Me.chkyes.TabIndex = 21
        Me.chkyes.Text = "YES"
        Me.chkyes.UseVisualStyleBackColor = True
        '
        'chkno
        '
        Me.chkno.AutoSize = True
        Me.chkno.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.chkno.Location = New System.Drawing.Point(631, 23)
        Me.chkno.Name = "chkno"
        Me.chkno.Size = New System.Drawing.Size(44, 17)
        Me.chkno.TabIndex = 22
        Me.chkno.Text = "NO"
        Me.chkno.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(704, 476)
        Me.Controls.Add(Me.chkno)
        Me.Controls.Add(Me.chkyes)
        Me.Controls.Add(Me.lblpicture)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.bttLoad)
        Me.Controls.Add(Me.bttRegister)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.bttExit)
        Me.Controls.Add(Me.lblmessage)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.AxGrFingerXCtrl1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BIOMETRICS      (FINGERPRINT TECHNIQUE)"
        CType(Me.AxGrFingerXCtrl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblmessage As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents bttExit As System.Windows.Forms.Button
    Friend WithEvents txtsurname As System.Windows.Forms.TextBox
    Friend WithEvents txtfirst As System.Windows.Forms.TextBox
    Friend WithEvents txtnumber As System.Windows.Forms.TextBox
    Friend WithEvents txtemail As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents bttRegister As System.Windows.Forms.Button
    Friend WithEvents bttLoad As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents AxGrFingerXCtrl1 As AxGrFingerXLib.AxGrFingerXCtrl
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtmiddle As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtqualification As System.Windows.Forms.TextBox
    Friend WithEvents txtinstitution As System.Windows.Forms.TextBox
    Friend WithEvents txtaddress As System.Windows.Forms.TextBox
    Friend WithEvents txtorigin As System.Windows.Forms.TextBox
    Friend WithEvents lblpicture As System.Windows.Forms.Label
    Friend WithEvents chkyes As System.Windows.Forms.CheckBox
    Friend WithEvents chkno As System.Windows.Forms.CheckBox
    Friend WithEvents txtsex As System.Windows.Forms.ComboBox
    Friend WithEvents txtstatus As System.Windows.Forms.ComboBox

End Class
