Imports System.Drawing

Public NotInheritable Class Circle
    Implements IShape

    Sub New(radius As Single, color As Color, center As Point2DF, velocity As Vector2DF)
        Me.New(radius, color, center, velocity, Vector2DF.Zero)
    End Sub

    Sub New(radius As Single, color As Color, center As Point2DF, velocity As Vector2DF, acceleration As Vector2DF)
        Me.Radius = radius
        Me.Center = center
        Me.Velocity = velocity
        Me.Acceleration = acceleration
        Me.Color = color
        Diameter = radius * 2
    End Sub

    Public ReadOnly Property Radius As Single

    Public ReadOnly Property Diameter As Single

    Public Property Color As Color Implements IShape.Color

    Public Property Center As Point2DF Implements IShape.Center

    Public Property Velocity As Vector2DF Implements IShape.Velocity

    Public Property Acceleration As Vector2DF Implements IShape.Acceleration

    Public Function Bounds() As Box2DF Implements IShape.Bounds
        Return New Box2DF((Center.X - Radius, Center.Y + Radius), (Center.X + Radius, Center.Y - Radius))
    End Function

    Public Function Contains(point As Point2DF) As Boolean Implements IShape.Contains
        Return Center.Distance(point) <= Radius
    End Function

    Public Function Clone() As IShape Implements IShape.Clone
        Return New Circle(Radius, Color, Center, Velocity, Acceleration)
    End Function

    Public Function PointClosestTo(point As Point2DF) As Point2DF Implements IShape.PointClosestTo
        Return Center + (point - Center).ToUnitVec() * Radius
    End Function

End Class