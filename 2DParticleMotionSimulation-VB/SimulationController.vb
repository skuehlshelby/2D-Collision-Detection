Imports Geometry
Imports Geometry.BVH

Friend NotInheritable Class SimulationController

    Public Sub New(simulation As Simulation)

    End Sub

    Private Property WorldBounds As Rectangle

    Private Property FrameRate As Integer

    Private Property Colors As IList(Of Color)

    Private Property Particles As IList(Of IShape)

#Region "Diagnostics"

    Private Property Paused As Boolean

    Private Property SceneSplitMethod As SplitMethod

    Private Property ShowBoundingVolumes As Boolean

    Private Property CalculateDrawTime As Boolean

#End Region

End Class