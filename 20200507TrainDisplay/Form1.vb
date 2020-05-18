'顯示區1224*208
'一個中文字寬度82
Imports System.IO
Public Class Form1
    Dim ChineseStation(FormStart.BusStop) As String ' = {"烏日", "大慶", "五權", "臺中", "精武", "太原"}
    Dim EnglishStation(FormStart.BusStop) As String ' = {"Wuri", "Daqing", "Wuchuan", "Taichung", "Jingwu", "Taiyuan"}
    Dim blink = 0
    Dim second = 0
    Dim StationDisplayTime = 0
    Dim StationID = 0
    Dim DriveTime = 0
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = 1 To FormStart.BusStop
            ChineseStation(i - 1) = FormStart.Controls("TextBox" + (i * 2 - 1).ToString()).Text
            EnglishStation(i - 1) = FormStart.Controls("TextBox" + (i * 2).ToString()).Text
        Next
        UpdateStationName()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        blink += 1
        Label11.Text = Label3.Text & "車站"
        Label12.Text = Label6.Text & " Station"
        If blink = 1 Then
            For i = 1 To 8
                Controls("Label" & i).Visible = False
            Next
            Label9.Visible = True
            Label10.Visible = True
            StationDisplayTime += 1
        End If
        If blink Mod 2 = 0 And blink < 7 Then
            Label11.Visible = True
            Label12.Visible = True
        End If
        If blink Mod 2 = 1 And blink < 7 Then
            Label11.Visible = False
            Label12.Visible = False
        End If
        If blink = 2 And StationDisplayTime = 3 And StationID + 1 <> FormStart.BusStop Then
            Try
                My.Computer.Audio.Play("Resource\" + Label2.Text + "1.wav")
            Catch
            End Try
        End If
        If blink = 7 And StationID + 1 = FormStart.BusStop Then
            If StationID + 1 = FormStart.BusStop Then
                TimerArrive.Stop()
                File.Create("Resource\restart.txt")
                Threading.Thread.Sleep(2000)
                Application.Restart()
            End If
        End If
        If blink = 7 Then
            If StationDisplayTime = 3 Then
                Label3.ForeColor = Color.Chartreuse
                Label6.ForeColor = Color.Chartreuse
                Label2.ForeColor = Color.Red
                Label5.ForeColor = Color.Red
                Label8.ForeColor = Color.Red
                StationDisplayTime = 0
                TimerDrive.Start()
            Else
                TimerSecond.Start()
            End If
            Timer1.Stop()
            blink = 0
            For i = 1 To 8
                Controls("Label" & i).Visible = True
            Next
            Label9.Visible = False
            Label10.Visible = False
            Label11.Visible = False
            Label12.Visible = False
        End If
    End Sub

    Private Sub TimerSecond_Tick(sender As Object, e As EventArgs) Handles TimerSecond.Tick
        second += 1
        If second = 2 And StationDisplayTime < 3 Then
            TimerSecond.Stop()
            second = 0
            Timer1.Start()
        End If
    End Sub

    Private Sub TimerDrive_Tick(sender As Object, e As EventArgs) Handles TimerDrive.Tick
        DriveTime += 1
        Label8.Left -= 1
        If Label8.Left = 598 Then
            Label8.Left = 880
        End If
        Dim ArriveTime = 600
        If DriveTime = ArriveTime Then
            Try
                My.Computer.Audio.Play("Resource\" + Label2.Text + "2.wav")
            Catch
            End Try
        End If
        If DriveTime = ArriveTime + 400 Then
            TimerDrive.Stop()
            DriveTime = 0
            Label8.Left = 880
            TimerArrive.Start()
        End If
    End Sub

    Private Sub TimerArrive_Tick(sender As Object, e As EventArgs) Handles TimerArrive.Tick
        blink += 1
        If blink Mod 2 = 0 Then
            Label2.Visible = False
            Label5.Visible = False
        Else
            Label2.Visible = True
            Label5.Visible = True
        End If
        If blink = 43 Then
            TimerArrive.Stop()
            blink = 0
            UpdateStationName()
            Label3.ForeColor = Color.Red
            Label6.ForeColor = Color.Red
            Label2.ForeColor = Color.Chartreuse
            Label5.ForeColor = Color.Chartreuse
            Label8.ForeColor = Color.Chartreuse
            For i = 1 To 8
                Controls("Label" & i).Visible = False
            Next
            Label9.Visible = True
            Label10.Visible = True
            Timer1.Start()
        End If
    End Sub

    Sub UpdateStationName()
        Label3.Text = ChineseStation(StationID + 0)
        Label2.Text = ChineseStation(StationID + 1)
        Label1.Text = ChineseStation(StationID + 2)
        Label6.Text = EnglishStation(StationID + 0)
        Label5.Text = EnglishStation(StationID + 1)
        Label4.Text = EnglishStation(StationID + 2)
        StationID += 1
        For i = 4 To 6
            If Me.Controls("Label" + i.ToString).Text.Length > 8 Then
                Me.Controls("Label" + i.ToString).Font = New Font(Me.Controls("Label" + i.ToString).Font.FontFamily, 32, Me.Controls("Label" + i.ToString).Font.Style)
            ElseIf Me.Controls("Label" + i.ToString).Text.Length > 6 Then
                Me.Controls("Label" + i.ToString).Font = New Font(Me.Controls("Label" + i.ToString).Font.FontFamily, 38, Me.Controls("Label" + i.ToString).Font.Style)
            Else
                Me.Controls("Label" + i.ToString).Font = New Font(Me.Controls("Label" + i.ToString).Font.FontFamily, 48, Me.Controls("Label" + i.ToString).Font.Style)
            End If
        Next
        If Label3.Text.Length > 3 Then
            Label3.Font = New Font(Label3.Font.FontFamily, 51, Label3.Font.Style)
        Else
            Label3.Font = New Font(Label3.Font.FontFamily, 55, Label3.Font.Style)
        End If
        If Label6.Text.Length > 7 Then
            Label12.Font = New Font(Label12.Font.FontFamily, 40, Label12.Font.Style)
        Else
            Label12.Font = New Font(Label12.Font.FontFamily, 48, Label12.Font.Style)
        End If
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub
End Class
