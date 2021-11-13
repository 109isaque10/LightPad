﻿Public Class About
    Dim fileName As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\currentV.txt"
    Dim AppPath As String = My.Application.Info.DirectoryPath, Version As String = Application.ProductVersion
    Dim fs As IO.FileStream, Writer As IO.StreamWriter

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Form1.autoUpdate()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("https://icons8.com")
    End Sub

    Private Sub About_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LinkLabel2.Text = "V: " & Version
        LinkLabel1.LinkColor = My.Settings.detailsColor
        LinkLabel2.LinkColor = My.Settings.detailsColor
        changeLanguage(My.Settings.langStr)
    End Sub
    Private Sub changeLanguage(s As String)
        Dim strLang As String()
        strLang = My.Resources.ResourceManager.GetString(s).Split(";")
        For Each c As Control In Controls
            If c.AccessibleDescription <> "" Then
                c.Text = strLang(c.AccessibleDescription)
            End If
        Next
        Text = strLang(57)
    End Sub
End Class