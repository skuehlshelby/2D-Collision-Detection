Imports System.Drawing

Public Interface IShape
    Property Center As Point

    Property Velocity As Vector

    Property Acceleration As Vector

    Property Color As Color

    Property Mass As Single

    Function Bounds() As Bounds

    Function Contains(point As Point) As Boolean

    Function PointClosestTo(point As Point) As Point

End Interface