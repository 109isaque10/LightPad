Imports System.Drawing
Imports System.Windows.Forms

Public Class ModernCheckBox
    Inherits CheckBox
    Private cImage = My.Resources.checkbox
    Private uImage = My.Resources.checkboxF
    Public Sub New()
        SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint, True)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim paintingImage As Image
        If Checked Then
            paintingImage = cImage
        Else
            paintingImage = uImage
        End If
        e.Graphics.DrawImage(paintingImage, -2, -1, 17, 17)
    End Sub
End Class
