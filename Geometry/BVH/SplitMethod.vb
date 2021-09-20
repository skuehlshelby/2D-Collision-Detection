Namespace BVH
    Public MustInherit Class SplitMethod
        Private Sub New(name As String)
            Me.Name = name
        End Sub

        Public MustOverride Function Split(shapes As IShape()) As SplitResult

        Public ReadOnly Property Name As String

        Public Shared Function Values() As IEnumerable(Of SplitMethod)
            Return New SplitMethod() { Midpoint, EqualCounts, SurfaceAreaHeuristic }
        End Function

        Public Shared Function Parse(name As String) As SplitMethod
            Return Values().Single(Function(value) value.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
        End Function

        Private Shared Function GetBounds(shapes As IEnumerable(Of IShape)) As Bounds
            Return Bounds.Union(shapes.Select(Function(shape) shape.Bounds()))
        End Function

        Private Shared Function DefaultFailureRule(original As IShape(), firstHalf As IShape(), secondHalf As IShape()) As Boolean
            Return (firstHalf.Length >= original.Length) OrElse (secondHalf.Length >= original.Length)
        End Function

        Public Shared ReadOnly Property Midpoint As SplitMethod = New MidpointSplit()

        Public Shared ReadOnly Property EqualCounts As SplitMethod = New EqualCountsSplit()

        Public Shared ReadOnly Property SurfaceAreaHeuristic As SplitMethod = New SurfaceAreaHeuristicSplit()

        Private NotInheritable Class MidpointSplit
            Inherits SplitMethod

            Public Sub New ()
                MyBase.New("Midpoint")
            End Sub

            Public Overrides Function Split(shapes() As IShape) As SplitResult
                Dim bounds As Bounds = GetBounds(shapes)
                Dim splitAxis As Axis = bounds.LongestAxis().Opposite()
                Dim partition As PartitionedRectangle = new PartitionedRectangle(bounds, 1/2, splitAxis)

                Dim firstHalf As IShape() = shapes.Where(Function(shape) partition.FirstHalf.Intersects(shape.Bounds())).ToArray()
                Dim secondHalf As IShape() = shapes.Where(Function(shape) partition.SecondHalf.Intersects(shape.Bounds())).ToArray()

                Return New SplitResult(firstHalf, secondHalf, splitAxis, DefaultFailureRule(shapes, firstHalf, secondHalf))
            End Function
        End Class

        Private NotInheritable Class EqualCountsSplit
            Inherits SplitMethod

            Public Sub New ()
                MyBase.New("Equal Counts")
            End Sub

            Public Overrides Function Split(shapes() As IShape) As SplitResult
                Dim bounds As Bounds = GetBounds(shapes)
                Dim splitAxis As Axis = bounds.LongestAxis()
                Dim sortedByAxis As IShape() = shapes.OrderBy(Function(shape) splitAxis.GetSelector(shape.Center)).ToArray()
                
                Dim firstHalf As IShape() = sortedByAxis.Take(sortedByAxis.Length \ 2).ToArray()
                Dim secondHalf As IShape() = sortedByAxis.Skip(firstHalf.Length).ToArray()
                
                Dim firstHalfBounds As Bounds = GetBounds(firstHalf)
                Dim secondHalfBounds As Bounds = GetBounds(secondHalf)

                firstHalf = firstHalf.Concat(secondHalf.Where(Function(shape) shape.Bounds().Intersects(firstHalfBounds))).ToArray()
                secondHalf = secondHalf.Concat(firstHalf.Where(Function(shape) shape.Bounds().Intersects(secondHalfBounds))).ToArray()

                Return New SplitResult(firstHalf, secondHalf, splitAxis, DefaultFailureRule(shapes, firstHalf, secondHalf))
            End Function
        End Class

        Private NotInheritable Class SurfaceAreaHeuristicSplit
            Inherits SplitMethod

            Public Sub New ()
                MyBase.New("Surface Area Heuristic")
            End Sub

            Public Overrides Function Split(shapes() As IShape) As SplitResult
                Throw New NotImplementedException()
            End Function
        End Class

    End Class
End NameSpace