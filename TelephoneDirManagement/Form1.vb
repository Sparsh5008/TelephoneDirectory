﻿Imports MySql.Data.MySqlClient
Public Class Form1
    Dim MySqlConn As MySqlConnection
    Dim mycom As MySqlCommand
    Dim captcha As Integer
    Dim number As Integer = 7
    Sub loadCaptcha()
        If captcha = 1 Then
            pic5.Image = My.Resources.img2
        ElseIf captcha = 2 Then
            pic5.Image = My.Resources.imkiz
        ElseIf captcha = 3 Then
            pic5.Image = My.Resources.not_a_robot
        ElseIf captcha = 4 Then
            pic5.Image = My.Resources.captcha
        ElseIf captcha = 5 Then
            pic5.Image = My.Resources.captcha2
        ElseIf captcha = 6 Then
            pic5.Image = My.Resources.google
        Else
            pic5.Image = My.Resources.fkr92pd
        End If
    End Sub
    Function verify_captcha(num As Integer, str As String)
        'verifies captcha string against integer corresponding to image

        If num = 1 And str = "smwm" Then
            Return 1
        ElseIf num = 2 And str = "imkiz" Then
            Return 1
        ElseIf num = 3 And str = "notarobot" Then
            Return 1
        ElseIf num = 4 And str = "CAPTCHA" Then
            Return 1
        ElseIf num = 5 And str = "CAPTCHA" Then
            Return 1
        ElseIf num = 6 And str = "Google" Then
            Return 1
        ElseIf num = 7 And str = "fkr92pd" Then
            Return 1
        Else
            Return 0
        End If
        Return 1

    End Function
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server='" & TextBox4.Text & "';userid=root;password=root;database=user_data"
        Try
            MySqlConn.Open()
            captcha = CInt(Math.Ceiling(Rnd() * number))
            captcha = captcha Mod number + 1
            loadCaptcha()
            pic1.Image = My.Resources.online
            MySqlConn.Close()
        Catch ex As MySqlException
            pic1.Image = My.Resources.offline
        End Try
    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = False Then
            TextBox2.PasswordChar = "*"
        Else
            TextBox2.PasswordChar = ""
        End If
    End Sub
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server='" & TextBox4.Text & "';userid=root;password=root;database=user_data"
        Dim reader As MySqlDataReader

        Try
            Label4.Text = ""
            MySqlConn.Open()
            pic1.Image = My.Resources.online
            Dim query As String
            If r1.Checked = True Then
                query = "Select * from user_data.user_table where UserName = '" & TextBox1.Text & "' and Password= '" & TextBox2.Text & "'"
                mycom = New MySqlCommand(query, MySqlConn)
            ElseIf r2.Checked = True Then
                query = "Select * from user_data.admin_data where UserName = '" & TextBox1.Text & "' and Password= '" & TextBox2.Text & "'"
                mycom = New MySqlCommand(query, MySqlConn)
            ElseIf r1.Checked = False And r2.Checked = False Then
                MessageBox.Show("Select User or Admin")

            End If


            reader = mycom.ExecuteReader()
            Dim count As Integer = 0
            While reader.Read
                count = count + 1
            End While
            If count = 1 Then
                If verify_captcha(captcha, TextBox3.Text) = 1 Then

                    UserForm1.Show()
                    Me.Hide()
                Else
                    MessageBox.Show("try again")
                End If
            Else
                Label4.Text = "*incorrect username or password"
            End If
            MySqlConn.Close()
        Catch ex As MySqlException
            pic1.Image = My.Resources.offline
        End Try
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        captcha = (captcha + 1) Mod number + 1
        loadCaptcha()
    End Sub



    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Hide()
        RegForm1.Show()
    End Sub

    Private Sub r2_CheckedChanged(sender As Object, e As EventArgs) Handles r2.CheckedChanged
        Label1.Text = "ADMIN LOGIN"
    End Sub

    Private Sub r1_CheckedChanged(sender As Object, e As EventArgs) Handles r1.CheckedChanged
        Label1.Text = "USER LOGIN"

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    '  Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
    ' MySqlConn = New MySqlConnection
    ' MySqlConn.ConnectionString = "server='" & TextBox4.Text & "';userid=root;password=root;database=user_data"
    'Try
    '    MySqlConn.Open()
    '  captcha = CInt(Math.Ceiling(Rnd() * number))
    '  captcha = captcha Mod number + 1
    '  loadCaptcha()
    ' pic1.Image = My.Resources.online
    ' MySqlConn.Close()
    '  Catch ex As MySqlException
    ' pic1.Image = My.Resources.offline
    '   End Try
    ' End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server='" & TextBox4.Text & "';userid=root;password=root;database=user_data"
        Try
            MySqlConn.Open()
            captcha = CInt(Math.Ceiling(Rnd() * number))
            captcha = captcha Mod number + 1
            loadCaptcha()
            pic1.Image = My.Resources.online
            MySqlConn.Close()
        Catch ex As MySqlException
            pic1.Image = My.Resources.offline
        End Try
    End Sub
End Class
