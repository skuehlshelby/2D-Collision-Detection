Namespace BVH
    Public Class PartitionedRectangle

        Public Sub New(original As RectF, percentage As Single, axis As Axis)
            If axis = Axis.Horizontal Then
                FirstHalf = new RectF(original.TopLeft, original.TopRight().Lerp(original.BottomRight, percentage))
                SecondHalf = new RectF(original.TopLeft.Lerp(original.BottomLeft(), percentage), original.BottomRight)
            Else 
                FirstHalf = new RectF(original.TopLeft, original.BottomLeft().Lerp(original.BottomRight, percentage))
                SecondHalf = new RectF(original.TopLeft.Lerp(original.TopRight(), percentage), original.BottomRight)
            End If

        End Sub

        Public ReadOnly Property FirstHalf As RectF

        Public ReadOnly Property SecondHalf As RectF

    End Class
End NameSpace