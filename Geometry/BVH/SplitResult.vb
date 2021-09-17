Namespace BVH
    Public Class SplitResult

        Sub New (firstHalf As IEnumerable(Of IShape), secondHalf As IEnumerable(Of IShape), splitAxis As Axis, failed As Boolean)
            Me.New(firstHalf.ToArray(), secondHalf.ToArray(), splitAxis, failed)
        End Sub

        Sub New(firstHalf As IShape(), secondHalf As IShape(), splitAxis As Axis, failed As Boolean)
            Me.FirstHalf = firstHalf
            Me.SecondHalf = secondHalf
            Me.SplitAxis = splitAxis
            Me.Failed = failed
        End Sub

        Public ReadOnly Property FirstHalf As IShape()

        Public ReadOnly Property SecondHalf As IShape()

        Public ReadOnly Property SplitAxis As Axis

        Public ReadOnly Property Failed As Boolean

    End Class
End NameSpace