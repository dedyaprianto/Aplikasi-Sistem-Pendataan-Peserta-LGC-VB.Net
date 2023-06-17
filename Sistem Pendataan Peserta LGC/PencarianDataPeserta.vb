Imports MySql.Data.MySqlClient
Public Class PencarianDataPeserta
    Sub DGV()
        DataGridView1.Columns(0).Width = 50
        DataGridView1.Columns(1).Width = 100
        DataGridView1.Columns(2).Width = 100
        DataGridView1.Columns(3).Width = 45
        DataGridView1.Columns(4).Width = 45
        DataGridView1.Columns(5).Width = 75
        DataGridView1.Columns(6).Width = 100
        DataGridView1.Columns(7).Width = 75
        DataGridView1.Columns(8).Width = 75
    End Sub
    Private Sub PencarianDataPeserta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call koneksi()
        da = New MySqlDataAdapter("select * From peserta ", conn)
        ds = New DataSet
        da.Fill(ds, "peserta")
        DataGridView1.DataSource = ds.Tables("peserta")
        DataGridView1.ReadOnly = True
        Call DGV()
    End Sub

    Private Sub Guna2Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guna2Button1.Click
        Call koneksi()
        If Guna2TextBox1.Text = "" Then
            MsgBox("Mohon Diisi yang ingin dicari")
        Else
            da = New MySqlDataAdapter("SELECT * from peserta where id_lgc LIKE '%" & Guna2TextBox1.Text & "%' or nama_desa_kel like '%" & Guna2TextBox1.Text & "%' or nama_dusun like '%" & Guna2TextBox1.Text & "%'  or rt like '%" & Guna2TextBox1.Text & "%'  or rw like '%" & Guna2TextBox1.Text & "%' or kategori like '%" & Guna2TextBox1.Text & "%' or kecamatan like '%" & Guna2TextBox1.Text & "%'  or nilai_lgc like '%" & Guna2TextBox1.Text & "%'  or ranking like '%" & Guna2TextBox1.Text & "%'", conn)
            ds = New DataSet
            da.Fill(ds, "id_lgc")
            da.Fill(ds, "nama_desa_kel")
            da.Fill(ds, "nama_dusun")
            da.Fill(ds, "rt")
            da.Fill(ds, "rw")
            da.Fill(ds, "kategori")
            da.Fill(ds, "kecamatan")
            da.Fill(ds, "nilai_lgc")
            da.Fill(ds, "ranking")
            DataGridView1.DataSource = ds.Tables("id_lgc")
            DataGridView1.DataSource = ds.Tables(0)
            DataGridView1.DataSource = ds.Tables("nama_desa_kel")
            DataGridView1.DataSource = ds.Tables(1)
            DataGridView1.DataSource = ds.Tables("nama_dusun")
            DataGridView1.DataSource = ds.Tables(2)
            DataGridView1.DataSource = ds.Tables("rt")
            DataGridView1.DataSource = ds.Tables(3)
            DataGridView1.DataSource = ds.Tables("rw")
            DataGridView1.DataSource = ds.Tables(4)
            DataGridView1.DataSource = ds.Tables("kategori")
            DataGridView1.DataSource = ds.Tables(5)
            DataGridView1.DataSource = ds.Tables("kecamatan")
            DataGridView1.DataSource = ds.Tables(6)
            DataGridView1.DataSource = ds.Tables("nilai_lgc")
            DataGridView1.DataSource = ds.Tables(7)
            DataGridView1.DataSource = ds.Tables("ranking")
            DataGridView1.DataSource = ds.Tables(8)
        End If
    End Sub

    Private Sub Guna2CircleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guna2CircleButton1.Click
        Dashboard.Show()
        Me.Close()
    End Sub
End Class