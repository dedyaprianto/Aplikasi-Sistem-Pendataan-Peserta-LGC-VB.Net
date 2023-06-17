Imports MySql.Data.MySqlClient
Public Class DataPeserta
    Sub cmbktg()
        ComboBox1.Items.Add("Perintis")
        ComboBox1.Items.Add("Berkembang")
        ComboBox1.Items.Add("Maju")
        ComboBox1.Items.Add("Mandiri")
        ComboBox1.Items.Add("Kencana")
        ComboBox1.Items.Add("Percontohan")
    End Sub
    Sub cmbkec()
        ComboBox2.Items.Add("Lamongan")
        ComboBox2.Items.Add("Deket")
        ComboBox2.Items.Add("Tikung")
        ComboBox2.Items.Add("Mantup")
        ComboBox2.Items.Add("Sarirejo")
        ComboBox2.Items.Add("Kembangbahu")
        ComboBox2.Items.Add("Turi")
        ComboBox2.Items.Add("Sukodadi")
        ComboBox2.Items.Add("Kalitengah")
        ComboBox2.Items.Add("Karanggeneng")
        ComboBox2.Items.Add("Karangbinangun")
        ComboBox2.Items.Add("Glagah")
        ComboBox2.Items.Add("Laren")
        ComboBox2.Items.Add("Paciran")
        ComboBox2.Items.Add("Brondong")
        ComboBox2.Items.Add("Solokuro")
        ComboBox2.Items.Add("Pucuk")
        ComboBox2.Items.Add("Babat")
        ComboBox2.Items.Add("Sekaran")
        ComboBox2.Items.Add("Maduran")
        ComboBox2.Items.Add("Sugio")
        ComboBox2.Items.Add("Kedungpring")
        ComboBox2.Items.Add("Ngimbang")
        ComboBox2.Items.Add("Sambeng")
        ComboBox2.Items.Add("Modo")
        ComboBox2.Items.Add("Bluluk")
        ComboBox2.Items.Add("Sukorame")
    End Sub
    Sub kosong()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        ComboBox1.Text = "Pilih Salah Satu"
        ComboBox2.Text = "Pilih Salah Satu"
        TextBox6.Text = ""
        TextBox7.Text = ""
    End Sub
    Sub jmlpsrt()
        Dim dtpsrt
        dtpsrt = DataGridView1.RowCount
        Label11.Text = dtpsrt - 1
    End Sub
    Sub tampil()
        Call koneksi()
        da = New MySqlDataAdapter("select * From peserta ", conn)
        ds = New DataSet
        da.Fill(ds, "peserta")
        DataGridView1.DataSource = ds.Tables("peserta")
        DataGridView1.ReadOnly = True
        Call jmlpsrt()
    End Sub
    Private Sub DataPeserta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call tampil()
        Call cmbkec()
        Call cmbktg()
        Call DGV()
    End Sub
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
    Private Sub Guna2Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guna2Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or ComboBox1.Text = "" Or ComboBox2.Text = "" Then
            MsgBox("Silahkan Isi Formnya")
        Else
            Call koneksi()
            Dim simpan As String = "INSERT INTO peserta VALUES ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & ComboBox1.Text & "','" & ComboBox2.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "')"
            cmd = New MySqlCommand(simpan, conn)
            cmd.ExecuteNonQuery()
            MsgBox("Input data berhasil")
            Call tampil()
            Call kosong()
        End If
    End Sub

    Private Sub Guna2Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guna2Button2.Click
        If MessageBox.Show("Apakah Anda Ingin Merubah Data Peserta", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or ComboBox1.Text = "" Or ComboBox2.Text = "" Then
                MsgBox("Silahkan Isi Formnya")
            Else
                Dim edit As String
                edit = "UPDATE peserta SET nama_desa_kel = '" & TextBox2.Text & "', nama_dusun = '" & TextBox3.Text & "', rt = '" & TextBox4.Text & "', rw = '" & TextBox5.Text & "', kategori = '" & ComboBox1.Text & "', kecamatan = '" & ComboBox2.Text & "', nilai_lgc = '" & TextBox6.Text & "', ranking = '" & TextBox7.Text & "' WHERE id_lgc= '" & TextBox1.Text & "' "
                cmd = New MySqlCommand(edit, conn)
                cmd.ExecuteNonQuery()
                Call tampil()
                Call kosong()
            End If
        End If
    End Sub
    Private Sub Guna2Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guna2Button3.Click
        koneksi()
        If TextBox1.Text = "" Then
            MsgBox("Data belum di pilih", vbInformation, "Pesan")
            Exit Sub
        Else
            Dim hapus As String
            hapus = "DELETE FROM peserta WHERE id_lgc='" & TextBox1.Text & "'"
            cmd = New MySqlCommand(hapus, conn)
            cmd.ExecuteNonQuery()
            MsgBox("Data berhasil di hapus", vbInformation, "Pesan")
            tampil()
            kosong()
        End If
    End Sub

    Private Sub Guna2Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guna2Button4.Click
        Call kosong()
    End Sub

    Private Sub Guna2Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guna2Button5.Click
        LaporanDataPeserta.CrystalReportViewer1.ReportSource = LaporanDataPeserta.CR_DataPeserta1
        LaporanDataPeserta.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2CircleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guna2CircleButton1.Click
        Dashboard.Show()
        Me.Close()
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index

        TextBox1.Text = DataGridView1.Item(0, i).Value
        TextBox2.Text = DataGridView1.Item(1, i).Value
        TextBox3.Text = DataGridView1.Item(2, i).Value
        TextBox4.Text = DataGridView1.Item(3, i).Value
        TextBox5.Text = DataGridView1.Item(4, i).Value
        ComboBox1.Text = DataGridView1.Item(5, i).Value
        ComboBox2.Text = DataGridView1.Item(6, i).Value
        TextBox6.Text = DataGridView1.Item(7, i).Value
        TextBox7.Text = DataGridView1.Item(8, i).Value
    End Sub

End Class