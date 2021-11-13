Public Class Language
    Private Sub Colors_CheckedChanged(sender As Object, e As EventArgs) Handles Defaultrn.CheckedChanged, Purplern.CheckedChanged
        For Each r As RadioButton In GroupBox1.Controls
            If r.Checked Then
                My.Settings.Language = r.TabIndex
                My.Settings.Save()
                My.Settings.Reload()
                Form1.loadCheck()
            End If
        Next
        changeLanguage(My.Settings.langStr)
    End Sub

    Private Sub Language_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        check()
    End Sub
    Private Sub check()
        Select Case My.Settings.Language
            Case 0
                Defaultrn.Checked = True
            Case 1
                Purplern.Checked = True
        End Select
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
        Text = strLang(54)
    End Sub
End Class