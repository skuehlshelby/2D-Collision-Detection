Imports System.Numerics

Public Structure ParticleII

    Sub New(radius As Single, color As Color, position As PointF, velocity As Vector2)
        Me.New(radius, color, position, velocity, Vector2.Zero) 
    End Sub

    Sub New(radius As Single, color As Color, position As PointF, velocity As Vector2, acceleration As Vector2)
        Me.Radius = radius
        Me.Position = position
        Me.Velocity = velocity
        Me.Acceleration = acceleration
        Me.Color = color
        Diameter = radius * 2
    End Sub

    Public ReadOnly Property Radius As Single

    Public ReadOnly Property Diameter As Single

    Public ReadOnly Property Color As Color

    Public Property Position As PointF

    Public Property Velocity As Vector2

    Public Property Acceleration As Vector2

    Public Function Left() As PointF
        Return New PointF(Position.X - Radius, Position.Y)
    End Function

    Public Function Right() As PointF
        Return New PointF(Position.X - Radius, Position.Y)
    End Function

    Public Function Top() As PointF
        Return New PointF(Position.X, Position.Y + Radius)
    End Function

    Public Function Bottom() As PointF
        Return New PointF(Position.X, Position.Y - Radius)
    End Function

    Public Function Bounds() As RectangleF
        Return New RectangleF(Left().X, Top().Y, Diameter, Diameter)
    End Function

End Structure