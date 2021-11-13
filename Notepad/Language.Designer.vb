<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Language
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Purplern = New ModernRadioButton.ModernRadioButton()
        Me.Defaultrn = New ModernRadioButton.ModernRadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.AccessibleDescription = "48"
        Me.GroupBox1.Controls.Add(Me.Purplern)
        Me.GroupBox1.Controls.Add(Me.Defaultrn)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(161, 58)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Languages:"
        '
        'Purplern
        '
        Me.Purplern.AccessibleDescription = "50"
        Me.Purplern.AutoSize = True
        Me.Purplern.Location = New System.Drawing.Point(6, 38)
        Me.Purplern.Name = "Purplern"
        Me.Purplern.Size = New System.Drawing.Size(79, 17)
        Me.Purplern.TabIndex = 1
        Me.Purplern.Text = "Portuguese"
        Me.Purplern.UseVisualStyleBackColor = True
        '
        'Defaultrn
        '
        Me.Defaultrn.AccessibleDescription = "49"
        Me.Defaultrn.AutoSize = True
        Me.Defaultrn.Location = New System.Drawing.Point(6, 15)
        Me.Defaultrn.Name = "Defaultrn"
        Me.Defaultrn.Size = New System.Drawing.Size(102, 17)
        Me.Defaultrn.TabIndex = 0
        Me.Defaultrn.Text = "Default (English)"
        Me.Defaultrn.UseVisualStyleBackColor = True
        '
        'Language
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(165, 63)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "Language"
        Me.Text = "Language"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Purplern As ModernRadioButton.ModernRadioButton
    Friend WithEvents Defaultrn As ModernRadioButton.ModernRadioButton
End Class
