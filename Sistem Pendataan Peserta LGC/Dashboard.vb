Imports MySql.Data.MySqlClient
Public Class Dashboard
    Sub tampil()
        Call koneksi()
        da = New MySqlDataAdapter("select * From pegawai ", conn)
        ds = New DataSet
        da.Fill(ds, "pegawai")
    End Sub
    Private Sub Dashboard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
     
    End Sub

    Private Sub Guna2Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guna2Button1.Click
        DataPeserta.Show()
        Me.Hide()
    End Sub
    Private Sub Guna2Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guna2Button2.Click
        DataPegawai.Show()
        Me.Hide()
    End Sub
    Private Sub Guna2Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guna2Button3.Click
        PencarianDataPeserta.Show()
        Me.Hide()
    End Sub
    Private Sub Guna2Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guna2Button4.Click
        LaporanDataPeserta.Show()
    End Sub

    Private Sub Guna2Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guna2Button5.Click
        PencarianDataPegawai.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guna2Button6.Click
        LaporanDataPegawai.Show()
    End Sub

    Private Sub Guna2Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guna2Button7.Click
        ResetPassword.Show()
        Me.Hide()
    End Sub
    Private Sub Guna2Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guna2Button8.Click
        If MessageBox.Show("Apakah Anda Menutup Aplikasi ???", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

End Class