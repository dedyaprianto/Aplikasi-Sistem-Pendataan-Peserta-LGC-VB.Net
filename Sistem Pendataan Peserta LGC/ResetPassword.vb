Imports MySql.Data.MySqlClient
Public Class ResetPassword
    Sub kosong()
        Guna2TextBox1.Text = ""
        Guna2TextBox2.Text = ""
        Guna2TextBox3.Text = ""
        Guna2TextBox4.Text = ""
        Label5.Text = ""
        Label6.Text = ""
    End Sub
    Private Sub Guna2TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guna2TextBox2.TextChanged
        koneksi()
        cmd = New MySqlCommand("SELECT PASSWORD FROM admin WHERE username ='" & Guna2TextBox1.Text & "'", conn)
        Dim pass As String = cmd.ExecuteScalar
        If (pass = Guna2TextBox2.Text) Then
            Label5.Text = "BENAR"
            Label5.ForeColor = Color.Lime
        Else
            Label5.Text = "SALAH"
            Label5.ForeColor = Color.Red
        End If
    End Sub

    Private Sub Guna2TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guna2TextBox4.TextChanged
        If (Guna2TextBox3.Text = Guna2TextBox4.Text) Then
            Label6.Text = "SESUAI"
            Label6.ForeColor = Color.Lime
        Else
            Label6.Text = "TIDAK SESUAI"
            Label6.ForeColor = Color.Red
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If Guna2TextBox2.UseSystemPasswordChar = True Then
            Guna2TextBox2.UseSystemPasswordChar = False
        Else
            Guna2TextBox2.UseSystemPasswordChar = True
        End If

        If Guna2TextBox3.UseSystemPasswordChar = True Then
            Guna2TextBox3.UseSystemPasswordChar = False
        Else
            Guna2TextBox3.UseSystemPasswordChar = True
        End If

        If Guna2TextBox4.UseSystemPasswordChar = True Then
            Guna2TextBox4.UseSystemPasswordChar = False
        Else
            Guna2TextBox4.UseSystemPasswordChar = True
        End If
    End Sub
    Private Sub Guna2Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guna2Button1.Click
        koneksi()
        If Guna2TextBox2.Text = "" Or Guna2TextBox3.Text = "" Or Guna2TextBox4.Text = "" Then
            Guna2TextBox1.Focus
            MsgBox("Maaf, Username dan Password Salah")
            Call kosong()
        Else
            If MessageBox.Show("Apakah Anda Yakin Mengganti Password!", "konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                cmd = New MySqlCommand("UPDATE admin SET password=('" & Guna2TextBox4.Text & "') WHERE username=('" & Guna2TextBox1.Text & "')", conn)
                Dim rts As String = cmd.ExecuteNonQuery()
                MsgBox("Password Berhasil Dirubah")
                Call kosong()
                Login.Show()
                Me.Close()
            End If
        End If
    End Sub

    Private Sub Guna2Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guna2Button2.Click
        Call kosong()
    End Sub

    Private Sub Guna2CircleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guna2CircleButton1.Click
        Dashboard.Show()
        Me.Close()
    End Sub

    Private Sub ResetPassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call kosong()
    End Sub
End Class