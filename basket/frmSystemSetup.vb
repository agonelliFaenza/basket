Public Class frmSystemSetup
    Private Sub frmSystemSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each sp As String In My.Computer.Ports.SerialPortNames
            ComboBox1.Items.Add(sp)
            ComboBox2.Items.Add(sp)
        Next
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Settings.COM1 = ComboBox1.Text
        My.Settings.COM2 = ComboBox2.Text
        Try
            MainForm.SerialPort1.PortName = My.Settings.COM1
            MainForm.SerialPort2.PortName = My.Settings.COM2

        Catch
        End Try
        Me.Close()

    End Sub
End Class