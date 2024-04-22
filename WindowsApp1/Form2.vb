Imports System.Data.SqlClient
Public Class Form2
    Public Conn As New SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Students;Data Source=OTHMANPC")
    Public DTable1 As New DataTable
    Public Cmd1 As New SqlCommand("select * from Studnets", Conn)
    Public DAdapter1 As New SqlDataAdapter(Cmd1)
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Me.Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox1.Select()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If Conn.State = ConnectionState.Closed Then Conn.Open()
        DAdapter1.Fill(DTable1)
        DataGridView1.DataSource = DTable1
        If Conn.State = ConnectionState.Open Then Conn.Close()
        ' MsgBox("تمت علمية التعبئة البيانات بنجاح", MsgBoxStyle.Information, "")
        Button1.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        Button6.Enabled = True
        Button7.Enabled = True
        Button8.Enabled = False
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text <> "" And TextBox2.Text <> "" Then
            Dim DRow As DataRow
            DRow = DTable1.NewRow
            DRow.Item(0) = Val(TextBox1.Text)
            DRow.Item(1) = Trim(TextBox2.Text)
            DTable1.Rows.Add(DRow)
            MsgBox("تمت عملية الحفظ بنجاح", MsgBoxStyle.Information)
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox1.Select()
        End If
    End Sub
End Class