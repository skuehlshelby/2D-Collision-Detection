Namespace Collision

    Public Class WorldBoundCollisionResolver
        Implements IResolveCollision(Of Rectangle, IShape)

        Public Sub ResolveCollision(first As Rectangle, second As IShape) Implements IResolveCollision(Of Rectangle, IShape).ResolveCollision
            Throw New NotImplementedException()
        End Sub
    End Class

End NameSpace