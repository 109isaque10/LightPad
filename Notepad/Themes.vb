Imports System.Windows.Forms

Public Class Themes
    Private Sub Theme_CheckedChanged(sender As Object, e As EventArgs) Handles Lightrn.CheckedChanged, Darkrn.CheckedChanged
        My.Settings.Dark = Darkrn.Checked
        My.Settings.Save()
        My.Settings.Reload()
        Form1.loadCheck()
        Form1.darkCheck()
        If My.Settings.Dark Then
            BackColor = Color.Black
            ForeColor = Color.FromName("Control")
            GroupBox1.ForeColor = Color.FromName("Control")
            GroupBox2.ForeColor = Color.FromName("Control")
        Else
            BackColor = DefaultBackColor
            ForeColor = DefaultForeColor
            GroupBox1.ForeColor = DefaultForeColor
            GroupBox2.ForeColor = DefaultForeColor
        End If
    End Sub

    Private Sub Colors_CheckedChanged(sender As Object, e As EventArgs) Handles Defaultrn.CheckedChanged, Purplern.CheckedChanged, Greenrn.CheckedChanged, Bluern.CheckedChanged, Redrn.CheckedChanged
        For Each r As RadioButton In GroupBox1.Controls
            If r.Checked Then
                My.Settings.Theme = r.TabIndex
                My.Settings.Save()
                My.Settings.Reload()
                Form1.loadCheck()
            End If
        Next
    End Sub

    Private Sub Themes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        check()
    End Sub
    Private Sub check()
        Select Case My.Settings.Theme
            Case 0
                Defaultrn.Checked = True
            Case 1
                Purplern.Checked = True
            Case 2
                Greenrn.Checked = True
            Case 3
                Bluern.Checked = True
            Case 4
                Redrn.Checked = True
        End Select
        If My.Settings.Dark Then
            Darkrn.Checked = True
        Else
            Lightrn.Checked = True
        End If
        changeLanguage(My.Settings.langStr)
    End Sub
    Private Sub changeLanguage(s As String)
        Dim strLang As String()
        strLang = My.Resources.ResourceManager.GetString(s).Split(";")
        For Each c As Control In Controls
            If c.AccessibleDescription <> "" Then
                c.Text = strLang(c.AccessibleDescription)
                If c.Name.Contains("Group") Then
                    For Each d As Control In c.Controls
                        d.Text = strLang(d.AccessibleDescription)
                    Next
                End If
            End If
        Next
        Text = strLang(47)
    End Sub
End Class