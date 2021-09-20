Imports Geometry.BVH
Imports Geometry.Collision

Friend Class RenderOptions
    Sub New(timeStep As Single, paused As Boolean, collisionDetectionMethod As CollisionDetectionMethod, sceneSplitMethod As SplitMethod, showBoundingVolumes As Boolean, calculateRenderTime As Boolean)
        Me.TimeStep = timeStep
        Me.Paused = paused
        Me.CollisionDetectionMethod = collisionDetectionMethod
        Me.SceneSplitMethod = sceneSplitMethod
        Me.ShowBoundingVolumes = showBoundingVolumes
        Me.CalculateRenderTime = calculateRenderTime
        RenderTimeStopwatch = New Stopwatch()
    End Sub

    Public Property TimeStep As Single
    
    Public Property Paused As Boolean

    Public Property CollisionDetectionMethod As CollisionDetectionMethod

    Public Property SceneSplitMethod As SplitMethod

    Public Property ShowBoundingVolumes As Boolean

    Public Property CalculateRenderTime As Boolean

    Public Readonly Property RenderTimeStopwatch As Stopwatch

End Class