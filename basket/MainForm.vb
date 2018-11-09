Public Class MainForm
    Public sxBuf(50) As Byte
    Public dxBuf(50) As Byte
    Public bufFalli(55) As Byte
    Public Active
    Public bonusSx As Byte
    Public bonusDx As Byte

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
                lblStatus1.Text = "PORT1 connessa " & SerialPort1.PortName
            Else
                SerialPort1.Write(bufFalli, 0, 55)
            End If
        Catch
            lblStatus1.Text = "PORT1 non connessa " & SerialPort1.PortName
        Finally
        End Try
        Try
            If SerialPort2.IsOpen = False Then
                SerialPort2.Open()
                lblStatus2.Text = "PORT2 connessa " & SerialPort2.PortName
            End If
        Catch
            lblStatus2.Text = "PORT2 non connessa " & SerialPort2.PortName
        Finally
        End Try


    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = 0 To 54
            bufFalli(i) = 0
        Next
        BonusSX = 0
        BonusDX = 0

        bufFalli(0) = &H3F
        bufFalli(1) = BCDconvert(NumeroSX1.Text)
        bufFalli(2) = BCDconvert(NumeroSX2.Text)
        bufFalli(3) = BCDconvert(NumeroSX3.Text)
        bufFalli(4) = BCDconvert(NumeroSX4.Text)
        bufFalli(5) = BCDconvert(NumeroSX5.Text)
        bufFalli(6) = BCDconvert(NumeroSX6.Text)
        bufFalli(7) = BCDconvert(NumeroSX7.Text)
        bufFalli(8) = BCDconvert(NumeroSX8.Text)
        bufFalli(9) = BCDconvert(NumeroSX9.Text)
        bufFalli(10) = BCDconvert(NumeroSX10.Text)
        bufFalli(11) = BCDconvert(NumeroSX11.Text)
        bufFalli(12) = BCDconvert(NumeroSX12.Text)
        bufFalli(13) = BCDconvert(NumeroDX1.Text)
        bufFalli(14) = BCDconvert(NumeroDX2.Text)
        bufFalli(15) = BCDconvert(NumeroDX3.Text)
        bufFalli(16) = BCDconvert(NumeroDX4.Text)
        bufFalli(17) = BCDconvert(NumeroDX5.Text)
        bufFalli(18) = BCDconvert(NumeroDX6.Text)
        bufFalli(19) = BCDconvert(NumeroDX7.Text)
        bufFalli(20) = BCDconvert(NumeroDX8.Text)
        bufFalli(21) = BCDconvert(NumeroDX9.Text)
        bufFalli(22) = BCDconvert(NumeroDX10.Text)
        bufFalli(23) = BCDconvert(NumeroDX11.Text)
        bufFalli(24) = BCDconvert(NumeroDX12.Text)

        bufFalli(54) = &H1
        bufFalli(54) = &H6F
        Try
            Me.SerialPort1.PortName = My.Settings.COM1
            Me.SerialPort2.PortName = My.Settings.COM2
        Catch
        End Try
        If Val(My.Settings.Timeout) <= 0 Then
            My.Settings.Timeout = 3000
        End If
        frmSetupSquadre.Show()
    End Sub



    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        ButtonPiu.Enabled = False
        ButtonMeno.Enabled = False
        NomeSX1.BackColor = SystemColors.Control
        NomeSX2.BackColor = SystemColors.Control
        NomeSX3.BackColor = SystemColors.Control
        NomeSX4.BackColor = SystemColors.Control
        NomeSX5.BackColor = SystemColors.Control
        NomeSX6.BackColor = SystemColors.Control
        NomeSX7.BackColor = SystemColors.Control
        NomeSX8.BackColor = SystemColors.Control
        NomeSX9.BackColor = SystemColors.Control
        NomeSX10.BackColor = SystemColors.Control
        NomeSX11.BackColor = SystemColors.Control
        NomeSX12.BackColor = SystemColors.Control
        NomeDX1.BackColor = SystemColors.Control
        NomeDX2.BackColor = SystemColors.Control
        NomeDX3.BackColor = SystemColors.Control
        NomeDX4.BackColor = SystemColors.Control
        NomeDX5.BackColor = SystemColors.Control
        NomeDX6.BackColor = SystemColors.Control
        NomeDX7.BackColor = SystemColors.Control
        NomeDX8.BackColor = SystemColors.Control
        NomeDX9.BackColor = SystemColors.Control
        NomeDX10.BackColor = SystemColors.Control
        NomeDX11.BackColor = SystemColors.Control
        NomeDX12.BackColor = SystemColors.Control
        NomeSX1.Enabled = True
        NomeSX2.Enabled = True
        NomeSX3.Enabled = True
        NomeSX4.Enabled = True
        NomeSX5.Enabled = True
        NomeSX6.Enabled = True
        NomeSX7.Enabled = True
        NomeSX8.Enabled = True
        NomeSX9.Enabled = True
        NomeSX10.Enabled = True
        NomeSX11.Enabled = True
        NomeSX12.Enabled = True
        NomeDX1.Enabled = True
        NomeDX2.Enabled = True
        NomeDX3.Enabled = True
        NomeDX4.Enabled = True
        NomeDX5.Enabled = True
        NomeDX6.Enabled = True
        NomeDX7.Enabled = True
        NomeDX8.Enabled = True
        NomeDX9.Enabled = True
        NomeDX10.Enabled = True
        NomeDX11.Enabled = True
        NomeDX12.Enabled = True

        Timer2.Enabled = False
        Active = vbNull
    End Sub

    Private Sub ButtonPiu_Click(sender As Object, e As EventArgs) Handles ButtonPiu.Click
        Dim temp As Byte
        Dim i As Byte
        Select Case Active
            Case 1
                If FSX1.ImageIndex < 5 Then
                    FSX1.ImageIndex = FSX1.ImageIndex + 1
                    bufFalli(25) = FSX1.ImageIndex
                End If
            Case 2
                If FSX2.ImageIndex < 5 Then
                    FSX2.ImageIndex = FSX2.ImageIndex + 1
                    bufFalli(26) = FSX2.ImageIndex
                End If
            Case 3
                If FSX3.ImageIndex < 5 Then
                    FSX3.ImageIndex = FSX3.ImageIndex + 1
                    bufFalli(27) = FSX3.ImageIndex
                End If
            Case 4
                If FSX4.ImageIndex < 5 Then
                    FSX4.ImageIndex = FSX4.ImageIndex + 1
                    bufFalli(28) = FSX4.ImageIndex
                End If
            Case 5
                If FSX5.ImageIndex < 5 Then
                    FSX5.ImageIndex = FSX5.ImageIndex + 1
                    bufFalli(29) = FSX5.ImageIndex
                End If
            Case 6
                If FSX6.ImageIndex < 5 Then
                    FSX6.ImageIndex = FSX6.ImageIndex + 1
                    bufFalli(30) = FSX6.ImageIndex
                End If
            Case 7
                If FSX7.ImageIndex < 5 Then
                    FSX7.ImageIndex = FSX7.ImageIndex + 1
                    bufFalli(31) = FSX7.ImageIndex
                End If
            Case 8
                If FSX8.ImageIndex < 5 Then
                    FSX8.ImageIndex = FSX8.ImageIndex + 1
                    bufFalli(32) = FSX8.ImageIndex
                End If
            Case 9
                If FSX9.ImageIndex < 5 Then
                    FSX9.ImageIndex = FSX9.ImageIndex + 1
                    bufFalli(33) = FSX9.ImageIndex
                End If
            Case 10
                If FSX10.ImageIndex < 5 Then
                    FSX10.ImageIndex = FSX10.ImageIndex + 1
                    bufFalli(34) = FSX10.ImageIndex
                End If
            Case 11
                If FSX11.ImageIndex < 5 Then
                    FSX11.ImageIndex = FSX11.ImageIndex + 1
                    bufFalli(35) = FSX11.ImageIndex
                End If
            Case 12
                If FSX12.ImageIndex < 5 Then
                    FSX12.ImageIndex = FSX12.ImageIndex + 1
                    bufFalli(36) = FSX12.ImageIndex
                End If
            Case 13
                If FDX1.ImageIndex < 5 Then
                    FDX1.ImageIndex = FDX1.ImageIndex + 1
                    bufFalli(37) = FDX1.ImageIndex
                End If
            Case 14
                If FDX2.ImageIndex < 5 Then
                    FDX2.ImageIndex = FDX2.ImageIndex + 1
                    bufFalli(38) = FDX2.ImageIndex
                End If
            Case 15
                If FDX3.ImageIndex < 5 Then
                    FDX3.ImageIndex = FDX3.ImageIndex + 1
                    bufFalli(39) = FDX3.ImageIndex
                End If
            Case 16
                If FDX4.ImageIndex < 5 Then
                    FDX4.ImageIndex = FDX4.ImageIndex + 1
                    bufFalli(40) = FDX4.ImageIndex
                End If
            Case 17
                If FDX5.ImageIndex < 5 Then
                    FDX5.ImageIndex = FDX5.ImageIndex + 1
                    bufFalli(41) = FDX5.ImageIndex
                End If
            Case 18
                If FDX6.ImageIndex < 5 Then
                    FDX6.ImageIndex = FDX6.ImageIndex + 1
                    bufFalli(42) = FDX6.ImageIndex
                End If
            Case 19
                If FDX7.ImageIndex < 5 Then
                    FDX7.ImageIndex = FDX7.ImageIndex + 1
                    bufFalli(43) = FDX7.ImageIndex
                End If
            Case 20
                If FDX8.ImageIndex < 5 Then
                    FDX8.ImageIndex = FDX8.ImageIndex + 1
                    bufFalli(44) = FDX8.ImageIndex
                End If
            Case 21
                If FDX9.ImageIndex < 5 Then
                    FDX9.ImageIndex = FDX9.ImageIndex + 1
                    bufFalli(45) = FDX9.ImageIndex
                End If
            Case 22
                If FDX10.ImageIndex < 5 Then
                    FDX10.ImageIndex = FDX10.ImageIndex + 1
                    bufFalli(46) = FDX10.ImageIndex
                End If
            Case 23
                If FDX11.ImageIndex < 5 Then
                    FDX11.ImageIndex = FDX11.ImageIndex + 1
                    bufFalli(47) = FDX11.ImageIndex
                End If
            Case 24
                If FDX12.ImageIndex < 5 Then
                    FDX12.ImageIndex = FDX12.ImageIndex + 1
                    bufFalli(48) = FDX12.ImageIndex
                End If

        End Select
        temp = 0
        For i = 25 To 36
            temp = temp + bufFalli(i)
        Next
        If temp > 5 Then temp = 5
        bufFalli(49) = temp
        temp = 0
        For i = 37 To 48
            temp = temp + bufFalli(i)
        Next
        If temp > 5 Then temp = 5
        bufFalli(50) = temp

        If btnBonusSX.BackColor = SystemColors.Control Then bufFalli(51) = 0 Else bufFalli(51) = 1
        If btnBonusDX.BackColor = SystemColors.Control Then bufFalli(52) = 0 Else bufFalli(52) = 1
        Timer2.Interval = Val(My.Settings.Timeout)
        Timer2.Stop()
        Timer2.Start()

    End Sub

    Private Sub ButtonMeno_Click(sender As Object, e As EventArgs) Handles ButtonMeno.Click
        Dim temp As Byte
        Dim i As Byte
        Select Case Active
            Case 1
                If FSX1.ImageIndex > 0 Then
                    FSX1.ImageIndex = FSX1.ImageIndex - 1
                    bufFalli(25) = FSX1.ImageIndex
                End If
            Case 2
                If FSX2.ImageIndex > 0 Then
                    FSX2.ImageIndex = FSX2.ImageIndex - 1
                    bufFalli(26) = FSX2.ImageIndex
                End If
            Case 3
                If FSX3.ImageIndex > 0 Then
                    FSX3.ImageIndex = FSX3.ImageIndex - 1
                    bufFalli(27) = FSX3.ImageIndex
                End If
            Case 4
                If FSX4.ImageIndex > 0 Then
                    FSX4.ImageIndex = FSX4.ImageIndex - 1
                    bufFalli(28) = FSX4.ImageIndex
                End If
            Case 5
                If FSX5.ImageIndex > 0 Then
                    FSX5.ImageIndex = FSX5.ImageIndex - 1
                    bufFalli(29) = FSX5.ImageIndex
                End If
            Case 6
                If FSX6.ImageIndex > 0 Then
                    FSX6.ImageIndex = FSX6.ImageIndex - 1
                    bufFalli(30) = FSX6.ImageIndex
                End If
            Case 7
                If FSX7.ImageIndex > 0 Then
                    FSX7.ImageIndex = FSX7.ImageIndex - 1
                    bufFalli(31) = FSX7.ImageIndex
                End If
            Case 8
                If FSX8.ImageIndex > 0 Then
                    FSX8.ImageIndex = FSX8.ImageIndex - 1
                    bufFalli(32) = FSX8.ImageIndex
                End If
            Case 9
                If FSX9.ImageIndex > 0 Then
                    FSX9.ImageIndex = FSX9.ImageIndex - 1
                    bufFalli(33) = FSX9.ImageIndex
                End If
            Case 10
                If FSX10.ImageIndex > 0 Then
                    FSX10.ImageIndex = FSX10.ImageIndex - 1
                    bufFalli(34) = FSX10.ImageIndex
                End If
            Case 11
                If FSX11.ImageIndex > 0 Then
                    FSX11.ImageIndex = FSX11.ImageIndex - 1
                End If
            Case 12
                If FSX12.ImageIndex > 0 Then
                    FSX12.ImageIndex = FSX12.ImageIndex - 1
                    bufFalli(36) = FSX12.ImageIndex
                End If
            Case 13
                If FDX1.ImageIndex > 0 Then
                    FDX1.ImageIndex = FDX1.ImageIndex - 1
                    bufFalli(37) = FDX1.ImageIndex
                End If
            Case 14
                If FDX2.ImageIndex > 0 Then
                    FDX2.ImageIndex = FDX2.ImageIndex - 1
                    bufFalli(38) = FDX2.ImageIndex
                End If
            Case 15
                If FDX3.ImageIndex > 0 Then
                    FDX3.ImageIndex = FDX3.ImageIndex - 1
                    bufFalli(39) = FDX3.ImageIndex
                End If
            Case 16
                If FDX4.ImageIndex > 0 Then
                    FDX4.ImageIndex = FDX4.ImageIndex - 1
                    bufFalli(40) = FDX4.ImageIndex
                End If
            Case 17
                If FDX5.ImageIndex > 0 Then
                    FDX5.ImageIndex = FDX5.ImageIndex - 1
                    bufFalli(41) = FDX5.ImageIndex
                End If
            Case 18
                If FDX6.ImageIndex > 0 Then
                    FDX6.ImageIndex = FDX6.ImageIndex - 1
                    bufFalli(42) = FDX6.ImageIndex
                End If
            Case 19
                If FDX7.ImageIndex > 0 Then
                    FDX7.ImageIndex = FDX7.ImageIndex - 1
                    bufFalli(43) = FDX7.ImageIndex
                End If
            Case 20
                If FDX8.ImageIndex > 0 Then
                    FDX8.ImageIndex = FDX8.ImageIndex - 1
                    bufFalli(44) = FDX8.ImageIndex
                End If
            Case 21
                If FDX9.ImageIndex > 0 Then
                    FDX9.ImageIndex = FDX9.ImageIndex - 1
                    bufFalli(45) = FDX9.ImageIndex
                End If
            Case 22
                If FDX10.ImageIndex > 0 Then
                    FDX10.ImageIndex = FDX10.ImageIndex - 1
                    bufFalli(46) = FDX10.ImageIndex
                End If
            Case 23
                If FDX11.ImageIndex > 0 Then
                    FDX11.ImageIndex = FDX11.ImageIndex - 1
                    bufFalli(47) = FDX11.ImageIndex
                End If
            Case 24
                If FDX12.ImageIndex > 0 Then
                    FDX12.ImageIndex = FDX12.ImageIndex - 1
                    bufFalli(48) = FDX12.ImageIndex
                End If

        End Select
        temp = 0
        For i = 25 To 36
            temp = temp + bufFalli(i)
        Next
        If temp > 5 Then temp = 5
        bufFalli(49) = temp
        temp = 0
        For i = 37 To 48
            temp = temp + bufFalli(i)
        Next
        If temp > 5 Then temp = 5
        bufFalli(50) = temp
        Timer2.Interval = Val(My.Settings.Timeout)
        Timer2.Stop()
        Timer2.Start()

    End Sub

    Private Sub Nome_Click(sender As Object, e As EventArgs) Handles NomeSX9.Click, NomeSX8.Click, NomeSX7.Click, NomeSX6.Click, NomeSX5.Click, NomeSX4.Click, NomeSX3.Click, NomeSX2.Click, NomeSX12.Click, NomeSX11.Click, NomeSX10.Click, NomeSX1.Click, NomeDX9.Click, NomeDX8.Click, NomeDX7.Click, NomeDX6.Click, NomeDX5.Click, NomeDX4.Click, NomeDX3.Click, NomeDX2.Click, NomeDX12.Click, NomeDX11.Click, NomeDX10.Click, NomeDX1.Click
        If sender.tag = Active Then
            Call Timer2_Tick(sender, e)
        Else
            NomeSX1.Enabled = False
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
            Timer2.Interval = Val(My.Settings.Timeout)
            Timer2.Enabled = True
            sender.BackColor = Color.Red
            sender.enabled = True
            Active = sender.tag
        End If
    End Sub

    Private Sub btnBonusSX_Click(sender As Object, e As EventArgs) Handles btnBonusSX.Click
        If btnBonusSX.BackColor = SystemColors.Control Then
            btnBonusSX.BackColor = Color.GreenYellow
        Else
            btnBonusSX.BackColor = SystemColors.Control
        End If

    End Sub

    Private Sub btnBonusDX_Click(sender As Object, e As EventArgs) Handles btnBonusDX.Click
        If btnBonusDX.BackColor = SystemColors.Control Then
            btnBonusDX.BackColor = Color.GreenYellow
        Else
            btnBonusDX.BackColor = SystemColors.Control
        End If
    End Sub
End Class
