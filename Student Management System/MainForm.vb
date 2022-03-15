Public Class MainForm

    'student page
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Hide()
        Dim Stu = New Student
        Stu.Show()
    End Sub
    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Me.Hide()
        Dim Stu = New Student
        Stu.Show()

    End Sub

    'details page
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Hide()
        Dim Det = New Details
        Det.Show()
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Me.Hide()
        Dim Det = New Details
        Det.Show()
    End Sub

    'logout 
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Dim log = New Login
        log.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim log = New Login
        log.Show()
        Me.Hide()
    End Sub


End Class