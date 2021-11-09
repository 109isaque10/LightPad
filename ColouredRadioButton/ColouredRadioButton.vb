Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class ColouredRadioButton
    Inherits RadioButton

    Private m_OnColour As Color
    Private m_OffColour As Color
    Private m_circle As Rectangle
    Private m_outline As Pen

    Public Property OnColour As Color
        Get
            Return m_OnColour
        End Get
        Set(ByVal value As Color)

            If (value = Color.White) OrElse (value = Color.Transparent) Then
                m_OnColour = Color.Empty
            Else
                m_OnColour = value
            End If
        End Set
    End Property

    Public Property OffColour As Color
        Get
            Return m_OffColour
        End Get
        Set(ByVal value As Color)

            If (value = Color.White) OrElse (value = Color.Transparent) Then
                m_OffColour = Color.Empty
            Else
                m_OffColour = value
            End If
        End Set
    End Property

    Public Sub New()
        m_circle = New Rectangle(1, 3, 8.5, 8.5)
        m_outline = New Pen(New SolidBrush(Color.Black), 1.0F)
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        BackColor = Color.Transparent
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias

        If Me.Checked Then

            If OnColour <> Color.Empty Then
                g.FillEllipse(New SolidBrush(OnColour), m_circle)
                g.DrawEllipse(m_outline, m_circle)
            End If
        Else

            If OffColour <> Color.Empty Then
                g.FillEllipse(New SolidBrush(OffColour), m_circle)
                g.DrawEllipse(m_outline, m_circle)
            End If
        End If
    End Sub
End Class
