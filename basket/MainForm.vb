Public Class MainForm
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
            End If
        Catch
            lblStatus1.Text = "PORT1 non connessa"
        Finally
        End Try
    End Sub
End Class
