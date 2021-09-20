Namespace BVH
    Public Class BoundingVolumeHierarchy

        Public Interface IBvhNode

            ReadOnly Property Shapes As IShape()

            ReadOnly Property Bounds As Bounds

        End Interface

        Private ReadOnly _root As BvhBuildNode

        Public Sub New(shapes As IShape(), splitMethod As SplitMethod)
            _root = Build(shapes, splitMethod)

            Dim results As ICollection(Of IBvhNode) = New List(Of IBvhNode)()

            GetLeaves(_root, results)

            Leaves = results
        End Sub

        Public ReadOnly Property Leaves As IEnumerable(Of IBvhNode)

        Private Shared Function Build(shapes As IShape(), splitMethod As SplitMethod) As BvhBuildNode
            If shapes.Length > 1 Then
                Dim result As SplitResult = splitMethod.Split(shapes)

                If result.Failed Then
                    Return New BvhBuildNode(shapes)
                Else
                    Return new BvhBuildNode(result.SplitAxis, Build(result.FirstHalf, splitMethod), Build(result.SecondHalf, splitMethod))
                End If
            Else
                Return New BvhBuildNode(shapes)
            End If
        End Function

        Private Class BvhBuildNode
            Implements IBvhNode
            Public Sub New(shapes As IShape())
                Me.Shapes = shapes
                Bounds = Bounds.Union(shapes.Select(Function(shape) shape.Bounds()))
                Left = Nothing
                Right = Nothing
                Axis = Nothing
                IsLeaf = True
            End Sub

            Public Sub New(axis As Axis, left As BvhBuildNode, right As BvhBuildNode)
                Me.Axis = axis
                Me.Left = left
                Me.Right = right
                Bounds = left.Bounds.Union(right.Bounds)
                Shapes = Nothing
                IsLeaf = False
            End Sub

            Public ReadOnly Property Axis As Axis

            Public ReadOnly Property Bounds As Bounds Implements IBvhNode.Bounds

            Public ReadOnly Property Left As BvhBuildNode

            Public ReadOnly Property Right As BvhBuildNode

            Public ReadOnly Property Shapes As IShape() Implements IBvhNode.Shapes

            Public ReadOnly Property IsLeaf As Boolean

        End Class

        Private Shared Sub GetLeaves(node As BvhBuildNode, leaves As ICollection(Of IBvhNode))
            If node.IsLeaf Then
                leaves.Add(node)
            Else
                GetLeaves(node.Left, leaves)
                GetLeaves(node.Right, leaves)
            End If
        End Sub

    End Class
End NameSpace