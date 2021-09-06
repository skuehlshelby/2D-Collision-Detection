Imports System.Drawing

Public Interface IShape
    Property Center As Point2DF

    Property Velocity As Vector2DF

    Property Acceleration As Vector2DF

    Property Color As Color

    Function Bounds() As Box2DF

    Function Contains(point As Point2DF) As Boolean

    Function Clone() As IShape

    Function PointClosestTo(point As Point2DF) As Point2DF

End Interface