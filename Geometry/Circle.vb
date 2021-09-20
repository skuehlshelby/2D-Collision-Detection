Imports System.Drawing

Public NotInheritable Class Circle
    Implements IShape

    Sub New(radius As Single, color As Color, center As Point, velocity As Vector)
        Me.New(radius, color, center, velocity, Vector.Zero)
    End Sub

    Sub New(radius As Single, color As Color, center As Point, velocity As Vector, acceleration As Vector)
        Me.Radius = radius
        Me.Center = center
        Me.Velocity = velocity
        Me.Acceleration = acceleration
        Me.Color = color
        Diameter = radius * 2
        Mass = radius * radius
    End Sub

    Public ReadOnly Property Radius As Single

    Public ReadOnly Property Diameter As Single

    Public Property Color As Color Implements IShape.Color

    Public Property Center As Point Implements IShape.Center

    Public Property Velocity As Vector Implements IShape.Velocity

    Public Property Acceleration As Vector Implements IShape.Acceleration

    Public Property Mass As Single Implements IShape.Mass

    Public Function Bounds() As Bounds Implements IShape.Bounds
        Return New Bounds((Center.X - Radius, Center.Y - Radius), (Center.X + Radius, Center.Y + Radius))
    End Function

    Public Function Contains(point As Point) As Boolean Implements IShape.Contains
        Return Center.Distance(point) <= Radius
    End Function

    Public Function PointClosestTo(point As Point) As Point Implements IShape.PointClosestTo
        Return Center + (Center - point).ToUnitVec() * Radius
    End Function

    Public Overrides Function ToString() As String
        Return $"{Color.Name} circle at {Center}"
    End Function
End Class