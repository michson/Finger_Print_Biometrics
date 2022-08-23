
Imports GrFingerXLib

Public Class Form1
    '---Database name---------------------------------------------------
    Const DBFile = "GrFingerSample.mdb"
    Const Logfile = "C:\Log.csv"
    Const ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="

    '--- this is for Util.vb class that define the management of fingerprint -------------
    Private myUtil As Util
    '---this declaration is for storing user’s ID----------
    Private _UserID As Integer
    '---this is database connection string---
    Private connection As System.Data.OleDb.OleDbConnection

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' --- initialize error -----
        Dim err As Integer
        '--- to initialize util class -----
        myUtil = New util(ListBox1, PictureBox1, AxGrFingerXCtrl1)
        ' ----- to Initialize GrFingerX Library ----
        err = myUtil.InitializeGrFinger()
        ' ---- to Print the result in log ------
        If err < 0 Then
            myUtil.WriteError(err)
            Exit Sub
        Else
            myUtil.WriteLog( _
               "**GrFingerX Initialized Successfull**")
        End If

        '--- to create a log file  ---
        If Not System.IO.File.Exists(Logfile) Then
            System.IO.File.Create(Logfile)
        End If
        bttRegister.Enabled = False
        bttLoad.Enabled = False
        GetControlDisable()
        chkyes.Visible = False
        chkno.Visible = False
        With txtstatus
            .Items.Add("Single")
            .Items.Add("Searching")
            .Items.Add("Married")
            .Items.Add("Divorced")
        End With
        With txtsex
            .Items.Add("MALE")
            .Items.Add("FEMALE")
        End With
    End Sub
    ' -----------------------------------------------------------------------------------
    '                                           GrFingerX events
    ' -----------------------------------------------------------------------------------
    ' ------ When fingerprint reader was plugged on system ----
    Private Sub AxGrFingerXCtrl1_SensorPlug( _
       ByVal sender As System.Object, _
       ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_SensorPlugEvent) _
       Handles AxGrFingerXCtrl1.SensorPlug
        myUtil.WriteLog("Sensor: " & e.idSensor & ". Event: Plugged.")
        AxGrFingerXCtrl1.CapStartCapture(e.idSensor)
    End Sub

    ' ---- When remove fingerprint reader from system ----
    Private Sub AxGrFingerXCtrl1_SensorUnplug( _
       ByVal sender As System.Object, _
       ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_SensorUnplugEvent) _
       Handles AxGrFingerXCtrl1.SensorUnplug
        myUtil.WriteLog("Sensor: " & e.idSensor & ". Event: Unplugged.")
        AxGrFingerXCtrl1.CapStopCapture(e.idSensor)
    End Sub

    ' ---- When finger was placed on fingerreader-----
    Private Sub AxGrFingerXCtrl1_FingerDown( _
       ByVal sender As System.Object, _
       ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_FingerDownEvent) _
       Handles AxGrFingerXCtrl1.FingerDown
        myUtil.WriteLog("Sensor: " & e.idSensor & ". Event: Finger Placed.")
    End Sub

    ' ---- When finger was removed from fingerreader-----
    Private Sub AxGrFingerXCtrl1_FingerUp( _
       ByVal sender As System.Object, _
       ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_FingerUpEvent) _
       Handles AxGrFingerXCtrl1.FingerUp
        myUtil.WriteLog("Sensor: " & e.idSensor & ". Event: Finger removed.")
    End Sub
    ' ---When an image was acquired from fingerreader----
    Private Sub AxGrFingerXCtrl1_ImageAcquired( _
       ByVal sender As System.Object, _
       ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_ImageAcquiredEvent) _
       Handles AxGrFingerXCtrl1.ImageAcquired

        '--- To Copying aquired image----
        myUtil.raw.height = e.height
        myUtil.raw.width = e.width
        myUtil.raw.res = e.res
        myUtil.raw.img = e.rawImage

        ' -----To Signal that an Image Event occurred -----
        myUtil.WriteLog("Sensor: " & e.idSensor & ". Event: Image captured.")

        ' -----TO display fingerprint image----
        ' myUtil.PrintBiometricDisplay(False, GRConstants.GR_DEFAULT_CONTEXT)

        '---To extract the template from the fingerprint scanned---
        ExtractTemplate()

        '---To identify whom the user is---
        _UserID = IdentifyFingerprint()
        If _UserID > 0 Then
            '---If user found---
            Beep()
            bttRegister.Enabled = False
            bttLoad.Enabled = False
            GetControlDisable()
            chkyes.Visible = False
            chkyes.Checked = False
            chkno.Visible = False
            '---display user's information---
            GetUserInfo()
            '---writes to log file---
            WriteToLog(_UserID)
        Else
            '---user not found---
            ClearDisplay()
            chkyes.Visible = True
            chkno.Visible = True
            Beep()
            lblmessage.Text = "User not found! Do you want to register?"
        End If
    End Sub
    ' Extract a template from a fingerprint image
    Private Function ExtractTemplate() As Integer
        Dim ret As Integer
        ' extract template
        ret = myUtil.ExtractTemplate()
        ' write template quality to log
        If ret = GRConstants.GR_BAD_QUALITY Then
            myUtil.WriteLog("Template extracted successfully. Bad quality.")

        ElseIf ret = GRConstants.GR_MEDIUM_QUALITY Then
            myUtil.WriteLog("Template extracted successfully. Medium quality.")

        ElseIf ret = GRConstants.GR_HIGH_QUALITY Then
            myUtil.WriteLog("Template extracted successfully. High quality.")
        End If
        If ret >= 0 Then
            ' if no error, display minutiae/segments/directions into the image
            myUtil.PrintBiometricDisplay(True, GRConstants.GR_NO_CONTEXT)
        Else
            ' write error to log
            myUtil.WriteError(ret)
        End If
        Return ret
    End Function
    '  Public img As String
    Private Function IdentifyFingerprint() As Integer
        '---Identify a fingerprint; returns the ID of the user---
        Dim ret As Integer, score As Integer
        score = 0
        ' identify it
        ret = myUtil.Identify(score)
        ' write result to log
        If ret > 0 Then
            myUtil.WriteLog("Fingerprint identified. ID = " & ret & ". Score = " & score & ".")
            'myUtil.PrintBiometricDisplay(True, GRConstants.GR_DEFAULT_CONTEXT)
            'NOTE THIS AREA WHEN RUN THE PROGRAM
        ElseIf ret = 0 Then
            myUtil.WriteLog("Fingerprint not Found.")
        Else
            myUtil.WriteError(ret)
        End If
        Return ret
    End Function
    '---get user's information---
    Public Sub GetUserInfo()
        Dim filePath As String
        Try
            ' filePath = "C:\Documents and Settings\GBENGA\Desktop\myproject\myproject" & "\" & DBFile
            ' filePath = "C:\Documents and Settings\GBENGA\Desktop\myproject2\myproject" & "\" & DBFile
            'filePath = "C:\Users\ABIKOYEM\Desktop\myproject2\myproject" & "\" & DBFile
            filePath = Application.StartupPath() & "\" & DBFile
            'filePath = Application.StartupPath() & "\" & DBFile
            connection = New OleDb.OleDbConnection(ConnectionString & filePath)
            connection.Open()
            Dim reader As OleDb.OleDbDataReader
            Dim command As OleDb.OleDbCommand = New OleDb.OleDbCommand
            command.Connection = connection
            '---retrieve user's particulars---
            command.CommandText = "SELECT * FROM Students_Info WHERE ID=" & _UserID
            reader = command.ExecuteReader(CommandBehavior.CloseConnection)
            reader.Read()
            '---display user's particulars---
            lblmessage.Text = "You are Welcome, " & reader("surname")
            txtsurname.Text = reader("surname")
            txtfirst.Text = reader("firstname")
            txtmiddle.Text = reader("middlename")
            txtnumber.Text = reader("phonenum")
            txtemail.Text = reader("email")
            txtsex.Text = reader("sex")
            txtstatus.Text = reader("Marritalstatus")
            txtinstitution.Text = reader("institution")
            txtqualification.Text = reader("qualification")
            txtorigin.Text = reader("state")
            txtaddress.Text = reader("address")
            Me.lblpicture.Text = reader("picture")
            '---reset the timer to another 5 seconds---
            Timer1.Enabled = False
            Timer1.Enabled = True
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            connection.Close()
        End Try
    End Sub
    '---- For Register Button ----
    Private Sub bttRegister_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttRegister.Click
        '---first add the fingerprint---
        _UserID = EnrollFingerprint()
        '---then add the particulars---
        If txtsurname.Text = "" Then
            MsgBox("Enter your surname!")
            txtsurname.BackColor = Color.Aqua
            Exit Sub
        End If
        If txtfirst.Text = "" Then
            MsgBox("Enter your first name!")
            txtfirst.BackColor = Color.Aqua
            Exit Sub
        End If
        If txtmiddle.Text = "" Then
            MsgBox("Enter your middle name!")
            txtmiddle.BackColor = Color.Aqua
            Exit Sub
        End If

        AddNewUser()
        chkyes.Visible = False
        chkyes.Checked = False
        chkno.Checked = False
        chkno.Visible = False
        PictureBox1.Image = Nothing

        '---clears the display---
        ClearDisplay()
        '---writes to log file---
        WriteToLog(_UserID)
    End Sub
    '---adds a fingerprint to the database; returns the ID of the user---
    Private Function EnrollFingerprint() As Integer
        Dim id As Integer
        ' add fingerprint
        id = myUtil.Enroll()
        ' write result to log
        If id >= 0 Then
            myUtil.WriteLog("Fingerprint enrolled with id = " & id)
        Else
            myUtil.WriteLog("Error: Fingerprint not enrolled")
        End If
        Return id
    End Function

    '---Add a new user's information to the database---
    Public Sub AddNewUser()
        Dim filePath As String
        Try
            'filePath = "C:\Documents and Settings\GBENGA\Desktop\myproject\myproject" & "\" & DBFile
            filePath = Application.StartupPath() & "\" & DBFile
            'filePath = "C:\Documents and Settings\GBENGA\Desktop\myproject2\myproject" & "\" & DBFile
            'filePath = "C:\Users\ABIKOYEM\Desktop\myproject2\myproject" & "\" & DBFile
            connection = New OleDb.OleDbConnection(ConnectionString & filePath)
            connection.Open()
            ' Dim command As OleDb.OleDbCommand = New OleDb.OleDbCommand
            '---set the user's particulars in the table---
            Dim sql As String = "UPDATE enroll SET surname='" & txtsurname.Text & "', " & _
               " firstname='" & txtfirst.Text & "', " & _
               " middlename='" & txtmiddle.Text & "', " & _
               " phonenum=" & txtnumber.Text & ", " & _
               " email='" & txtemail.Text & "', " & _
               " sex='" & txtsex.Text & "', " & _
               " Marritalstatus='" & txtstatus.Text & "', " & _
               " institution='" & txtinstitution.Text & "', " & _
               " qualification='" & txtqualification.Text & "', " & _
               " state='" & txtorigin.Text & "', " & _
               " picture='" & Me.lblpicture.Text & "'," & _
               " address='" & txtaddress.Text & "' " & _
               " WHERE ID=" & _UserID
            Dim command As OleDb.OleDbCommand = New OleDb.OleDbCommand(sql, connection)
            'command.CommandText = sql
            command.ExecuteNonQuery()
            MsgBox("User added successfully!")
            connection.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    '---Clears the user's particulars---
    Public Sub ClearDisplay()
        lblmessage.Text = _
           "Please place your index finger on the fingerprint reader"
        'PictureBox1.Image = My.Resources.fingerprintreader
        txtsurname.Text = String.Empty
        txtfirst.Text = String.Empty
        txtnumber.Text = String.Empty
        txtemail.Text = String.Empty
        txtmiddle.Text = String.Empty
        txtsex.Text = String.Empty
        txtstatus.Text = String.Empty
        txtinstitution.Text = String.Empty
        txtqualification.Text = String.Empty
        txtorigin.Text = String.Empty
        txtaddress.Text = String.Empty
        Me.PictureBox2.Image = Nothing
        Me.lblpicture.Text = String.Empty

    End Sub

    '---the Timer control---
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ClearDisplay()
        Me.PictureBox1.Image = Nothing
        GetControlEnable()
        Timer1.Enabled = False
        chkyes.Visible = False
        chkno.Visible = False
    End Sub

    Public Sub WriteToLog(ByVal ID As String)
        '---write to a log file---
        Dim sw As New System.IO.StreamWriter( _
           Logfile, True, System.Text.Encoding.ASCII)
        sw.WriteLine(ID & "," & Now.ToString)
        sw.Close()
    End Sub

    Private Sub bttExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttExit.Click
        End
    End Sub

    Private Sub bttLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttLoad.Click
        OpenFileDialog1.Filter = "Images|*.GIF;*.JPG;*.TIF;*.JPEG;*.BMP"
        Me.OpenFileDialog1.ShowDialog()
        If OpenFileDialog1.FileName = "" Then
            Exit Sub
        Else
            Me.lblpicture.Text = Me.OpenFileDialog1.FileName

        End If
    End Sub

    Private Sub txtsurname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsurname.KeyPress
        If System.Char.IsLetter(e.KeyChar) Then Exit Sub
        If System.Char.IsControl(e.KeyChar) Then
            Exit Sub
        Else
            Beep()
            MsgBox("INVALID DATA", MsgBoxStyle.Information)
            MsgBox("TYPE IN VALID STRING", MsgBoxStyle.Information)
            txtsurname.Text = ""
        End If
        e.Handled = True
    End Sub

    Private Sub txtfirst_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfirst.KeyPress
        If System.Char.IsControl(e.KeyChar) Then Exit Sub
        If System.Char.IsLetter(e.KeyChar) Then
            Exit Sub
        Else
            Beep()
            MsgBox("INVALID DATA", MsgBoxStyle.Information)
            MsgBox("TYPE IN VALID STRING", MsgBoxStyle.Information)
            txtfirst.Text = ""
        End If
        e.Handled = True
    End Sub


    Private Sub txtmiddle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmiddle.KeyPress
        If System.Char.IsLetter(e.KeyChar) Then Exit Sub
        If System.Char.IsControl(e.KeyChar) Then
            Exit Sub
        Else
            Beep()
            MsgBox("INVALID DATA", MsgBoxStyle.Information)
            MsgBox("TYPE IN VALID STRING", MsgBoxStyle.Information)
            txtmiddle.Text = ""
        End If
        e.Handled = True
    End Sub

    Private Sub txtnumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnumber.KeyPress
        If System.Char.IsNumber(e.KeyChar) Then Exit Sub
        If System.Char.IsControl(e.KeyChar) Then
            Exit Sub
        Else
            Beep()
            MsgBox("INVALID DATA", MsgBoxStyle.Information)
            MsgBox("TYPE IN VALID NUMBER", MsgBoxStyle.Information)
        End If
        e.Handled = True
    End Sub

    Private Sub txtaddress_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtaddress.KeyPress
        ' If System.Char.IsControl(e.KeyChar) Then Exit Sub
        'If System.Char.IsLetterOrDigit(e.KeyChar) Then
        'Exit Sub
        'Else
        'Beep()
        'End If
        'e.Handled = True
    End Sub
    Private Sub lblpicture_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblpicture.TextChanged
        If lblpicture.Text = "" Then
            Me.PictureBox2.Image = My.Resources.fingerprintreader
            Exit Sub
        End If
        Me.PictureBox2.Image = Image.FromFile(Me.lblpicture.Text)

    End Sub
    Public Sub GetControlEnable()
        Me.txtaddress.Enabled = True
        Me.txtemail.Enabled = True
        Me.txtfirst.Enabled = True
        Me.txtinstitution.Enabled = True
        Me.txtmiddle.Enabled = True
        Me.txtnumber.Enabled = True
        Me.txtorigin.Enabled = True
        Me.txtqualification.Enabled = True
        Me.txtsex.Enabled = True
        Me.txtstatus.Enabled = True
        Me.txtsurname.Enabled = True

    End Sub
    Public Sub GetControlDisable()
        Me.txtaddress.Enabled = False
        Me.txtemail.Enabled = False
        Me.txtfirst.Enabled = False
        Me.txtinstitution.Enabled = False
        Me.txtmiddle.Enabled = False
        Me.txtnumber.Enabled = False
        Me.txtorigin.Enabled = False
        Me.txtqualification.Enabled = False
        Me.txtsex.Enabled = False
        Me.txtstatus.Enabled = False
        Me.txtsurname.Enabled = False
    End Sub

    Private Sub txtsex_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If System.Char.IsLetter(e.KeyChar) Then Exit Sub
        If System.Char.IsControl(e.KeyChar) Then
            Exit Sub
        Else
            Beep()
            MsgBox("INVALID DATA", MsgBoxStyle.Information)
            MsgBox("TYPE IN VALID STRING", MsgBoxStyle.Information)
            txtsex.Text = ""
        End If
        e.Handled = True
    End Sub

      Private Sub txtinstitution_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtinstitution.KeyPress
        If System.Char.IsLetter(e.KeyChar) Then Exit Sub
        If System.Char.IsControl(e.KeyChar) Then
            Exit Sub
        Else
            Beep()
            MsgBox("INVALID DATA", MsgBoxStyle.Information)
            MsgBox("TYPE IN VALID STRING", MsgBoxStyle.Information)
            txtinstitution.Text = ""
        End If
        e.Handled = True
    End Sub

    Private Sub txtinstitution_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtinstitution.TextChanged

    End Sub

    Private Sub txtorigin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtorigin.KeyPress
        If System.Char.IsLetter(e.KeyChar) Then Exit Sub
        If System.Char.IsControl(e.KeyChar) Then
            Exit Sub
        Else
            Beep()
            MsgBox("INVALID DATA", MsgBoxStyle.Information)
            MsgBox("TYPE IN VALID STRING", MsgBoxStyle.Information)
            txtorigin.Text = ""
        End If
        e.Handled = True
    End Sub


    
    Private Sub chkno_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkno.CheckedChanged
        If chkno.Checked = True Then
            chkyes.Checked = False
            MsgBox("YOU CHOOSE NO TO END PROJECT", MsgBoxStyle.Information)

            End
        End If
    End Sub

    Private Sub chkyes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkyes.CheckedChanged
        If chkyes.Checked = True Then
            MsgBox("YOU CHOOSE YES TO REGISTER AS A USER", MsgBoxStyle.Information)
            bttRegister.Enabled = True
            bttLoad.Enabled = True
            GetControlEnable()
            txtsurname.Focus()
        End If
    End Sub

    Private Sub txtsex_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsex.KeyPress
        'If System.Char Then
        If System.Char.IsControl(e.KeyChar) Or System.Char.IsPunctuation(e.KeyChar) Or System.Char.IsLetterOrDigit(e.KeyChar) Then
            Beep()
            MsgBox("You dont have to type", MsgBoxStyle.Information)
            MsgBox("Select your sex", MsgBoxStyle.Information)
            txtsex.Text = ""

        End If
        e.Handled = True
    End Sub

    Private Sub txtstatus_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtstatus.KeyPress
        If System.Char.IsControl(e.KeyChar) Or System.Char.IsPunctuation(e.KeyChar) Or System.Char.IsLetterOrDigit(e.KeyChar) Then
            Beep()
            MsgBox("You dont have to type", MsgBoxStyle.Information)
            MsgBox("Select your sex", MsgBoxStyle.Information)

        End If
        e.Handled = True
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub
End Class
