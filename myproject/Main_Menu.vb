Public Class Main_Menu

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        If MsgBox("Shutdown Application! Are you sure?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Caution!!!") = MsgBoxResult.Yes Then
            Me.Close()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub VerifyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerifyToolStripMenuItem.Click
        Registration.Show(Me)
    End Sub

    Private Sub VerifyStudentHereToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerifyStudentHereToolStripMenuItem.Click
        Form1.Show(Me)
    End Sub
End Class