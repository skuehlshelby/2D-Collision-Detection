Namespace BVH
    Public Class BoundingVolumeHierarchy

        Private ReadOnly _root As BvhBuildNode

        Public Sub New(shapes As IShape(), splitMethod As SplitMethod)
            _root = Build(shapes, splitMethod)
        End Sub

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

            Public ReadOnly Property Bounds As Bounds

            Public ReadOnly Property Left As BvhBuildNode

            Public ReadOnly Property Right As BvhBuildNode

            Public ReadOnly Property Shapes As IShape()

            Public ReadOnly Property IsLeaf As Boolean

        End Class

        Public Function GetBoundingVolumes() As IEnumerable(Of Bounds)
            Dim volumes As ICollection(Of Bounds) = New List(Of Bounds)()

            If _root IsNot Nothing AndAlso Not _root.IsLeaf Then
                GetVolumes(_root.Left, _root.Right, volumes)
            End If 

            Return volumes
        End Function

        Private Sub GetVolumes(left As BvhBuildNode, right As BvhBuildNode, volumes As ICollection(Of Bounds))
            volumes.Add(left.Bounds)
            volumes.Add(right.Bounds)

            If Not left.IsLeaf Then
                GetVolumes(left.Left, left.Right, volumes)
            End If

            If Not right.IsLeaf Then
                GetVolumes(right.Left, right.Right, volumes)
            End If
        End Sub

        Public Function GetCollisionCandidates() As ICollection(Of Pair(Of IShape))
            Dim results As ICollection(Of Pair(Of IShape)) = New List(Of Pair(Of IShape))()

            If _root IsNot Nothing AndAlso Not _root.IsLeaf Then
                GetCollisionCandidates(_root.Left, _root.Right, results)
            End If

            Return results
        End Function

        Private Sub GetCollisionCandidates(left As BvhBuildNode, right As BvhBuildNode, candidates As ICollection(Of Pair(Of IShape)))
            If left.IsLeaf AndAlso right.IsLeaf Then
                Dim leftAndRight As IShape() = left.Shapes.Concat(right.Shapes).ToArray()

                For i As Integer = LBound(leftAndRight) To UBound(leftAndRight) - 1
                    For j As Integer = i + 1 To UBound(leftAndRight)
                        candidates.Add(New Pair(Of IShape)(leftAndRight(i), leftAndRight(j)))
                    Next
                Next
            Else
                If left.Bounds.Intersects(right.Bounds) Then
                    If left.IsLeaf Then
                        GetCollisionCandidates(left, right.Left, candidates)
                        GetCollisionCandidates(left, right.Right, candidates)
                    Else
                        GetCollisionCandidates(left.Left, right, candidates)
                        GetCollisionCandidates(left.Right, right, candidates)
                    End If
                Else
                    If Not left.IsLeaf Then GetCollisionCandidates(left.Left, left.Right, candidates)
                    If Not right.IsLeaf Then GetCollisionCandidates(right.Left, right.Right, candidates)
                End If
            End If
        End Sub

    End Class
End NameSpace