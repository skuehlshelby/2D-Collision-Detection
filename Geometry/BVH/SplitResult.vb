Namespace BVH
    Public NotInheritable Class SplitResult

        Private Sub New()
            FirstHalf = Nothing
            SecondHalf = Nothing
            SplitAxis = Nothing
            Failed = True
        End Sub

        Private Sub New(firstHalf As IShape(), secondHalf As IShape(), splitAxis As Axis)
            Me.FirstHalf = firstHalf
            Me.SecondHalf = secondHalf
            Me.SplitAxis = splitAxis
            Failed = False
        End Sub

        Public ReadOnly Property FirstHalf As IShape()

        Public ReadOnly Property SecondHalf As IShape()

        Public ReadOnly Property SplitAxis As Axis

        Public ReadOnly Property Failed As Boolean

        Public Shared Function Failure() As SplitResult
            Return New SplitResult()
        End Function

        Public Shared Function Success(firstHalf As IShape(), secondHalf As IShape(), splitAxis As Axis) As SplitResult
            Return New SplitResult(firstHalf, secondHalf, splitAxis)
        End Function

    End Class
End NameSpace