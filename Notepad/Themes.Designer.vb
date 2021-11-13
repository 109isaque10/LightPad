<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Themes
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Darkrn = New ModernRadioButton.ModernRadioButton()
        Me.Lightrn = New ModernRadioButton.ModernRadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Redrn = New ModernRadioButton.ModernRadioButton()
        Me.Bluern = New ModernRadioButton.ModernRadioButton()
        Me.Greenrn = New ModernRadioButton.ModernRadioButton()
        Me.Purplern = New ModernRadioButton.ModernRadioButton()
        Me.Defaultrn = New ModernRadioButton.ModernRadioButton()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.AccessibleDescription = "44"
        Me.GroupBox2.Controls.Add(Me.Darkrn)
        Me.GroupBox2.Controls.Add(Me.Lightrn)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 111)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(199, 44)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Theme:"
        '
        'Darkrn
        '
        Me.Darkrn.AccessibleDescription = "46"
        Me.Darkrn.AutoSize = True
        Me.Darkrn.Location = New System.Drawing.Point(137, 21)
        Me.Darkrn.Name = "Darkrn"
        Me.Darkrn.Size = New System.Drawing.Size(48, 17)
        Me.Darkrn.TabIndex = 9
        Me.Darkrn.Text = "Dark"
        Me.Darkrn.UseVisualStyleBackColor = True
        '
        'Lightrn
        '
        Me.Lightrn.AccessibleDescription = "45"
        Me.Lightrn.AutoSize = True
        Me.Lightrn.Location = New System.Drawing.Point(6, 21)
        Me.Lightrn.Name = "Lightrn"
        Me.Lightrn.Size = New System.Drawing.Size(48, 17)
        Me.Lightrn.TabIndex = 8
        Me.Lightrn.Text = "Light"
        Me.Lightrn.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.AccessibleDescription = "38"
        Me.GroupBox1.AccessibleName = ""
        Me.GroupBox1.Controls.Add(Me.Redrn)
        Me.GroupBox1.Controls.Add(Me.Bluern)
        Me.GroupBox1.Controls.Add(Me.Greenrn)
        Me.GroupBox1.Controls.Add(Me.Purplern)
        Me.GroupBox1.Controls.Add(Me.Defaultrn)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 100)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Colors:"
        '
        'Redrn
        '
        Me.Redrn.AccessibleDescription = "43"
        Me.Redrn.AutoSize = True
        Me.Redrn.Location = New System.Drawing.Point(115, 34)
        Me.Redrn.Name = "Redrn"
        Me.Redrn.Size = New System.Drawing.Size(45, 17)
        Me.Redrn.TabIndex = 4
        Me.Redrn.Text = "Red"
        Me.Redrn.UseVisualStyleBackColor = True
        '
        'Bluern
        '
        Me.Bluern.AccessibleDescription = "42"
        Me.Bluern.AutoSize = True
        Me.Bluern.Location = New System.Drawing.Point(115, 11)
        Me.Bluern.Name = "Bluern"
        Me.Bluern.Size = New System.Drawing.Size(46, 17)
        Me.Bluern.TabIndex = 3
        Me.Bluern.Text = "Blue"
        Me.Bluern.UseVisualStyleBackColor = True
        '
        'Greenrn
        '
        Me.Greenrn.AccessibleDescription = "41"
        Me.Greenrn.AutoSize = True
        Me.Greenrn.Location = New System.Drawing.Point(6, 57)
        Me.Greenrn.Name = "Greenrn"
        Me.Greenrn.Size = New System.Drawing.Size(54, 17)
        Me.Greenrn.TabIndex = 2
        Me.Greenrn.Text = "Green"
        Me.Greenrn.UseVisualStyleBackColor = True
        '
        'Purplern
        '
        Me.Purplern.AccessibleDescription = "40"
        Me.Purplern.AutoSize = True
        Me.Purplern.Location = New System.Drawing.Point(6, 34)
        Me.Purplern.Name = "Purplern"
        Me.Purplern.Size = New System.Drawing.Size(55, 17)
        Me.Purplern.TabIndex = 1
        Me.Purplern.Text = "Purple"
        Me.Purplern.UseVisualStyleBackColor = True
        '
        'Defaultrn
        '
        Me.Defaultrn.AccessibleDescription = "39"
        Me.Defaultrn.AutoSize = True
        Me.Defaultrn.Location = New System.Drawing.Point(6, 11)
        Me.Defaultrn.Name = "Defaultrn"
        Me.Defaultrn.Size = New System.Drawing.Size(59, 17)
        Me.Defaultrn.TabIndex = 0
        Me.Defaultrn.Text = "Default"
        Me.Defaultrn.UseVisualStyleBackColor = True
        '
        'Themes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(209, 160)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "Themes"
        Me.Text = "Theme"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Defaultrn As ModernRadioButton.ModernRadioButton
    Friend WithEvents Darkrn As ModernRadioButton.ModernRadioButton
    Friend WithEvents Lightrn As ModernRadioButton.ModernRadioButton
    Friend WithEvents Redrn As ModernRadioButton.ModernRadioButton
    Friend WithEvents Bluern As ModernRadioButton.ModernRadioButton
    Friend WithEvents Greenrn As ModernRadioButton.ModernRadioButton
    Friend WithEvents Purplern As ModernRadioButton.ModernRadioButton
End Class
