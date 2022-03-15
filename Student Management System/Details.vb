Imports MySql.Data.MySqlClient
Public Class Details
    'database connection
    Dim Con As New MySqlConnection("host=127.0.0.1; user=root; database=student_management_system")

    'Fetching data of each student through id from database
    Private Sub FetchStudentData()
        If student_id.Text = "" Then
            MsgBox("Enter Student Id")
        Else
            Con.Open()
            Dim Query = "select * from student where student_id=" & student_id.Text & ""
            Dim cmd As MySqlCommand
            cmd = New MySqlCommand(Query, Con)
            Dim dt As DataTable
            dt = New DataTable
            Dim sda As MySqlDataAdapter
            sda = New MySqlDataAdapter(cmd)
            sda.Fill(dt)
            For Each dr As DataRow In dt.Rows
                student_name.Text = dr(1).ToString
                student_address.Text = dr(2).ToString
                student_contact.Text = dr(3).ToString
                student_email.Text = dr(4).ToString

                student_name.Visible = True
                student_address.Visible = True
                student_contact.Visible = True
                student_email.Visible = True
            Next
            Con.Close()
        End If


    End Sub
    Private Sub Details_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    'Search button calling fetch funtion
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FetchStudentData()
    End Sub

    'home redirect
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Dim Main = New MainForm
        Main.Show()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        e.Graphics.DrawString("Student Management System", New Font("Century gothic", 25), Brushes.SkyBlue, 180, 40)
        e.Graphics.DrawString("***Student Confidential Information***", New Font("Arial", 20), Brushes.Crimson, 200, 100)
        e.Graphics.DrawString(("Student Name: " + student_name.Text + vbCrLf + "Student Address: " + student_address.Text + vbCrLf + "Student Contact: " + student_contact.Text + vbCrLf + "Student Email: " + student_email.Text), New Font("Arial", 20), Brushes.Black, 150, 190)

        e.Graphics.DrawString("--------Student Information End------------", New Font("Century gothic", 15), Brushes.SkyBlue, 150, 500)
    End Sub

    'print page redirect
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PrintPreviewDialog1.Show()
    End Sub
End Class