Imports System.Net

Public Class Form1
    Dim AppPath = My.Application.Info.DirectoryPath
    Dim tool As String = AppPath + "\LightPad.exe"
    Dim wClient As New WebClient

    Private Sub getUpdates()
        If IO.File.Exists(tool) Then
            Try
                IO.File.Delete(tool)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
        lblProgress.Visible = True
        lblVersion.Text = "Downloading newest version.."
        wClient.DownloadFileAsync(New Uri("https://www.dropbox.com/s/h0r8bn2nufyxcil/LightPad.exe?dl=1"), AppPath + "\LightPad.exe")
        AddHandler wClient.DownloadProgressChanged, AddressOf ProgressChanged
    End Sub

    Private Sub ProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs)
        ProgressBar1.Value = e.ProgressPercentage
        lblProgress.Text = e.ProgressPercentage.ToString + "%"
        newVersionAvailable.BalloonTipTitle = "Updating.."
        newVersionAvailable.BalloonTipText = "Downloading updates.. " & e.ProgressPercentage.ToString & "%"
        newVersionAvailable.ShowBalloonTip(0)
        If lblProgress.Text = "100%" Then
            MsgBox("Sucessfully updated!")
            newVersionAvailable.BalloonTipTitle = "Update Completed!"
            newVersionAvailable.BalloonTipText = "Sucessfully updated!"
            newVersionAvailable.ShowBalloonTip(0)
            Process.Start(AppPath + "\LightPad.exe")
            Close()
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        yes()
    End Sub

    Private Sub yes()
        LinkLabel1.Visible = False
        LinkLabel2.Visible = False
        lblVersion.Text = "Updating.."
        newVersionAvailable.BalloonTipTitle = "Updating.."
        newVersionAvailable.BalloonTipText = "Killing old process.."
        newVersionAvailable.ShowBalloonTip(0)
        Dim currentProcess As String = "LightPad"
        For Each process As Process In Process.GetProcessesByName(currentProcess)
            Try
                process.Kill()
                lblVersion.Text = "Killing old process.."
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next
        getUpdates()
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Close()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim request As HttpWebRequest = HttpWebRequest.Create("https://www.dropbox.com/s/08azfq6z77smtom/newestV.txt?dl=1")
        Dim response As HttpWebResponse = request.GetResponse()
        Dim sr As IO.StreamReader = New IO.StreamReader(response.GetResponseStream())
        Dim newestVersion As String = sr.ReadToEnd()
        Dim currentVersion As String = My.Computer.FileSystem.ReadAllText(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\currentV.txt")
        WindowState = FormWindowState.Minimized
        Timer1.Start()
        If newestVersion > currentVersion Then
            Dim siz As Size = New Size(364, 132)
            Size = siz
            lblVersion.Text = "There is a new version available: " & newestVersion & vbCrLf & "Do you want to update?"
            LinkLabel1.Visible = True
            LinkLabel2.Visible = True
            ProgressBar1.Visible = True
            newVersionAvailable.ShowBalloonTip(0)
        Else
            Dim siz As Size = New Size(364, 70)
            Size = siz
            lblVersion.Text = "You´re already in the newest version available!"
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub ShowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowToolStripMenuItem.Click
        Show()
        WindowState = FormWindowState.Normal
    End Sub

    Private Sub HideToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HideToolStripMenuItem.Click
        Hide()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        Hide()
    End Sub

    Private Sub newVersionAvailable_MouseClick(sender As Object, e As MouseEventArgs) Handles newVersionAvailable.MouseDoubleClick
        If newVersionAvailable.BalloonTipTitle = "Update Available!" Then
            yes()
        End If
    End Sub

    Public Sub closeForm1()
        Close()
    End Sub
End Class
