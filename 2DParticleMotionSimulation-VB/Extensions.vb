Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports Geometry

Public Module Extensions

    <Extension()>
    Public Sub SetDoubleBuffered(panel As Panel)
        panel.GetType().InvokeMember("DoubleBuffered",
                                     BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.SetProperty,
                                     Nothing, panel, new Object() {True})
    End Sub

    <Extension()>
    Public Function ToDrawingApi(rect As Bounds, worldHeight As Integer, worldWidth As Integer) As RectangleF
        Return New RectangleF(rect.TopLeft().X, worldHeight - rect.TopLeft().Y, rect.Width(), rect.Height())
    End Function

    <Extension()>
    Public Function ToRectangle(rect As Bounds, worldHeight As Integer) As Rectangle
        Return New Rectangle(CInt(rect.BottomLeft.X), worldHeight - CInt(rect.TopRight.Y), CInt(rect.Width()), CInt(rect.Height()))
    End Function

    <Extension()>
    Public Function ToRectangleF(rect As Bounds, worldHeight As Integer) As RectangleF
        Return New RectangleF(rect.BottomLeft.X, worldHeight - rect.TopRight.Y, rect.Width(), rect.Height())
    End Function

    <Extension()>
    Public Function ToRectangle(rectF As RectangleF) As Rectangle
        Return New Rectangle(CInt(rectF.X), CInt(rectF.Y), CInt(rectF.Width), CInt(rectF.Height))
    End Function

    Public Function GetRandomShape(maxRadius As Integer, maxVelocity As Integer, containerWidth As Integer, containerHeight As Integer, ParamArray colors As Color()) As IShape
        Dim random As Random = New Random()

        Return _
            New Circle(Random.Next(2, maxRadius), colors(Random.Next(colors.Length)),
                         New Point(Random.Next(maxRadius, containerWidth - maxRadius), Random.Next(maxRadius, containerHeight - maxRadius)),
                         New Vector(Random.Next(- maxVelocity, maxVelocity), Random.Next(- maxVelocity, maxVelocity)))
    End Function
End Module