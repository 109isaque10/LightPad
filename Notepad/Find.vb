Public Class Find
    Dim position As Integer = 0
    Dim final As Integer = 0
    Dim f As Integer = 0
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        findButton()
    End Sub

    Private Sub findButton()
        If CheckBox1.Checked Then
            find(RichTextBoxFinds.None, StringComparison.InvariantCulture)
        ElseIf CheckBox2.Checked And CheckBox1.Checked Then
            find(RichTextBoxFinds.Reverse, StringComparison.InvariantCulture)
        ElseIf CheckBox2.Checked Then
            find(RichTextBoxFinds.Reverse, StringComparison.InvariantCultureIgnoreCase)
        Else
            find(RichTextBoxFinds.None, StringComparison.InvariantCultureIgnoreCase)
        End If
    End Sub

    Private Sub find(find As RichTextBoxFinds, find2 As StringComparison)
        final = Form1.RichTextBox1.Text.LastIndexOf(TextBox1.Text, find2)
        If final = -1 Then
            MessageBox.Show(Me, "Nothing found! Are you sure you typed it correctly?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf TextBox1.Text = "" Then
            MessageBox.Show(Me, "You haven´t typed anything!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If position < final Then
                findFormat(find, find2)
            Else
                position = 0
                findFormat(find, find2)
            End If
        End If
    End Sub

    Private Sub findFormat(find As RichTextBoxFinds, find2 As StringComparison)
        Form1.RichTextBox1.Find(TextBox1.Text, position, -1, find)
        MsgBox(final & ":" & position)
        Form1.RichTextBox1.Focus()
        position = Form1.RichTextBox1.Text.IndexOf(TextBox1.Text, position, find2) + 1
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        position = 0
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        findButton()
        replace()
        f = 0
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Do While True
            findButton()
            replace()
            f = 0
            If f = final - 1 Then
                Exit Do
            End If
        Loop
    End Sub

    Private Sub replace()
        If f < final Then
            Form1.RichTextBox1.SelectedText = TextBox2.Text
            f += 1
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            findButton()
        End If
    End Sub
End Class