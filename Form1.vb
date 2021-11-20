Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        ListBox1.Items.Add("App start..")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MsgBox(" u Sure? ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ListBox1.Items.Clear()
            ListBox1.Items.Add("App start..")
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        For Each TextBox As Control In Me.Controls
            Try
                If CType(TextBox, TextBox).Name.Contains("Source") Then
                    CType(TextBox, TextBox).Text = New System.Random().Next(10, 100)
                End If
            Catch ex As Exception

            End Try
        Next
    End Sub

    Private Sub FtoC_Source_TextChanged(sender As Object, e As EventArgs) Handles FtoC_Source.TextChanged
        Try
            FtoC_Target.Text = 5 / 9 * (Convert.ToDouble(FtoC_Source.Text) - 32)
        Catch ex As Exception
            ListBox1.Items.Add(ex.Message)
        End Try
    End Sub

    Private Sub FtoK_Source_TextChanged(sender As Object, e As EventArgs) Handles FtoK_Source.TextChanged
        Try
            FtoK_Target.Text = (5 / 9 * (Convert.ToDouble(FtoK_Source.Text) - 32)) + 273.15
        Catch ex As Exception
            ListBox1.Items.Add(ex.Message)
        End Try
    End Sub

    Private Sub CtoF_Source_TextChanged(sender As Object, e As EventArgs) Handles CtoF_Source.TextChanged
        Try
            CtoF_Target.Text = Convert.ToDouble(CtoF_Source.Text) * 9 / 5 + 32
        Catch ex As Exception
            ListBox1.Items.Add(ex.Message)
        End Try
    End Sub

    Private Sub CtoK_Source_TextChanged(sender As Object, e As EventArgs) Handles CtoK_Source.TextChanged
        Try
            CtoK_Target.Text = Convert.ToDouble(CtoK_Source.Text) + 273.15
        Catch ex As Exception
            ListBox1.Items.Add(ex.Message)
        End Try
    End Sub
    Private Sub KtoF_Source_TextChanged(sender As Object, e As EventArgs) Handles KtoF_Source.TextChanged
        Try
            KtoF_Target.Text = (Convert.ToDouble(KtoF_Source.Text) * 9 / 5) - 459.67
        Catch ex As Exception
            ListBox1.Items.Add(ex.Message)
        End Try
    End Sub

    Private Sub KtoC_Source_TextChanged(sender As Object, e As EventArgs) Handles KtoC_Source.TextChanged
        Try
            KtoC_Target.Text = Convert.ToDouble(KtoC_Source.Text) - 273.15
        Catch ex As Exception
            ListBox1.Items.Add(ex.Message)
        End Try
    End Sub

    Private Sub Qm_TextChanged(sender As Object, e As EventArgs) Handles Qm.TextChanged
        Try
            If Not Qm.Text = "" And Not Qc.Text = "" And Not QTs.Text = "" And Not QTe.Text = "" Then
                QΔT.Text = Convert.ToDouble(QTs.Text) - Convert.ToDouble(QTe.Text)
                QQ.Text = Convert.ToDouble(Qm.Text) * Convert.ToDouble(Qc.Text) * Convert.ToDouble(QΔT.Text)
            End If
        Catch ex As Exception
            ListBox1.Items.Add(ex.Message)
        End Try
    End Sub

    Private Sub Qc_TextChanged(sender As Object, e As EventArgs) Handles Qc.TextChanged
        Try
            If Not Qm.Text = "" And Not Qc.Text = "" And Not QTs.Text = "" And Not QTe.Text = "" Then
                QΔT.Text = Convert.ToDouble(QTs.Text) - Convert.ToDouble(QTe.Text)
                QQ.Text = Convert.ToDouble(Qm.Text) * Convert.ToDouble(Qc.Text) * Convert.ToDouble(QΔT.Text)
            End If
        Catch ex As Exception
            ListBox1.Items.Add(ex.Message)
        End Try
    End Sub

    Private Sub QTs_TextChanged(sender As Object, e As EventArgs) Handles QTs.TextChanged
        Try
            If Not Qm.Text = "" And Not Qc.Text = "" And Not QTs.Text = "" And Not QTe.Text = "" Then
                QΔT.Text = Convert.ToDouble(QTs.Text) - Convert.ToDouble(QTe.Text)
                QQ.Text = Convert.ToDouble(Qm.Text) * Convert.ToDouble(Qc.Text) * Convert.ToDouble(QΔT.Text)
            End If
        Catch ex As Exception
            ListBox1.Items.Add(ex.Message)
        End Try
    End Sub

    Private Sub QTe_TextChanged(sender As Object, e As EventArgs) Handles QTe.TextChanged
        Try
            If Not Qm.Text = "" And Not Qc.Text = "" And Not QTs.Text = "" And Not QTe.Text = "" Then
                QΔT.Text = Convert.ToDouble(QTs.Text) - Convert.ToDouble(QTe.Text)
                QQ.Text = Convert.ToDouble(Qm.Text) * Convert.ToDouble(Qc.Text) * Convert.ToDouble(QΔT.Text)
            End If
        Catch ex As Exception
            ListBox1.Items.Add(ex.Message)
        End Try
    End Sub
End Class
