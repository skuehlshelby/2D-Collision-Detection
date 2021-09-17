Namespace BVH
    Public Class PartitionedRectangle

        Public Sub New(original As Rectangle, percentage As Single, axis As Axis)
            If axis = Axis.Horizontal Then
                FirstHalf = new Rectangle(original.TopLeft, original.TopRight().Lerp(original.BottomRight, percentage))
                SecondHalf = new Rectangle(original.TopLeft.Lerp(original.BottomLeft(), percentage), original.BottomRight)
            Else 
                FirstHalf = new Rectangle(original.TopLeft, original.BottomLeft().Lerp(original.BottomRight, percentage))
                SecondHalf = new Rectangle(original.TopLeft.Lerp(original.TopRight(), percentage), original.BottomRight)
            End If

        End Sub

        Public ReadOnly Property FirstHalf As Rectangle

        Public ReadOnly Property SecondHalf As Rectangle

    End Class
End NameSpace