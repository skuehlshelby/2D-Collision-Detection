Imports Geometry.BVH

Namespace Collision
    Public MustInherit Class CollisionDetectionMethod
        Private Sub New(name As String)
            Me.Name = name
        End Sub

        Public ReadOnly Property Name As String

        Public Shared Function Values() As IEnumerable(Of CollisionDetectionMethod)

        End Function

        Public Shared Function Parse(name As String) As CollisionDetectionMethod
            Return Values().Single(Function(value) value.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
        End Function

        Public MustOverride Function GetWallCollisions(shapes As IShape()) As IEnumerable(Of IShape)

        Public MustOverride Function GetShapeCollisions(shapes As IShape(), splitMethod As SplitMethod) As ICollection(Of IShape())

        Private Class DiscreteDetection
            Inherits CollisionDetectionMethod

            Public Sub New()
                MyBase.New("Discrete")
            End Sub


        End Class

        Private Class ContinuousDetection
            Inherits CollisionDetectionMethod

            Public Sub New()
                MyBase.New("Continuous")
            End Sub

        End Class

    End Class
End Namespace