Namespace BVH
    Public Class PartitionedRectangle

        Public Sub New(original As Bounds, percentage As Single, axis As Axis)
            If axis = Axis.Horizontal Then
                FirstHalf = New Bounds(original.BottomLeft.Lerp(original.TopLeft(), percentage), original.TopRight)
                SecondHalf = New Bounds(original.BottomLeft, original.TopRight.Lerp(original.BottomRight(), percentage))
            Else
                FirstHalf = New Bounds(original.BottomLeft, original.TopRight.Lerp(original.TopLeft(), percentage))
                SecondHalf = New Bounds(original.BottomLeft.Lerp(original.BottomRight(), percentage), original.TopRight)
            End If

        End Sub

        Public ReadOnly Property FirstHalf As Bounds

        Public ReadOnly Property SecondHalf As Bounds

    End Class
End NameSpace