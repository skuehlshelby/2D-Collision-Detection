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

        Private Shared Function GetCentroidBounds(shapes As IEnumerable(Of IShape)) As Bounds
            Return Bounds.Union(shapes.Select(Function(shape) shape.Center))
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
                Dim centroidBounds As Bounds = GetCentroidBounds(shapes)

                If Math.Abs(centroidBounds.Area() - 0.0F) < 0.01 Then
                    Return SplitResult.Failure()
                End If

                Dim splitAxis As Axis = centroidBounds.LongestAxis()
                Dim middle As Single = (splitAxis.SelectAxis(centroidBounds.BottomLeft) + splitAxis.SelectAxis(centroidBounds.TopRight)) / 2.0F
                Dim sortedByAxis As IShape() = shapes.OrderBy(Function(shape) splitAxis.SelectAxis(shape.Center)).ToArray()

                Dim firstHalf As IShape() = sortedByAxis.TakeWhile(Function(shape) splitAxis.SelectAxis(shape.Center) < middle).ToArray()
                Dim secondHalf As IShape() = sortedByAxis.Skip(firstHalf.Length).ToArray()

                Return SplitResult.Success(firstHalf, secondHalf, splitAxis)
            End Function
        End Class

        Private NotInheritable Class EqualCountsSplit
            Inherits SplitMethod

            Public Sub New ()
                MyBase.New("Equal Counts")
            End Sub

            Public Overrides Function Split(shapes() As IShape) As SplitResult
                Dim centroidBounds As Bounds = GetCentroidBounds(shapes)

                If Math.Abs(centroidBounds.Area() - 0.0F) < 0.01 Then
                    Return SplitResult.Failure()
                End If

                Dim splitAxis As Axis = centroidBounds.LongestAxis()
                Dim sortedByAxis As IShape() = shapes.OrderBy(Function(shape) splitAxis.SelectAxis(shape.Center)).ToArray()

                Dim firstHalf As IShape() = sortedByAxis.Take(sortedByAxis.Length \ 2).ToArray()
                Dim secondHalf As IShape() = sortedByAxis.Skip(firstHalf.Length).ToArray()

                Return SplitResult.Success(firstHalf, secondHalf, splitAxis)
            End Function

        End Class

        Private NotInheritable Class SurfaceAreaHeuristicSplit
            Inherits SplitMethod

            Public Sub New ()
                MyBase.New("Surface Area Heuristic")
            End Sub

            Public Overrides Function Split(shapes() As IShape) As SplitResult
                If shapes.Length > 4 Then
                    Dim centroidBounds As Bounds = GetCentroidBounds(shapes)

                    If Math.Abs(centroidBounds.Area() - 0.0F) < 0.01 Then
                        Return SplitResult.Failure()
                    End If

                    Dim bounds As Bounds = GetBounds(shapes)
                    Dim splitAxis As Axis = bounds.LongestAxis()
                    Dim buckets(6) As SahBucket

                    For index As Integer = LBound(buckets) To UBound(buckets)
                        buckets(index) = New SahBucket(bounds, CSng(index / UBound(buckets)), splitAxis, shapes) 
                    Next

                    Array.Sort(buckets, Function(l, r) l.SplitCost().CompareTo(r.SplitCost()))

                    If buckets(0).SplitCost() < shapes.Length Then
                        Return SplitResult.Success(buckets(0).FirstHalf, buckets(0).SecondHalf, splitAxis)
                    Else
                        Return SplitResult.Failure()
                    End If
                Else
                    Return EqualCounts.Split(shapes)
                End If
            End Function

            Private NotInheritable Class SahBucket
                Public Sub New(original As Bounds, percentage As Single, splitAxis As Axis, shapes As IEnumerable(Of IShape))
                    Dim sortedShapes As IShape() = shapes.OrderBy(Function(shape) splitAxis.SelectAxis(shape.Center)).ToArray()
                    Dim partition As Single = splitAxis.SelectAxis(original.BottomLeft) + (splitAxis.SelectAxis(original) * percentage)
                    
                    FirstHalf = sortedShapes.TakeWhile(Function(shape) splitAxis.SelectAxis(shape.Center) <= partition).ToArray()
                    FirstHalfBounds = GetBounds(FirstHalf)
                    FirstHalfCount = FirstHalf.Length
                    SecondHalf = sortedShapes.Skip(FirstHalf.Length).ToArray()
                    SecondHalfBounds = GetBounds(SecondHalf)
                    SecondHalfCount = SecondHalf.Length
                    SplitCost = 0.125F + ((FirstHalfCount * FirstHalfBounds.Area()) + (SecondHalfCount * SecondHalfBounds.Area())) / original.Area()
                End Sub

                Public ReadOnly Property SplitCost As Double

                Public ReadOnly Property FirstHalf As IShape()

                Public ReadOnly Property FirstHalfBounds As Bounds

                Public ReadOnly Property FirstHalfCount As Integer

                Public ReadOnly Property SecondHalf As IShape()

                Public ReadOnly Property SecondHalfBounds As Bounds

                Public ReadOnly Property SecondHalfCount As Integer
            End Class
        End Class

    End Class
End NameSpace