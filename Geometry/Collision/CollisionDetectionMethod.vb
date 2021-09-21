Imports Geometry.BVH

Namespace Collision
    Public MustInherit Class CollisionDetectionMethod
        Private Sub New(name As String)
            Me.Name = name
        End Sub

        Public ReadOnly Property Name As String

        Public MustOverride Function GetCollisions(bvh As BoundingVolumeHierarchy) As IEnumerable(Of Pair(Of IShape))

        Public MustOverride Function GetCollisions(shapes As IShape(), splitMethod As SplitMethod) As IEnumerable(Of Pair(Of IShape))

        Private Shared Function Overlap(first As IShape, second As IShape) As Boolean
            Return first.Contains(second.PointClosestTo(first.Center))
        End Function

        Private Shared Function AreMovingTowardsEachOther(first As IShape, second As IShape) As Boolean
            Dim relativeVelocity As Vector = second.Velocity - first.Velocity
            Dim displacement As Vector = first.Center - second.Center

            Return relativeVelocity.Dot(displacement) < 0.0F
        End Function

        Public Shared ReadOnly Property Discrete As CollisionDetectionMethod = New DiscreteDetection()

        Public Shared ReadOnly Property Continuous As CollisionDetectionMethod = New ContinuousDetection()

        Public Shared Function Values() As IEnumerable(Of CollisionDetectionMethod)
            Return New CollisionDetectionMethod() { Discrete, Continuous }
        End Function

        Public Shared Function Parse(name As String) As CollisionDetectionMethod
            Return Values().Single(Function(value) value.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
        End Function

        Private Class DiscreteDetection
            Inherits CollisionDetectionMethod

            Public Sub New()
                MyBase.New("Discrete")
            End Sub

            Public Overrides Function GetCollisions(shapes As IShape(), splitMethod As SplitMethod) As IEnumerable(Of Pair(Of IShape))
                Return GetCollisions(New BoundingVolumeHierarchy(shapes, splitMethod))
            End Function

            Public Overrides Function GetCollisions(bvh As BoundingVolumeHierarchy) As IEnumerable(Of Pair(Of IShape))
                Return _
                    bvh.GetCollisionCandidates().Where(
                        Function(candidate) _
                          Overlap(candidate.First, candidate.Second) AndAlso
                          AreMovingTowardsEachOther(candidate.First, candidate.Second))
            End Function
        End Class

        Private Class ContinuousDetection
            Inherits CollisionDetectionMethod

            Public Sub New()
                MyBase.New("Continuous")
            End Sub

            Public Overrides Function GetCollisions(bvh As BoundingVolumeHierarchy) As IEnumerable(Of Pair(Of IShape))
                Throw New NotImplementedException
            End Function

            Public Overrides Function GetCollisions(shapes As IShape(), splitMethod As SplitMethod) As IEnumerable(Of Pair(Of IShape))
                Throw New NotImplementedException
            End Function
        End Class

    End Class
End Namespace