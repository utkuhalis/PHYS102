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
        For Each TextBox As Control In TabPage1.Controls
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

    Function CalcWaterQ()
        Try
            If Not Qm.Text = "" And Not Qc.Text = "" And Not QTs.Text = "" And Not QTe.Text = "" Then
                QΔT.Text = Convert.ToDouble(QTs.Text) - Convert.ToDouble(QTe.Text)
                QQ.Text = Convert.ToDouble(Qm.Text) * Convert.ToDouble(Qc.Text) * Convert.ToDouble(QΔT.Text)
            End If
        Catch ex As Exception
            ListBox1.Items.Add(ex.Message)
        End Try
    End Function

    Private Sub Qm_TextChanged(sender As Object, e As EventArgs) Handles Qm.TextChanged
        CalcWaterQ()
    End Sub

    Private Sub Qc_TextChanged(sender As Object, e As EventArgs) Handles Qc.TextChanged
        CalcWaterQ()
    End Sub

    Private Sub QTs_TextChanged(sender As Object, e As EventArgs) Handles QTs.TextChanged
        CalcWaterQ()
    End Sub

    Private Sub QTe_TextChanged(sender As Object, e As EventArgs) Handles QTe.TextChanged
        CalcWaterQ()
    End Sub

    Function CalcWaterIron()
        Try
            If Not WaterM.Text = "" And Not WaterC.Text = "" And Not WaterT.Text = "" And Not IronM.Text = "" And Not IronC.Text = "" And Not IronT.Text = "" Then

                Dim IronResult1 = Convert.ToDouble(IronM.Text) * Convert.ToDouble(IronC.Text)
                Dim IronResult2 = IronResult1 * Convert.ToDouble(IronT.Text)

                Dim WaterResult1 = Convert.ToDouble(WaterM.Text) * Convert.ToDouble(WaterC.Text)
                Dim WaterResult2 = WaterResult1 * Convert.ToDouble(WaterT.Text)

                Return (IronResult2 + WaterResult2) / (IronResult1 + WaterResult1) & "C"
            End If
        Catch ex As Exception
            ListBox1.Items.Add(ex.Message)
        End Try
    End Function

    Private Sub WaterM_TextChanged(sender As Object, e As EventArgs) Handles WaterM.TextChanged
        WIc.Text = CalcWaterIron()
    End Sub

    Private Sub WaterC_TextChanged(sender As Object, e As EventArgs) Handles WaterC.TextChanged
        WIc.Text = CalcWaterIron()
    End Sub

    Private Sub WaterT_TextChanged(sender As Object, e As EventArgs) Handles WaterT.TextChanged
        WIc.Text = CalcWaterIron()
    End Sub

    Private Sub IronM_TextChanged(sender As Object, e As EventArgs) Handles IronM.TextChanged
        WIc.Text = CalcWaterIron()
    End Sub

    Private Sub IronC_TextChanged(sender As Object, e As EventArgs) Handles IronC.TextChanged
        WIc.Text = CalcWaterIron()
    End Sub

    Private Sub IronT_TextChanged(sender As Object, e As EventArgs) Handles IronT.TextChanged
        WIc.Text = CalcWaterIron()
    End Sub

    Function CalcWaterBoil()
        Try
            If Not BoilM.Text = "" And Not BoilC.Text = "" And Not BoilT.Text = "" Then
                Return (Convert.ToDouble(BoilM.Text) * Convert.ToDouble(BoilC.Text) * (100 - Convert.ToDouble(BoilT.Text))) + (Convert.ToDouble(BoilM.Text) * 2260000)
            End If
        Catch ex As Exception
            ListBox1.Items.Add(ex.Message)
        End Try
    End Function

    Private Sub BoilM_TextChanged(sender As Object, e As EventArgs) Handles BoilM.TextChanged
        BoilQ.Text = CalcWaterBoil()
    End Sub

    Private Sub BoilC_TextChanged(sender As Object, e As EventArgs) Handles BoilC.TextChanged
        BoilQ.Text = CalcWaterBoil()
    End Sub

    Private Sub BoilT_TextChanged(sender As Object, e As EventArgs) Handles BoilT.TextChanged
        BoilQ.Text = CalcWaterBoil()
    End Sub

    Function calcWaterSteam()
        Try
            If Not sourceC.Text = "" And Not targetC.Text = "" And Not steamM.Text = "" Then
                ListBox2.Items.Clear()

                Dim IceQ = 0
                Dim LiquidQ = 0
                Dim LiquidingQ = 0
                Dim steamingQ = 0
                Dim steamQ = 0

                For i = Convert.ToDouble(sourceC.Text) To Convert.ToDouble(targetC.Text)
                    If i = Convert.ToDouble(sourceC.Text) Then
                        IceQ = Convert.ToDouble(steamM.Text) * 2090 * (0 - (i))
                        ListBox2.Items.Add(i & "° = " & IceQ)
                    End If

                    If i = 0 Then
                        LiquidQ = Convert.ToDouble(steamM.Text) * 333000
                        ListBox2.Items.Add(i & "° = " & LiquidQ)
                    End If

                    If i = 100 Then
                        LiquidingQ = Convert.ToDouble(steamM.Text) * 4186 * (i - 0)
                        ListBox2.Items.Add(i & "° = " & LiquidingQ)
                    End If

                    If i = 100 Then
                        steamingQ = Convert.ToDouble(steamM.Text) * 2260000
                        ListBox2.Items.Add(i & "° = " & steamingQ)
                    End If

                    If i = Convert.ToDouble(targetC.Text) Then
                        steamQ = Convert.ToDouble(steamM.Text) * 2010 * (i - 100)
                        ListBox2.Items.Add(i & "° = " & steamQ)
                    End If
                Next

                ListBox2.Items.Add("")
                ListBox2.Items.Add("Total Q = " & (IceQ + LiquidQ + LiquidingQ + steamingQ + steamQ))


            End If
        Catch ex As Exception
            ListBox1.Items.Add(ex.Message)
        End Try
    End Function

    Private Sub sourceC_TextChanged(sender As Object, e As EventArgs) Handles sourceC.TextChanged
        calcWaterSteam()
    End Sub

    Private Sub targetC_TextChanged(sender As Object, e As EventArgs) Handles targetC.TextChanged
        calcWaterSteam()
    End Sub

    Private Sub steamM_TextChanged(sender As Object, e As EventArgs) Handles steamM.TextChanged
        calcWaterSteam()
    End Sub
End Class
