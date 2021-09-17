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
    Public Function ToDrawingApi(rect As Rectangle, worldHeight As Integer, worldWidth As Integer) As RectangleF
        Return New RectangleF(rect.TopLeft.X, worldHeight - rect.TopLeft.Y, rect.Width(), rect.Height())
    End Function

    
    Public Function GetRandomShape(maxRadius As Integer, maxVelocity As Integer, containerWidth As Integer, containerHeight As Integer, ParamArray colors As Color()) As IShape
        Dim random As Random = New Random()

        Return _
            New Circle(Random.Next(2, maxRadius), colors(Random.Next(colors.Length)),
                         New Point(Random.Next(maxRadius, containerWidth - maxRadius), Random.Next(maxRadius, containerHeight - maxRadius)),
                         New Vector(Random.Next(- maxVelocity, maxVelocity), Random.Next(- maxVelocity, maxVelocity)))
    End Function
End Module