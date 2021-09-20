Imports Geometry
Imports Geometry.BVH
Imports Geometry.Collision

Friend NotInheritable Class SimulationController
    
    Public Sub New(timeStep As Single, sceneHeight As Integer, sceneWidth As Integer)
        options = New RenderOptions(timeStep, False, CollisionDetectionMethod.Discrete, SplitMethod.Midpoint, False, False)
        info = New SceneInfo(New Bounds((0.0F, 0.0F), (sceneWidth, sceneHeight)))
        model = New SimulationModel()
    End Sub

    Private options As RenderOptions
    Private info As SceneInfo
    Private model As SimulationModel

    Public Property Paused As Boolean
        Get
            Return options.Paused
        End Get
        Set
            options.Paused = value
        End Set
    End Property

    Public Property ShowBoundingVolumes As Boolean
        Get
            Return options.ShowBoundingVolumes
        End Get
        Set
            options.ShowBoundingVolumes = value
        End Set
    End Property

    Public Property CalculateRenderTime As Boolean
        Get
            Return options.CalculateRenderTime
        End Get
        Set
            options.CalculateRenderTime = value
        End Set
    End Property

    Public Function GetSceneSplitMethods() As IEnumerable(Of String)
        Return SplitMethod.Values().Select(Function(method) method.Name)
    End Function

    Public Sub SetSceneSplitMethod(method As String)
        options.SceneSplitMethod = SplitMethod.Parse(method)
    End Sub

    Public Function GetCollisionDetectionMethods() As IEnumerable(Of String)
        Return CollisionDetectionMethod.Values().Select(Function(method) method.Name)
    End Function

    Public Sub SetCollisionDetectionMethod(method As String)
        options.CollisionDetectionMethod = CollisionDetectionMethod.Parse(method)
    End Sub

    Public Function GetScene() As Queue(Of Action(Of Graphics))
        Return model.GetScene(options, info)
    End Function

    Public Sub SetNumberOfShapes(count As Integer)
        model.UpdateShapeCount(count, info)
    End Sub

    Public Sub SetWorldSize(height As Integer, width As Integer)
        info.WorldBounds = New Bounds((0.0F, 0.0F), New Point(width, height))
        model.RestrictShapes(info.WorldBounds, info.Shapes)
    End Sub

    Public Sub UpdateTimeStep(newTimeStep As Single)
        options.TimeStep = newTimeStep
    End Sub

End Class