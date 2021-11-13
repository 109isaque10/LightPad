Imports System.IO
Imports System.Resources

Public Class Form1
    Private Const V As Integer = 4
    Dim cache As List(Of String) = New List(Of String)(5), undoNumber As Integer, cacheResume As Boolean
    Dim nadme As String, original As String, path As String
    Dim op As OpenFileDialog = New OpenFileDialog(), sp As SaveFileDialog = New SaveFileDialog()
    Dim AppPath As String = My.Application.Info.DirectoryPath, Version As String = Application.ProductVersion
    Dim fs As IO.FileStream, Writer As IO.StreamWriter
    Dim render As New MyRender(), rectangleSeparator As Rectangle
    Dim feedbackLink As String
    Public Shared strLang() As String
    Public Shared resMan As ResourceManager
    Public Shared au As AutoUpdate.Form1

    Public Shared ReadOnly Property DarkSettings As Boolean
        Get
            Return My.Settings.Dark
        End Get
    End Property
    Public Shared ReadOnly Property DetailColorSettings As Color
        Get
            Return My.Settings.detailsColor
        End Get
    End Property
    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        If RichTextBox1.Text <> "" And RichTextBox1.Text <> original Then
            saveChanges(e, True)
        Else
            Clear()
        End If
    End Sub

    Private Sub Clear()
        original = ""
        RichTextBox1.Text = original
        nadme = "Untitled"
        Text = nadme & " - LightPad"
    End Sub

    Private Sub openFileAs()
        Using op
            If op.ShowDialog() = DialogResult.OK Then
                path = op.FileName
                format()
                Dim fileStream = op.OpenFile()
                read(fileStream)
            End If
        End Using
    End Sub

    Private Sub read(fileStream As FileStream)
        Using reader As StreamReader = New StreamReader(fileStream)
            RichTextBox1.Text = reader.ReadToEnd()
            original = RichTextBox1.Text
        End Using
    End Sub

    Private Sub write(fileStream As FileStream)
        Using writer As StreamWriter = New StreamWriter(fileStream)
            writer.WriteAsync(RichTextBox1.Text)
            original = RichTextBox1.Text
        End Using
    End Sub

    Private Sub format()
        Dim sep() As Char = {"/", "\", "//"}
        nadme = path.Split(sep).Last
        Text = nadme & " - LightPad"
    End Sub

    Private Sub openFile()
        path = Environment.GetCommandLineArgs.GetValue(1)
        Dim fileStream = File.Open(path, FileMode.Open)
        format()
        read(fileStream)
    End Sub

    Private Sub saveFile()
        Try
            Text = nadme & " - LightPad"
            Dim fileStream = File.OpenWrite(path)
            write(fileStream)
        Catch ex As Exception
            saveFileAs()
        End Try
    End Sub

    Private Sub saveFileAs()
        Using sp
            If sp.ShowDialog() = DialogResult.OK Then
                path = sp.FileName()
                format()
                Dim fileStream = sp.OpenFile()
                write(fileStream)
            End If
        End Using
    End Sub

    Private Sub cacheSet()
        If cacheResume Then
            If cache.Count < 5 Then
                cache.Add(RichTextBox1.Text)
            Else
                cache.RemoveAt(0)
                cache.Add(RichTextBox1.Text)
            End If
        End If
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        openFileAs()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        saveFile()
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        saveFileAs()
    End Sub

    Private Sub UndoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem.Click
        undo()
    End Sub

    Private Sub undo()
        If undoNumber > 0 Then
            undoNumber -= 1
        End If
        cacheResume = False
        RichTextBox1.Text = cache(undoNumber)
        cacheResume = True
    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged
        cacheSet()
        notSaved()
    End Sub

    Private Sub notSaved()
        If Not RichTextBox1.Text = original Then
            If Not Text.Contains("*") Then
                Text = "*" & Text
            End If
        Else
            Text = Text.Replace("*", "")
        End If
    End Sub

    Private Sub WordWrapToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WordWrapToolStripMenuItem.Click
        wordWrapCheck()
    End Sub

    Private Sub wordWrapCheck()
        If WordWrapToolStripMenuItem.Checked Then
            RichTextBox1.WordWrap = True
        Else
            RichTextBox1.WordWrap = False
        End If
        My.Settings.WordWrap = WordWrapToolStripMenuItem.Checked
    End Sub

    Private Sub DarkToolStripMenuItem_Click(sender As Object, e As EventArgs)
        darkCheck()
    End Sub

    Public Sub darkCheck()
        Dim control As Color = Color.FromName("Control")
        If My.Settings.Dark Then
            RichTextBox1.BackColor = Color.FromArgb(64, 64, 64)
            RichTextBox1.ForeColor = control
            MyRender.highlightbackcolor = Color.Gray
            MyRender.nonhighlightbackcolor = Color.Black
            MyRender.nonhighlightforecolor = Color.White
            MenuStrip1.BackColor = Color.Black
        Else
            RichTextBox1.BackColor = Color.FromName("Window")
            RichTextBox1.ForeColor = Color.FromName("WindowText")
            MyRender.highlightbackcolor = Color.CornflowerBlue
            MyRender.nonhighlightbackcolor = control
            MyRender.nonhighlightforecolor = Color.Black
            MenuStrip1.BackColor = control
        End If
    End Sub
    Public Sub loadCheck()
        Select Case My.Settings.Theme
            Case 0
                changeTheme(IIf(My.Settings.Dark, New SolidBrush(Color.Gray), New SolidBrush(Color.Black)))
                saveSettings()
            Case 1
                changeTheme(New SolidBrush(Color.BlueViolet))
                saveSettings()
            Case 2
                changeTheme(New SolidBrush(Color.Green))
                saveSettings()
            Case 3
                changeTheme(New SolidBrush(Color.RoyalBlue))
                saveSettings()
            Case 4
                changeTheme(New SolidBrush(Color.IndianRed))
                saveSettings()
        End Select
        Select Case My.Settings.Language
            Case 0
                My.Settings.langStr = "en"
                saveSettings()
                changeLanguage(My.Settings.langStr)
            Case 1
                My.Settings.langStr = "pt"
                saveSettings()
                changeLanguage(My.Settings.langStr)
        End Select
    End Sub
    Private Sub changeLanguage(s As String)
        Dim strLang As String()
        strLang = My.Resources.ResourceManager.GetString(s).Split(";")
        Me.strLang = strLang
        For Each c As ToolStripMenuItem In MenuStrip1.Items
            If c.AccessibleDescription <> "" Then
                c.Text = strLang(c.AccessibleDescription)
                For Each d As ToolStripMenuItem In c.DropDownItems
                    If d.AccessibleDescription <> "" Then
                        d.Text = strLang(d.AccessibleDescription)
                        d.ToolTipText = strLang(d.AccessibleName)
                    End If
                Next
            End If
        Next
        feedbackLink = strLang(58)
        setSize()
    End Sub
    Private Sub changeTheme(s As SolidBrush)
        MyRender.detailsColor = s
        My.Settings.detailsColor = s.Color
    End Sub
    Private Sub saveSettings()
        My.Settings.Save()
        My.Settings.Reload()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.firstTime Then
            File.Delete(AppPath + "\addPermissions.exe")
            File.Delete(AppPath + "\addPermissions.exe.config")
            My.Settings.firstTime = False
            saveSettings()
        End If
        setSize()
        MenuStrip1.Renderer = render
        KeyPreview = True
        cacheResume = True
        prepareFile(op)
        prepareFile(sp)
        If My.Application.CommandLineArgs.Count > 0 Then
            openFile()
        End If
        WordWrapToolStripMenuItem.Checked = My.Settings.WordWrap
        darkCheck()
        wordWrapCheck()
        loadCheck()
        Clear()
        autoUpdate()
    End Sub
    Private Sub setSize()
        ToolStripSeparator1.AutoSize = True
        ToolStripSeparator2.AutoSize = True
        ToolStripSeparator3.AutoSize = True
        ToolStripSeparator1.AutoSize = False
        ToolStripSeparator2.AutoSize = False
        ToolStripSeparator3.AutoSize = False
        ToolStripSeparator1.Size = New Size(ToolStripSeparator1.Width, 6)
        ToolStripSeparator2.Size = New Size(ToolStripSeparator2.Width, 6)
        ToolStripSeparator3.Size = New Size(ToolStripSeparator3.Width, 6)
    End Sub
    Public Shared Sub autoUpdate()
        Try
            au = New AutoUpdate.Form1(My.Settings.Dark, My.Settings.detailsColor, Application.ProductVersion, strLang)
        Catch ex As Exception
            MessageBox.Show("An error ocurred, please give the developer this info: " + vbCrLf + ex.ToString, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub prepareFile(sp As FileDialog)
        sp.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        sp.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        sp.FilterIndex = 1
        sp.RestoreDirectory = True
    End Sub

    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        My.Computer.Clipboard.SetText(RichTextBox1.SelectedText)
        RichTextBox1.SelectedText = ""
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        My.Computer.Clipboard.SetText(RichTextBox1.SelectedText)
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        RichTextBox1.SelectedText = My.Computer.Clipboard.GetText
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If RichTextBox1.Text <> "" And RichTextBox1.Text <> original Then
            saveChanges(e, False)
        End If
    End Sub

    Private Sub RedoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RedoToolStripMenuItem.Click
        redo()
    End Sub

    Private Sub redo()
        If undoNumber < cache.Count - 1 Then
            undoNumber += 1
        End If
        cacheResume = False
        RichTextBox1.Text = cache(undoNumber)
        cacheResume = True
    End Sub

    Private Sub PrintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintToolStripMenuItem.Click
        printDocument()
    End Sub

    Private Sub printDocument()
        PrintDialog1.AllowSomePages = True
        PrintDialog1.Document = PrintDocument1
        Dim result As DialogResult = PrintDialog1.ShowDialog()
        If result = DialogResult.OK Then
            PrintDocument1.Print()
        End If
    End Sub

    Private Sub FindToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FindToolStripMenuItem.Click
        find()
    End Sub

    Private Sub WordWrapToolStripMenuItem_Paint(sender As Object, e As PaintEventArgs) Handles WordWrapToolStripMenuItem.Paint
        Dim selC As Color = IIf(WordWrapToolStripMenuItem.Selected, MyRender.detailsColor.Color, MyRender.nonhighlightbackcolor)
        Select Case WordWrapToolStripMenuItem.Checked
            Case True
                e.Graphics.FillRectangle(New SolidBrush(MyRender.nonhighlightbackcolor), New Rectangle(e.ClipRectangle.X, e.ClipRectangle.Y, 23, e.ClipRectangle.Height))
                e.Graphics.DrawImage(My.Resources.checkmark, New Point(6, 2))
                e.Graphics.FillRectangle(New SolidBrush(selC), New Rectangle(New Point(WordWrapToolStripMenuItem.Font.Size, WordWrapToolStripMenuItem.Height - 1.5), New Size(WordWrapToolStripMenuItem.Font.Size, 2)))
        End Select
    End Sub

    Private Sub LanguageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LanguageToolStripMenuItem.Click
        Dim t As New Language, control As Color = Color.FromName("Control")
        If My.Settings.Dark Then
            t.BackColor = Color.Black
            t.ForeColor = control
            t.GroupBox1.ForeColor = control
        End If
        t.Show()
    End Sub

    Private Sub ThemeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ThemeToolStripMenuItem.Click
        Dim t As New Themes, control As Color = Color.FromName("Control")
        If My.Settings.Dark Then
            t.BackColor = Color.Black
            t.ForeColor = control
            t.GroupBox1.ForeColor = control
            t.GroupBox2.ForeColor = control
        End If
        t.Show()
    End Sub

    Private Sub FeedbackToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FeedbackToolStripMenuItem.Click
        Process.Start(feedbackLink)
    End Sub

    Private Sub find()
        Dim t As New Find, control As Color = Color.FromName("Control")
        If My.Settings.Dark Then
            t.BackColor = Color.Black
            t.ForeColor = control
            t.Button1.BackColor = Color.FromArgb(64, 64, 64, 64)
            t.Button2.BackColor = Color.FromArgb(64, 64, 64, 64)
            t.Button3.BackColor = Color.FromArgb(64, 64, 64, 64)
        End If
        t.Show()
    End Sub

    Private Sub printPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        e.Graphics.DrawString(RichTextBox1.Text, RichTextBox1.Font, Brushes.Black, 100, 100)
    End Sub

    Private Sub saveChanges(e As FormClosingEventArgs, yes As Boolean)
        Dim yesNo As DialogResult = MessageBox.Show("Do you want to save changes to " & nadme & "?", "LightPad", MessageBoxButtons.YesNoCancel)
        If yesNo = DialogResult.Yes Then

            saveFileAs()
        ElseIf yesNo = DialogResult.Cancel And Not yes Then
            e.Cancel = True
        ElseIf yes Then
            Clear()
        End If
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        Dim about As New About
        If My.Settings.Dark Then
            about.BackColor = Color.Black
            about.ForeColor = Color.FromName("Control")
        End If
        about.Show()
    End Sub

    Private Sub FontToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FontToolStripMenuItem.Click
        FontDialog1.ShowColor = True
        FontDialog1.Font = RichTextBox1.Font
        FontDialog1.Color = RichTextBox1.ForeColor
        If FontDialog1.ShowDialog() <> DialogResult.Cancel Then
            RichTextBox1.Font = FontDialog1.Font
            RichTextBox1.ForeColor = FontDialog1.Color
        End If
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Shift And e.KeyCode = Keys.S Then
            saveFileAs()
        End If
        Select Case e.Control.Equals(True) And e.KeyCode
            Case Keys.O
                openFileAs()
            Case Keys.P
                printDocument()
            Case Keys.F
                find()
            Case Keys.Z
                undo()
            Case Keys.Y
                redo()
            Case Keys.N
                If RichTextBox1.Text <> "" And RichTextBox1.Text <> original Then
                    Dim f As EventArgs
                    saveChanges(f, True)
                Else
                    Clear()
                End If
            Case Keys.S
                saveFile()
        End Select
    End Sub
End Class
Public Class MyRender
    Inherits ToolStripProfessionalRenderer
    Shared Property highlightbackcolor As Color = Color.CornflowerBlue
    Shared Property highlightforecolor As Color = Color.White
    Shared Property nonhighlightbackcolor As Color = Color.FromName("Control")
    Shared Property nonhighlightforecolor As Color = Color.Black
    Shared Property detailsColor As SolidBrush = Brushes.Black
    Shared Property menufont As New Font("Segoe UI", 9)
    Protected Overloads Overrides Sub OnRenderMenuItemBackground(ByVal e As ToolStripItemRenderEventArgs)
        Dim rc As New Rectangle(Point.Empty, e.Item.Size)
        Dim selC As Color = IIf(e.Item.Selected, detailsColor.Color, nonhighlightbackcolor)
        Dim foreC As Color = IIf(e.Item.Selected, nonhighlightforecolor, nonhighlightforecolor)
        Using brush As New SolidBrush(nonhighlightbackcolor)
            e.Graphics.FillRectangle(brush, rc)
            If e.Item.Name.Contains("Separator") Then
                e.Graphics.DrawLine(New Pen(detailsColor), 6, CInt(e.Item.Height / 4), e.Item.Width - 6, CInt(e.Item.Height / 4))
            Else
                e.Graphics.FillRectangle(New SolidBrush(selC), New Rectangle(New Point(e.Item.Font.Size, e.Item.Height - 1.5), New Size(e.Item.Font.Size, 2)))
            End If
        End Using
        e.Item.ForeColor = foreC
        e.Item.Font = menufont
    End Sub
    Protected Overrides Sub OnRenderToolStripBorder(e As ToolStripRenderEventArgs)
        MyBase.OnRenderToolStripBorder(e)
        e.Graphics.FillRectangle(New SolidBrush(nonhighlightbackcolor), New Rectangle(New Point(0, e.ToolStrip.Height - 2), New Size(e.ToolStrip.Width, 2)))
        e.Graphics.DrawRectangle(New Pen(New SolidBrush(nonhighlightbackcolor)), New Rectangle(0, 1, e.AffectedBounds.Width, e.AffectedBounds.Height - 3))
        e.Graphics.FillRectangle(New SolidBrush(nonhighlightbackcolor), e.ConnectedArea)
        e.Graphics.FillRectangle(detailsColor, New Rectangle(e.ConnectedArea.X + 5, e.ConnectedArea.Y, e.ConnectedArea.Width - 10, e.ConnectedArea.Height))
    End Sub
    Public Sub New()
        MyBase.New(New colors)
    End Sub
End Class

Public Class colors
    Inherits ProfessionalColorTable
    Public Overrides ReadOnly Property MenuBorder() As Color
        Get
            Return MyRender.nonhighlightbackcolor
        End Get
    End Property
End Class