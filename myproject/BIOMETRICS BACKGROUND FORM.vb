Public Class BIOMETRICS_BACKGROUND_FORM

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer2.Enabled = True
        Timer3.Enabled = True
        back()
    End Sub
    Private Sub back()
        Dim frm As New Form1
        frm.Show()
        Timer1.Enabled = False

    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        Dim G As Graphics
        G = Me.CreateGraphics
        Dim path As New System.Drawing.Drawing2D.GraphicsPath()
        path.AddLine(New Point(60, 60), New Point(600, 60))
        path.AddLine(New Point(600, 60), New Point(600, 750))
        path.AddLine(New Point(600, 750), New Point(60, 750))
        Dim pathBrush As New System.Drawing.Drawing2D.PathGradientBrush(path)
        pathBrush.CenterColor = Color.Red
        Dim surroundColors() As Color = _
        {Color.Yellow, Color.Green, Color.Blue, Color.Cyan}
        pathBrush.SurroundColors = surroundColors
        G.FillPath(pathBrush, path)
        Me.BackgroundImage = My.Resources.Rhododendron
        PictureBox1.Image = My.Resources.fingerprintreader2
        Label1.Text = "FINGERPRINT PROCESSING SYSTEM"
        'Label2.Text = "BIOMETRICS"
        Timer2.Enabled = True
        Timer3.Enabled = False
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Dim G As Graphics
        Me.CenterToScreen()
        Me.BackgroundImage = My.Resources.Rhododendron

        PictureBox1.Image = My.Resources.Soap_Bubbles
        ' Dim G As Graphics
        Dim P As New Pen(Color.Blue)
        G = PictureBox1.CreateGraphics
        G.DrawRectangle(P, 10, 10, 200, 150)
        G.DrawLine(P, 10, 10, 210, 160)
        G.DrawLine(P, 210, 10, 10, 160)
        Dim pn As New Pen(Me.ForeColor)
        pn.Width = 10
        pn.DashStyle = Drawing.Drawing2D.DashStyle.Dash
        Dim rect As Rectangle
        rect.X = Me.ClientRectangle.X + (Me.ClientRectangle.Width \ 4)
        rect.Y = Me.ClientRectangle.Y + (Me.ClientRectangle.Height \ 4)
        rect.Width = Me.ClientRectangle.Width \ 2
        rect.Height = Me.ClientRectangle.Height \ 2
        'e.Graphics.DrawEllipse(pn, rect)
        pn.Dispose()
        Label1.Text = "DESIGNED AND IMPLEMENTATION OF FINGERPRINT SECURITY PROCESSING SYSTEM"
        'Label2.Text = "FINGERPRINT TECHNIQUE OF"
        Timer2.Enabled = False
        Timer3.Enabled = True
    End Sub

    Private Sub BIOMETRICS_BACKGROUND_FORM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        Timer2.Enabled = True
        Timer3.Enabled = True
        Me.BackgroundImage = My.Resources.Rhododendron
        Me.PictureBox1.Image = My.Resources.fingerprintreader2
    End Sub
End Class