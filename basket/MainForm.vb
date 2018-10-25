Public Class MainForm
    Public sxBuf(50) As Byte
    Public dxBuf(50) As Byte
    Public bufFalli(50) As Byte

    Private Sub btnEsci_Click(sender As Object, e As EventArgs) Handles btnEsci.Click
        Me.Close()
    End Sub

    Private Sub Button61_Click(sender As Object, e As EventArgs) Handles Button61.Click
        frmSetup.ActiveControl = frmSetup.MTB1
        frmSetup.MTB1.Text = ""
        frmSetup.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            If SerialPort1.IsOpen = False Then
                SerialPort1.Open()
                lblStatus1.Text = "PORT1 connessa"
            Else
                SerialPort1.Write(bufFalli, 0, 50)
            End If
        Catch
            lblStatus1.Text = "PORT1 non connessa"
        Finally
        End Try
        Try
            If SerialPort2.IsOpen = False Then
                SerialPort2.Open()
                lblStatus2.Text = "PORT2 connessa"
            End If
        Catch
            lblStatus2.Text = "PORT2 non connessa"
        Finally
        End Try


    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = 0 To 49
            bufFalli(i) = 0
        Next
        bufFalli(0) = &H3F
        bufFalli(49) = &H6F
        Try
            Me.SerialPort1.PortName = My.Settings.COM1
            Me.SerialPort2.PortName = My.Settings.COM2
        Catch
        End Try

    End Sub

    Private Sub NomeSX1_Click(sender As Object, e As EventArgs) Handles NomeSX1.Click
        NomeSX1.BackColor = Color.Red
        NomeSX2.Enabled = False
        NomeSX3.Enabled = False
        NomeSX4.Enabled = False
        NomeSX5.Enabled = False
        NomeSX6.Enabled = False
        NomeSX7.Enabled = False
        NomeSX8.Enabled = False
        NomeSX9.Enabled = False
        NomeSX10.Enabled = False
        NomeSX11.Enabled = False
        NomeSX12.Enabled = False
        NomeDX1.Enabled = False
        NomeDX2.Enabled = False
        NomeDX3.Enabled = False
        NomeDX4.Enabled = False
        NomeDX5.Enabled = False
        NomeDX6.Enabled = False
        NomeDX7.Enabled = False
        NomeDX8.Enabled = False
        NomeDX9.Enabled = False
        NomeDX10.Enabled = False
        NomeDX11.Enabled = False
        NomeDX12.Enabled = False
        ButtonPiu.Enabled = True
        ButtonMeno.Enabled = True
    End Sub
End Class
