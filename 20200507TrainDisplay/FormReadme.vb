Imports System.IO
Public Class FormReadme
    Private Sub FormReadme_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Text = "請把音檔放在Resource資料夾中，「下一站」和「接近」的檔案分別" + Environment.NewLine _
            + "在檔名最後加上1和2，例如：" + Environment.NewLine _
            + "" + Environment.NewLine _
            + "「下一站 五權」   →    「五權1.wav」" + Environment.NewLine _
            + "「五權 快到了」   →    「五權2.wav」" + Environment.NewLine _
            + " " + Environment.NewLine _
            + "起始站和最終站僅做為顯示之用，不會播報語音。" + Environment.NewLine _
            + " " + Environment.NewLine _
            + "請注意：檔名開頭必須和中文站名相同，「臺」與「台」不能混用" + Environment.NewLine _
            + "，否則會導致程式讀取錯誤。" + Environment.NewLine
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        FormStart.Show()
    End Sub

    Private Sub FormReadme_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If File.Exists("Resource\restart.txt") Then
            File.Delete("Resource\restart.txt")
            Me.Hide()
            FormStart.Show()
        End If
        Timer1.Stop()
    End Sub
End Class