Imports MySql.Data.MySqlClient
Public Class DataPegawai
    Sub cmbjk()
        ComboBox1.Items.Add("Laki-laki")
        ComboBox1.Items.Add("Perempuan")
    End Sub
    Sub kosong()
        TextBox1.Text = ""
        TextBox2.Text = ""
        ComboBox1.Text = "Pilih Salah Satu"
        TextBox3.Text = ""
        TextBox4.Text = ""
    End Sub
    Sub jmlpgw()
        Dim dtpgw
        dtpgw = DataGridView1.RowCount
        Label7.Text = dtpgw - 1
    End Sub
    Sub tampil()
        Call koneksi()
        da = New MySqlDataAdapter("select * From pegawai ", conn)
        ds = New DataSet
        da.Fill(ds, "pegawai")
        DataGridView1.DataSource = ds.Tables("pegawai")
        DataGridView1.ReadOnly = True
        Call jmlpgw()
    End Sub
    Private Sub DataPegawai_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call tampil()
        Call cmbjk()
    End Sub
    Private Sub Guna2Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guna2Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or ComboBox1.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            MsgBox("Silahkan Isi Formnya")
        Else
            Call koneksi()
            Dim simpan As String = "INSERT INTO pegawai VALUES ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & ComboBox1.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "') "
            cmd = New MySqlCommand(simpan, conn)
            cmd.ExecuteNonQuery()
            MsgBox("Data Berhasil")
            Call tampil()
            Call kosong()
        End If
    End Sub

    Private Sub Guna2Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guna2Button2.Click
        If MessageBox.Show("Apakah Anda Ingin Merubah Data Pegawai LGC", "konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If TextBox1.Text = "" Or TextBox2.Text = "" Or ComboBox1.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
                MsgBox("Silahkan Isi Formnya")
            Else
                Dim edit As String
                edit = "UPDATE pegawai SET nama_pegawai = '" & TextBox2.Text & "', jenis_kelamin = '" & ComboBox1.Text & "', alamat = '" & TextBox3.Text & "', telepon = '" & TextBox4.Text & "' WHERE id_pegawai= '" & TextBox1.Text & "' "
                cmd = New MySqlCommand(edit, conn)
                cmd.ExecuteNonQuery()
                MsgBox("Data Berhasil Diubah")
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
            hapus = "DELETE FROM pegawai WHERE id_pegawai='" & TextBox1.Text & "'"
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
        LaporanDataPegawai.Show()
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
        ComboBox1.Text = DataGridView1.Item(2, i).Value
        TextBox3.Text = DataGridView1.Item(3, i).Value
        TextBox4.Text = DataGridView1.Item(4, i).Value
    End Sub

End Class