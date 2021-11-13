Imports System.Net
Public Class Form1
    Dim AppPath = My.Application.Info.DirectoryPath
    Dim tool As String = AppPath + "\LightPad.exe"
    Dim wClient As New WebClient
    Dim newVersion As Boolean
    Dim currentVersion As String
    Dim version As List(Of String) = New List(Of String)
    Dim strLang As String()

    Private Sub getUpdates()
        If IO.File.Exists(tool) Then
            Try
                Process.GetProcessesByName("LightPad")(0).Kill()
                IO.File.Delete(tool)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
        lblProgress.Visible = True
        lblVersion.Text = version(5)
        wClient.DownloadFileAsync(New Uri("https://www.dropbox.com/s/h0r8bn2nufyxcil/LightPad.exe?dl=1"), AppPath + "\LightPad.exe")
        AddHandler wClient.DownloadProgressChanged, AddressOf ProgressChanged
    End Sub

    Private Sub ProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs)
        ProgressBar1.Value = e.ProgressPercentage
        lblProgress.Text = e.ProgressPercentage.ToString + "%"
        newVersionAvailable.BalloonTipTitle = version(4)
        newVersionAvailable.BalloonTipText = version(5) & e.ProgressPercentage.ToString & "%"
        newVersionAvailable.ShowBalloonTip(0)
        If lblProgress.Text = "100%" Then
            MsgBox(version(7))
            newVersionAvailable.BalloonTipTitle = version(6)
            newVersionAvailable.BalloonTipText = version(7)
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
        lblVersion.Text = version(4)
        newVersionAvailable.BalloonTipTitle = version(4)
        newVersionAvailable.BalloonTipText = version(3)
        newVersionAvailable.ShowBalloonTip(0)
        Dim currentProcess As String = "LightPad"
        For Each process As Process In Process.GetProcessesByName(currentProcess)
            Try
                process.Kill()
                lblVersion.Text = version(3)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next
        getUpdates()
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Close()
    End Sub

    Public Sub New(dark As Boolean, details As Color, currentVersion As String, strLang As String())
        InitializeComponent()
        If dark Then
            BackColor = Color.Black
            ForeColor = Color.FromName("Control")
        End If
        LinkLabel1.LinkColor = details
        LinkLabel2.LinkColor = details
        Me.currentVersion = currentVersion
        Me.strLang = strLang
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim request As HttpWebRequest = HttpWebRequest.Create("https://www.dropbox.com/s/08azfq6z77smtom/newestV.txt?dl=1")
        Dim response As HttpWebResponse = request.GetResponse()
        Dim sr As IO.StreamReader = New IO.StreamReader(response.GetResponseStream())
        Dim newestVersion As String = sr.ReadToEnd()
        WindowState = FormWindowState.Minimized
        Timer1.Start()
        changeLanguage()
        If newestVersion > currentVersion Then
            Dim siz As Size = New Size(364, 132)
            Size = siz
            lblVersion.Text = version(1) & newestVersion & vbCrLf & version(2)
            LinkLabel1.Visible = True
            LinkLabel2.Visible = True
            ProgressBar1.Visible = True
            newVersionAvailable.ShowBalloonTip(0)
            newVersion = True
        Else
            Dim siz As Size = New Size(364, 70)
            Size = siz
            lblVersion.Text = version(0)
        End If
    End Sub
    Private Sub changeLanguage()
        For Each c As Control In Controls
            If c.AccessibleDescription <> "" Then
                c.Text = strLang(c.AccessibleDescription)
            End If
        Next
        Text = strLang(67)
        'already new 0
        'new version available 1
        'do you want 2
        'kill process 3
        'updating 4
        'downloading updates 5
        'update 6
        'update complete 7
        For i = 61 To 68
            version.Add(strLang(i))
        Next
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
        If newVersion Then
            yes()
        End If
    End Sub
End Class
