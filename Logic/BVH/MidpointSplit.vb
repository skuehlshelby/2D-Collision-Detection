Namespace BVH

    Public Class MidpointSplit
        Implements ISplitMethod

        Public Function Split(shapes As IShape()) As SplitResult Implements ISplitMethod.Split
            Dim bounds As RectF = RectF.Union(shapes.Select(Function(shape) shape.Bounds()))
            Dim splitAxis As Axis = bounds.LongestAxis().Opposite()
            Dim partition As PartitionedRectangle = new PartitionedRectangle(bounds, 1/2, splitAxis)

            Return _
                New SplitResult(shapes.Where(Function(shape) shape.Bounds().Intersects(partition.FirstHalf)),
                                shapes.Where(Function(shape) shape.Bounds().Intersects(partition.SecondHalf)), 
                                splitAxis)
        End Function

    End Class
End NameSpace