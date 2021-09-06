Friend Class BoundingVolumeHierarchy
    Implements IEnumerable(Of IEnumerable(Of IShape))

    Private ReadOnly _root As BVHBuildNode

    Public Sub New(shapes As IEnumerable(Of IShape))
        _root = Build(shapes)
    End Sub

    Private Function Build(shapes As IEnumerable(Of IShape)) As BVHBuildNode
        If shapes.Count() < 4 Then

        Else

        End If
    End Function

    Private Class BVHBuildNode

        Public Sub New(bounds As Box2DF, ParamArray shapes As IShape())
            Me.Bounds = bounds
            Me.Shapes = shapes
            Left = Nothing
            Right = Nothing
            Axis = Nothing
            IsLeaf = True
        End Sub

        Public Sub New(axis As Axis, left As BVHBuildNode, right As BVHBuildNode)
            Me.Axis = axis
            Me.Left = left
            Me.Right = right
            Bounds = left.Bounds.Union(right.Bounds)
            Shapes = Nothing
            IsLeaf = False
        End Sub


        Public ReadOnly Axis As Axis

        Public ReadOnly Bounds As Box2DF

        Public ReadOnly Left As BVHBuildNode

        Public ReadOnly Right As BVHBuildNode

        Public ReadOnly Shapes As IEnumerable(Of IShape)

        Public ReadOnly IsLeaf As Boolean

    End Class

    Private Class SurfaceAreaHeuristic
        Function ShouldSplit() As Boolean
            Throw New NotImplementedException
        End Function

        'Function 

    End Class

    Public Function GetEnumerator() As IEnumerator(Of IEnumerable(Of IShape)) Implements IEnumerable(Of IEnumerable(Of IShape)).GetEnumerator
        Throw New NotImplementedException()
    End Function

    Private Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
        Throw New NotImplementedException()
    End Function

End Class