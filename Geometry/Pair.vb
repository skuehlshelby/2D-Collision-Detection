Public Class Pair(Of T)

    Sub New(first As T, second As T)
        Me.First = first
        Me.Second = second
    End Sub

    Public ReadOnly Property First As T

    Public ReadOnly Property Second As T

End Class