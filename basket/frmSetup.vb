
Public Class frmSetup
    Private PASSWORD As String = "98765"

    Public Property PASSWORD1 As String
        Get
            Return PASSWORD
        End Get
        Set(value As String)
            PASSWORD = value
        End Set
    End Property

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MTB1.Text = PASSWORD1 Then
            Me.Close()
            frmSetupSquadre.Show()
        End If
    End Sub

    Private Sub MTB1_TextChanged(sender As Object, e As EventArgs) Handles MTB1.TextChanged
        If MTB1.Text = PASSWORD1 Then
            Button1.Enabled = True
            'Button2.Enabled = True
            Button3.Enabled = True
        Else
            Button1.Enabled = False
            'Button2.Enabled = False
            Button3.Enabled = False

        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
        frmSystemSetup.Show()
    End Sub
End Class