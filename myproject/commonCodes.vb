Imports System.Data.OleDb
Module commonCodes
    

    Public Sub Back(ByVal Fm As Form)
        Dim MIKMsg As MsgBoxResult
        MIKMsg = MsgBox("Are you sure you want to close this window?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Caution")
        If MIKMsg = MsgBoxResult.Yes Then
            Fm.Close()
        Else
            Exit Sub
        End If
    End Sub
End Module
