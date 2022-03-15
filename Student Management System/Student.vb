Imports MySql.Data.MySqlClient

Public Class Student
    'Database connection 
    Dim Con As New MySqlConnection("host=127.0.0.1; user=root; database=student_management_system")
    Private Sub Student_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Populate()
    End Sub
    Private Sub Populate()
        Con.Open()
        Dim sql = "select * from student"
        Dim adapter As MySqlDataAdapter
        adapter = New MySqlDataAdapter(sql, Con)
        Dim builder As MySqlCommandBuilder
        builder = New MySqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        StudentDVG.DataSource = ds.Tables(0)
        Con.Close()
    End Sub

    'Adding student
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Con.Open()
        Dim Query As String
        Query = "insert into student (student_name,student_address,student_contact,student_email) values ('" & student_name.Text & "', '" & student_address.Text & "', '" & student_contact.Text & "', '" & student_email.Text & "')"
        Dim cmd As MySqlCommand
        cmd = New MySqlCommand(Query, Con)
        cmd.ExecuteNonQuery()
        MsgBox("Student Added Successfully")
        Clear()
        Con.Close()
        Populate()
    End Sub

    Dim key = 0

    'clear fields
    Private Sub Clear()
        student_name.Clear()
        key = 0
        student_address.Text = ""
        student_contact.Text = ""
        student_email.Text = ""
    End Sub

    'delete student
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If key = 0 Then
            MsgBox("Select A Student To Delete")
        Else
            Try
                Con.Open()
                Dim Query As String
                Query = "Delete from student where student_id=" & key & ""
                Dim cmd As MySqlCommand
                cmd = New MySqlCommand(Query, Con)
                cmd.ExecuteNonQuery()
                MsgBox("Student Deleted Successfully")
                Con.Close()
                Populate()
                Clear()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    'Student table display
    Private Sub StudentDVG_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles StudentDVG.CellMouseClick
        Dim row As DataGridViewRow = StudentDVG.Rows(e.RowIndex)
        key = Convert.ToInt32(row.Cells(0).Value.ToString())
        student_name.Text = row.Cells(1).Value.ToString()
        student_address.Text = row.Cells(2).Value.ToString()
        student_contact.Text = row.Cells(3).Value.ToString()
        student_email.Text = row.Cells(4).Value.ToString()
    End Sub

    'edit student details
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If student_name.Text = "" Or student_address.Text = "" Or student_contact.Text = "" Or student_email.Text = "" Then
            MsgBox("Missing Information!!")
        Else
            Con.Open()
            Dim Query As String
            Query = "Update student set student_name='" & student_name.Text & "' ,student_address='" & student_address.Text & "',student_contact='" & student_contact.Text & "',student_email='" & student_email.Text & "' where student_id=" & key & ""
            Dim cmd As MySqlCommand
            cmd = New MySqlCommand(Query, Con)
            cmd.ExecuteNonQuery()
            MsgBox("Student Updated Successfully")
            Con.Close()
            Populate()
            Clear()
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Application.Exit()
    End Sub

    'Home button
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        Dim Main = New MainForm
        Main.Show()
    End Sub
End Class
