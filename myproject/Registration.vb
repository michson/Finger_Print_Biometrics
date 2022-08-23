Imports GrFingerXLib
Imports System.Data.OleDb
Public Class Registration
    Const ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
    Private myUtil As util
    Const myDb = "MajorDB.mdb"
    Private _UserID As Integer
    Private connection As System.Data.OleDb.OleDbConnection
    Dim cnobj, cnobjState As OleDbConnection
    Dim cmobj, cmobj1, cmobjState, cmobj2 As OleDbCommand
    Dim rdobj, rdobj1, rdobjState, rdobj2 As OleDbDataReader
    Dim sqlfetch, sqlsave, HoldLevel, sqlstate As String

    Private Sub AxGrFingerXCtrl1_SensorPlug( _
       ByVal sender As System.Object, _
       ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_SensorPlugEvent) _
       Handles AxGrFingerXCtrl1.SensorPlug
        myUtil.WriteLog("Sensor: " & e.idSensor & ". Event: Plugged.")
        AxGrFingerXCtrl1.CapStartCapture(e.idSensor)
    End Sub

    Private Sub AxGrFingerXCtrl1_SensorUnplug( _
       ByVal sender As System.Object, _
       ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_SensorUnplugEvent) _
       Handles AxGrFingerXCtrl1.SensorUnplug
        myUtil.WriteLog("Sensor: " & e.idSensor & ". Event: Unplugged.")
        AxGrFingerXCtrl1.CapStopCapture(e.idSensor)
    End Sub
    Private Sub AxGrFingerXCtrl1_FingerDown( _
           ByVal sender As System.Object, _
           ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_FingerDownEvent) _
           Handles AxGrFingerXCtrl1.FingerDown
        myUtil.WriteLog("Sensor: " & e.idSensor & ". Event: Finger Placed.")
    End Sub

    Private Sub AxGrFingerXCtrl1_FingerUp( _
      ByVal sender As System.Object, _
      ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_FingerUpEvent) _
      Handles AxGrFingerXCtrl1.FingerUp
        myUtil.WriteLog("Sensor: " & e.idSensor & ". Event: Finger removed.")
    End Sub

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

    Private Function IdentifyFingerprint() As Integer
        Dim ret As Integer, score As Integer
        score = 0
        ret = myUtil.Identify(score)
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

    Private Sub AxGrFingerXCtrl1_ImageAcquired( _
       ByVal sender As System.Object, _
       ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_ImageAcquiredEvent) _
       Handles AxGrFingerXCtrl1.ImageAcquired

        myUtil.raw.height = e.height
        myUtil.raw.width = e.width
        myUtil.raw.res = e.res
        myUtil.raw.img = e.rawImage

        myUtil.WriteLog("Sensor: " & e.idSensor & ". Event: Image captured.")

        ' myUtil.PrintBiometricDisplay(False, GRConstants.GR_DEFAULT_CONTEXT)

        ExtractTemplate()

        _UserID = IdentifyFingerprint()
    End Sub

    Public Sub GetUserInfo()
        Dim filePath As String
        Try
            filePath = Application.StartupPath() & "\" & myDb
            connection = New OleDb.OleDbConnection(ConnectionString & filePath)
            connection.Open()
            Dim reader As OleDb.OleDbDataReader
            Dim command As OleDb.OleDbCommand = New OleDb.OleDbCommand
            command.Connection = connection
            '---retrieve user's particulars---
            command.CommandText = "SELECT * FROM Enroll WHERE ID=" & _UserID
            reader = command.ExecuteReader(CommandBehavior.CloseConnection)
            reader.Read()
            If reader.HasRows = True Then
                MsgBox("The user with this thumb print has been registered previously", _
                MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Duplicate registration")
            End If
            '---display user's particulars---
            'lblmessage.Text = "You are Welcome, " & reader("surname")
            'txtsurname.Text = reader("surname")
            'txtfirst.Text = reader("firstname")
            'txtmiddle.Text = reader("middlename")
            'txtnumber.Text = reader("phonenum")
            'txtemail.Text = reader("email")
            'txtsex.Text = reader("sex")
            'txtstatus.Text = reader("Marritalstatus")
            'txtinstitution.Text = reader("institution")
            'txtqualification.Text = reader("qualification")
            'txtorigin.Text = reader("state")
            'txtaddress.Text = reader("address")
            'Me.lblpicture.Text = reader("picture")
            ''---reset the timer to another 5 seconds---
            'Timer1.Enabled = False
            'Timer1.Enabled = True
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            connection.Close()
        End Try
    End Sub

    Private Sub BtnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowse.Click
        MikOpener.Filter = "All Pictures|*.bmp;*.gif;*.jpg;*.png|Bitmaps|*.bmp|GIFs|*.gif|JPEGs|*.jpg|PNGs|*.png"
        MikOpener.ShowDialog()
        If MikOpener.FileName = "" Then
            PicPass.Image = Nothing
            Exit Sub
            'LblPath.Text = MikOpener.FileName
        Else
            Label1.Visible = False
            PicPass.ImageLocation() = MikOpener.FileName
        End If
    End Sub

    Private Sub BtnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBack.Click
        commonCodes.Back(Me)
    End Sub

    Private Sub Registration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DtPicker.Text = Date.Now
        CboSex.Items.Add("Male")
        CboSex.Items.Add("Female")
        For A As Integer = 1992 To 2100
            CboSession.Items.Add(CStr(A) & "/" & CStr(A + 1))
        Next
        CboSemester.Items.Add("FIRST")
        CboSemester.Items.Add("SECOND")
    End Sub

    Public Sub AddNewUser()
        Dim filePath As String
        Try
            filePath = "D:\Mik New\FINGERPRINTS\myproject" & "\" & myDb 'Application.StartupPath()
            connection = New OleDb.OleDbConnection(ConnectionString & filePath)
            connection.Open()
            Dim sql As String = "UPDATE Students_Info SET Surname='" & Txtsurname.Text & "', " & _
               " Matric_No='" & TxtMatric_No.Text & "', " & _
               " M_Name='" & Txtmidname.Text & "', " & _
               " L_Name='" & Txtmidname.Text & "', " & _
               " Sex='" & CboSex.Text & "', " & _
               " M_Status=" & CboStatus.Text & ", " & _
               " DOB='" & DtPicker.Text & "', " & _
               " EMail='" & txtEmail.Text & "', " & _
               " Religion='" & CboReligion.Text & "', " & _
               " Nationality='" & CboNation.Text & "', " & _
               " State_Orig='" & CboState.Text & "', " & _
               " LGA='" & CboLGA.Text & "', " & _
               " P_Address='" & TxtAddress.Text & "', " & _
               " Phone_No='" & TxtPhone.Text & "', " & _
               " Dept='" & CboDept.Text & "', " & _
               " C_Session='" & CboSession.Text & "', " & _
               " C_Programme='" & CboProgramme.Text & "', " & _
               " C_Level='" & CboLevel.Text & "', " & _
               " C_Semester='" & CboSemester.Text & "', " & _
               " PictureAddress='" & LblPath.Text & "', " & _
               " K_Surname='" & txtKname.Text & "', " & _
               " K_ONames='" & txtKOtherName.Text & "', " & _
               " K_Address='" & txtKAddress.Text & "', " & _
               " K_Phone='" & txtKPhone.Text & "', " & _
               " K_Email='" & txtKEmail.Text & "', " & _
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


    Private Sub BtnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnContinue.Click
        _UserID = EnrollFingerprint()
        'WriteToLog(_UserID)
        AddNewUser()
    End Sub

    
    Private Sub BtnActive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActive.Click
        myUtil = New util(ListBox1, PicThumb, AxGrFingerXCtrl1)
        Dim err As Integer
        ' ----- to nitialize GrFingerX Library ----
        err = myUtil.InitializeGrFinger()
        ' ---- to Print the result in log ------
        If err < 0 Then
            myUtil.WriteError(err)
            Exit Sub
        Else
            MsgBox("GrFingerX Initialized Successfull")
        End If
    End Sub
End Class