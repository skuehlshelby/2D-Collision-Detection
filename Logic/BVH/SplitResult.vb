Namespace BVH
    Public Class SplitResult

        Sub New (firstHalf As IEnumerable(Of IShape), secondHalf As IEnumerable(Of IShape), splitAxis As Axis)
            Me.New(firstHalf.ToArray(), secondHalf.ToArray(), splitAxis)
        End Sub

        Sub New(firstHalf As IShape(), secondHalf As IShape(), splitAxis As Axis)
            Me.FirstHalf = firstHalf
            Me.SecondHalf = secondHalf
            Me.SplitAxis = splitAxis
        End Sub

        Public ReadOnly Property FirstHalf As IShape()

        Public ReadOnly Property SecondHalf As IShape()

        Public ReadOnly Property SplitAxis As Axis

    End Class
End NameSpace