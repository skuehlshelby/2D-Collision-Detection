Imports System.Numerics

Public NotInheritable Class Particle
    Sub New(radius As Single, color As Color, position As Vector2, velocity As Vector2)
        Me.New(radius, color, position, velocity, Vector2.Zero) 
    End Sub

    Sub New(radius As Single, color As Color, position As Vector2, velocity As Vector2, acceleration As Vector2)
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

    Public Property Position As Vector2

    Public Property Velocity As Vector2

    Public Property Acceleration As Vector2

    Public Function BoundingRectangle() As RectangleF
        Return New RectangleF(Left(), Bottom(), Diameter, Diameter)
    End Function

    Public Sub InvertVelocityHorizontal()
        Velocity = New Vector2(-Velocity.X, Velocity.Y)
    End Sub

    Public Sub InvertVelocityVertical()
        Velocity = New Vector2(Velocity.X, -Velocity.Y)
    End Sub

    Public Sub Move(changeInTime As Single)
        Position = PositionAtTime(changeInTime)
    End Sub

    Public Function PositionAtTime(changeInTime As Single) As Vector2
        Return Position + New Vector2(Velocity.X * changeInTime, Velocity.Y * changeInTime)
    End Function

    Public Function PointOnEdge(degrees As Single) As Vector2
        Return New Vector2(Position.X + (Radius * CSng(Math.Cos(degrees))), Position.Y + (Radius * CSng(Math.Sin(degrees))))
    End Function

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

#Region "Shared Members"

    Private Shared ReadOnly Random As Random = New Random()

    Public Shared Function GetRandom(maxRadius As Integer, maxVelocity As Integer, containerWidth As Integer, containerHeight As Integer, ParamArray colors As Color()) As Particle
        Return _
            New Particle(Random.Next(2, maxRadius), colors(Random.Next(colors.Length)),
                         New Vector2(Random.Next(maxRadius, containerWidth - maxRadius), Random.Next(maxRadius, containerHeight - maxRadius)),
                         New Vector2(Random.Next(- maxVelocity, maxVelocity), Random.Next(- maxVelocity, maxVelocity)))
    End Function 

#End Region

End Class