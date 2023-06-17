Imports MySql.Data.MySqlClient
Public Class Login
    Sub kosong()
        Guna2TextBox1.Text = ""
        Guna2TextBox2.Text = ""
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call koneksi()
        Guna2TextBox2.UseSystemPasswordChar = True
    End Sub
    Private Sub Guna2CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guna2CheckBox1.CheckedChanged
        If Guna2CheckBox1.CheckState = CheckState.Checked Then
            Guna2TextBox2.UseSystemPasswordChar = False
        Else
            Guna2TextBox2.UseSystemPasswordChar = True
        End If
    End Sub
    Private Sub Guna2Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guna2Button1.Click
        Call koneksi()
        Dim sql As String
        sql = "SELECT * FROM admin WHERE username='" + Guna2TextBox1.Text + "' AND password='" + Guna2TextBox2.Text + "'"
        cmd = New MySqlCommand(sql, conn)
        dr = cmd.ExecuteReader()
        If dr.HasRows = True Then
            MsgBox("Login Sukses!, Selamat Datang " + Guna2TextBox1.Text + " ", MsgBoxStyle.Information, "")
            Call kosong()
            Dashboard.Show()
            Me.Hide()
        Else
            MessageBox.Show("Maaf, Username dan Password Salah", "Konfirmasi",
            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Guna2TextBox1.Focus()
            Call kosong()
        End If
    End Sub
End Class
