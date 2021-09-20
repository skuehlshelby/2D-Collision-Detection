Imports Geometry

Public Class SceneInfo
    
    Public Sub New(worldBounds As Bounds)
        Shapes = New List(Of IShape)
        ShapeColors = New List(Of Color) From {Color.CornflowerBlue, Color.Goldenrod, Color.DarkCyan}
        MaxShapeSize = 40
        MaxShapeSpeed = 40
        Me.WorldBounds = worldBounds
    End Sub

    Public ReadOnly Property Shapes As ICollection(Of IShape)

    Public ReadOnly Property ShapeColors As ICollection(Of Color)

    Public Property MaxShapeSize As Integer

    Public Property MaxShapeSpeed As Integer

    Public Property WorldBounds As Bounds

End Class