Public Class ENTRYFORM
    Private Sub ENTRYFORM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.Hide()
        BIOMETRICS_BACKGROUND_FORM.Show()
    End Sub
End Class

