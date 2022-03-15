Public Class Login
    'clear-button
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        userName.Clear()
        password.Clear()

    End Sub

    'close [X]
    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Application.Exit()
    End Sub

    'Login button
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If userName.Text = "" Or password.Text = "" Then
            MsgBox("Please enter username and password")
        ElseIf userName.Text = "admin" And password.Text = "admin@123" Then
            Dim Main = New MainForm
            Main.Show()
            Me.Hide()
        Else
            MsgBox("Username or password is incorrect!!")
        End If
    End Sub
End Class