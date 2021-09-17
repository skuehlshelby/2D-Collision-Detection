Namespace BVH
    Public Class BoundingVolumeHierarchy

        Private ReadOnly _root As BvhBuildNode

        Public Sub New(shapes As IShape(), splitMethod As SplitMethod)
            _root = Build(shapes, splitMethod)

            Dim results As ICollection(Of IShape()) = New List(Of IShape())()

            GetLeaves(_root, results)

            Leaves = results
        End Sub

        Public ReadOnly Property Leaves As IEnumerable(Of IShape())

        Private Shared Function Build(shapes As IShape(), splitMethod As SplitMethod) As BvhBuildNode
            If shapes.Length > 2 Then
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

            Public Sub New(shapes As IShape())
                Me.Shapes = shapes
                Bounds = Rectangle.Union(shapes.Select(Function(shape) shape.Bounds()))
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

            Public ReadOnly Axis As Axis

            Public ReadOnly Bounds As Rectangle

            Public ReadOnly Left As BvhBuildNode

            Public ReadOnly Right As BvhBuildNode

            Public ReadOnly Shapes As IShape()

            Public ReadOnly IsLeaf As Boolean

        End Class

        Private Shared Sub GetLeaves(node As BvhBuildNode, leaves As ICollection(Of IShape()))
            If node.IsLeaf Then
                leaves.Add(node.Shapes)
            Else
                GetLeaves(node.Left, leaves)
                GetLeaves(node.Right, leaves)
            End If
        End Sub

    End Class
End NameSpace