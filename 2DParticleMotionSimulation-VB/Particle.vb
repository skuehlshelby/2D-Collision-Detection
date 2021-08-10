Public NotInheritable Class Particle
    Sub New(radius As Single, color As Color, position As PointF, velocity As PointF, acceleration As PointF)
        Me.Radius = radius
        Me.Position = position
        Me.Velocity = velocity
        Me.Acceleration = acceleration
        Me.Color = color
        Diameter = radius * 2
    End Sub

    Public ReadOnly Property Radius As Single

    Public Readonly Property Diameter As Single

    Public ReadOnly Property Color As Color

    Public Property Position As PointF

    Public Property Velocity As PointF

    Public Property Acceleration As PointF

    Public Function BoundingRectangle() As RectangleF
        Return New RectangleF(Left(), Bottom(), Diameter, Diameter)
    End Function

    Public Sub InvertVelocityHorizontal()
        Velocity = New PointF(Velocity.X * -1, Velocity.Y)
    End Sub

    Public Sub InvertVelocityVertical()
        Velocity = New PointF(Velocity.X, Velocity.Y * -1)
    End Sub

    Public Function Left() As Single
        Return Position.X - Radius
    End Function

    Public Function Right() As Single
        Return Position.X + Radius
    End Function

    Public Function Top() As Single
        Return Position.Y + Radius
    End Function

    Public Function Bottom() As Single
        Return Position.Y - Radius
    End Function

End Class