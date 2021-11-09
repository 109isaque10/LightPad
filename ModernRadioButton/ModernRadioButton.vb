Imports System.Drawing
Imports System.Windows.Forms

Public Class ModernRadioButton
    Inherits RadioButton
    Private cImage = My.Resources.checked
    Private uImage = My.Resources.unchecked
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
        e.Graphics.DrawImage(paintingImage, 0, 2, 13, 13)
    End Sub
End Class
