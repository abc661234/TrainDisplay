Imports System.IO
'Icons made by <a href="https://www.flaticon.com/authors/smashicons" title="Smashicons">Smashicons</a> from <a href="https://www.flaticon.com/" title="Flaticon"> www.flaticon.com</a>
Class FormStart
    Public BusStop As Integer = 0
    Private Sub FormStart_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReadFile()
    End Sub

    Sub AddStop()
        Me.AutoScroll = False
        BusStop += 1
        If BusStop <> 2 Then
            Try
                Me.Controls("Label" + ((BusStop - 2) * 4 + 3).ToString()).Text = "　　　"
            Catch
            End Try
        End If
        For i = (BusStop - 1) * 4 To (BusStop - 1) * 4 + 3
            Dim lb As Label = New Label
            lb.Name = "Label" + (i + 1).ToString()
            If i Mod 4 = 0 Then
                lb.Text = "中文："
            ElseIf i Mod 4 = 1 Then
                lb.Text = "英文："
            ElseIf i Mod 4 = 2 Then
                If BusStop = 1 Then
                    lb.Text = "　　　      (起始站不播報)"
                Else
                    lb.Text = "　　　      (最終站不播報)"
                End If
            End If
            If i Mod 4 <> 3 Then
                lb.Location = New Point(35, (i + 1) * 50 - (BusStop - 1) * 50)
            Else
                lb.Location = New Point(242, i * 50 - (BusStop - 1) * 50 - 4)
                lb.Size = New Size(500, 100)
                lb.Font = New Font(Font.FontFamily, 12, FontStyle.Regular)
            End If
            Me.Controls.Add(lb)
            lb.BringToFront()
            lb.AutoSize = True
        Next
        For i = (BusStop - 1) * 2 To (BusStop - 1) * 2 + 1
            Dim tb As TextBox = New TextBox
            tb.Name = "TextBox" + (i + 1).ToString()
            tb.Location = New Point(130, 46 + i * 50 + (BusStop - 1) * 50)
            tb.Size = New Size(266, 35)
            If i Mod 2 = 1 Then
                tb.ImeMode = ImeMode.Off
            End If
            Me.Controls.Add(tb)
            tb.BringToFront()
        Next
        Me.AutoScroll = True
        Me.AutoScrollPosition = New Point(0, 100000)
    End Sub

    Private Sub Label500_Click(sender As Object, e As EventArgs) Handles Label500.Click
        Label500.Top += 150
        Label600.Top += 150
        AddStop()
        If BusStop > 1 Then
            Label600.Visible = True
        Else
            Label600.Visible = False
        End If
    End Sub

    Private Sub Label600_Click(sender As Object, e As EventArgs) Handles Label600.Click
        Label500.Top -= 150
        Label600.Top -= 150
        Me.AutoScroll = False
        Dim rm As Control
        Me.AutoScroll = False
        For i = (BusStop - 1) * 4 To (BusStop - 1) * 4 + 3
            rm = Me.Controls("Label" + (i + 1).ToString())
            Me.Controls.Remove(rm)
        Next
        For i = (BusStop - 1) * 2 To (BusStop - 1) * 2 + 1
            rm = Me.Controls("TextBox" + (i + 1).ToString())
            Me.Controls.Remove(rm)
        Next
        Try
            Me.Controls("Label" + ((BusStop - 2) * 4 + 3).ToString).Text = "　　　      (最終站不播報)"
        Catch
        End Try
        BusStop -= 1
        Me.AutoScroll = True
        Me.AutoScrollPosition = New Point(0, 100000)
        If BusStop > 3 Then
            Label600.Visible = True
        Else
            Label600.Visible = False
        End If
    End Sub

    Private Sub Button100_Click(sender As Object, e As EventArgs) Handles Button100.Click
        Dim sw As StreamWriter = New StreamWriter("Resource\info.txt")
        sw.WriteLine(BusStop)
        Dim str As String
        For i = 1 To BusStop
            str = "TextBox" + (i * 2 - 1).ToString()
            sw.WriteLine(Me.Controls(str).Text)
            str = "TextBox" + (i * 2).ToString()
            sw.WriteLine(Me.Controls(str).Text)
        Next
        sw.Close()
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub FormStart_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    Private Sub Button200_Click(sender As Object, e As EventArgs) Handles Button200.Click
        Dim DirInfo As IO.DirectoryInfo
        DirInfo = New IO.DirectoryInfo("Test")
        For Each file In DirInfo.GetFiles("*", IO.SearchOption.TopDirectoryOnly)
            If file.Name <> "credit.txt" Then
                file.CopyTo("Resource\" + file.Name, True)
            End If
        Next file
        While BusStop > 0
            Label600_Click(Nothing, Nothing)
        End While
        ReadFile()
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub ReadFile()
        Dim count As Integer
        Dim sr As StreamReader
        If File.Exists("Resource\info.txt") Then
            Try
                sr = New StreamReader("Resource\info.txt")
                count = sr.ReadLine()
            Catch
            End Try
        End If
        If count < 3 Then
            count = 3
        End If
        For i = 0 To count - 1
            If i >= 3 Then
                Label500.Top += 150
                Label600.Top += 150
                Label600.Visible = True
            End If
            AddStop()
        Next
        For i = 1 To count * 2
            Try
                Me.Controls("TextBox" + i.ToString()).Text = sr.ReadLine()
            Catch
            End Try
        Next
        Try
            sr.Close()
        Catch
        End Try
    End Sub
End Class