

' -----------------------------------------------------------------------------------
' Database routines
' -----------------------------------------------------------------------------------

Imports System.Data.OleDb
Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Drawing.Imaging
' Template data
Public Class TTemplate
    ' Template itself
    Public tpt As System.Array = Array.CreateInstance(GetType(Byte), GrFingerXLib.GRConstants.GR_MAX_SIZE_TEMPLATE)


    ' Template size
    Public Size As Long
End Class
' Template list
Public Structure TTemplates
    ' ID
    Public ID As Integer
    ' Template itself
    Public template As TTemplate
End Structure

Public Class DBClass

    ' the database we'll be connecting to
    Public DBFile As String = "majorDB.mdb"
    Public ConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="

    ' the connection object
    Dim connection As New OleDbConnection

    ' Open connection
    Public Function OpenDB() As Boolean
        Dim filePath As String
        Try
            filePath = "D:\Mik New\FINGERPRINTS\myproject" & "\" & DBFile 'Application.StartupPath() & "\" & DBFile
            connection = New OleDb.OleDbConnection(ConnectionString & filePath)
            Return True
        Catch
            Return False
        End Try
    End Function

    ' Close conection
    Public Sub closeDB()
        connection.Close()
    End Sub

    ' Clear database
    Public Sub clearDB()
        Dim sqlCMD As OleDbCommand = New OleDbCommand("DELETE FROM enroll", connection)
        ' run "clear" query
        sqlCMD.Connection.Open()
        sqlCMD.ExecuteNonQuery()
        sqlCMD.Connection.Close()
    End Sub

    ' Add template to database. Returns added template ID.
    Public Function AddTemplate(ByRef template As TTemplate) As Long
        Dim da As New OleDbDataAdapter("select * from Students_Info", connection)

        ' Create SQL command containing ? parameter for BLOB.
        da.InsertCommand = New OleDbCommand("INSERT INTO Students_Info (template) Values(?)", connection)
        da.InsertCommand.CommandType = CommandType.Text
        da.InsertCommand.Parameters.Add("@template", OleDbType.Binary, template.Size, "template")

        ' Open connection
        connection.Open()

        ' Fill DataSet.
        Dim Mik As DataSet = New DataSet
        da.Fill(Mik, "Students_Info")

        ' Add a new row.
        ' Create parameter for ? contained in the SQL statement.
        Dim newRow As DataRow = Mik.Tables("Students_Info").NewRow()
        newRow("template") = template.tpt
        Mik.Tables("Students_Info").Rows.Add(newRow)

        ' Include an event to fill in the Autonumber value.
        AddHandler da.RowUpdated, New OleDbRowUpdatedEventHandler(AddressOf OnRowUpdated)

        ' Update DataSet.
        da.Update(Mik, "Students_Info")
        connection.Close()

        ' return ID
        Return newRow("ID")
    End Function

    ' Event procedure for OnRowUpdated
    Private Sub OnRowUpdated(ByVal sender As Object, ByVal args As OleDbRowUpdatedEventArgs)
        ' Include a variable and a command to retrieve identity value
        ' from Access database.
        Dim newID As Integer = 0
        Dim idCMD As OleDbCommand = New OleDbCommand("SELECT @@IDENTITY", connection)

        If args.StatementType = StatementType.Insert Then
            ' Retrieve identity value and store it in column
            newID = CInt(idCMD.ExecuteScalar())
            args.Row("ID") = newID
        End If
    End Sub

    ' Returns a DataTable with all enrolled templates from database.
    Public Function getTemplates() As TTemplates()
        Dim ds As New DataSet
        Dim da As New OleDbDataAdapter("select * from Students_Info", connection)
        Dim ttpts As TTemplates()
        Dim i As Integer

        ' Get query response
        da.Fill(ds)
        Dim tpts As DataRowCollection = ds.Tables(0).Rows
        ' Create response array
        ReDim ttpts(tpts.Count)
        ' No results?
        If tpts.Count = 0 Then Return ttpts
        ' get each template and put results in our array
        For i = 1 To tpts.Count
            ttpts(i).template = New TTemplate
            ttpts(i).ID = tpts.Item(i - 1).Item("ID")
            ttpts(i).template.tpt = tpts.Item(i - 1).Item("template")
            ttpts(i).template.Size = ttpts(i).template.tpt.Length
        Next
        Return ttpts
    End Function

    ' Returns template with supplied ID.
    Public Function getTemplate(ByVal id As Long) As Byte()
        Dim ds As New DataSet
        Dim da As New OleDbDataAdapter("select * from Students_Info where ID = " & id, connection)
        Dim tpt As New TTemplate

        ' Get query response
        da.Fill(ds)
        Dim tpts As DataRowCollection = ds.Tables(0).Rows
        ' No results?
        If tpts.Count <> 1 Then Return Nothing
        ' Deserialize template and return it
        Return tpts.Item(0).Item("template")
    End Function

End Class