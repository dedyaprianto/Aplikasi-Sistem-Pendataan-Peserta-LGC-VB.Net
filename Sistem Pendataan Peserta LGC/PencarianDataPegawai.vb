Imports MySql.Data.MySqlClient
Public Class PencarianDataPegawai
    Private Sub PencarianDataPegawai_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call koneksi()
        da = New MySqlDataAdapter("SELECT * FROM pegawai ", conn)
        ds = New DataSet
        da.Fill(ds, "pegawai")
        DataGridView1.DataSource = ds.Tables("pegawai")
        DataGridView1.ReadOnly = True
    End Sub

    Private Sub Guna2Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guna2Button1.Click
        Call koneksi()
        If Guna2TextBox1.Text = "" Then
            MsgBox("Mohon Diisi yang ingin dicari")
        Else
            Dim cari As String
            cari = "SELECT * FROM pegawai WHERE id_pegawai LIKE '%" & Guna2TextBox1.Text & "%' OR nama_pegawai LIKE '%" & Guna2TextBox1.Text & "%' OR jenis_kelamin LIKE '%" & Guna2TextBox1.Text & "%' OR alamat LIKE '%" & Guna2TextBox1.Text & "%'"
            da = New MySqlDataAdapter(cari, conn)
            Dim dt As New DataTable
            dt.Clear()
            da.Fill(dt)
            DataGridView1.DataSource = dt
            DataGridView1.ClearSelection()
        End If
    End Sub

    Private Sub Guna2CircleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guna2CircleButton1.Click
        Dashboard.Show()
        Me.Close()
    End Sub
End Class