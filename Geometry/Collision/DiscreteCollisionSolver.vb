Namespace Collision
    Public Class DiscreteCollisionSolver
        Implements ICollisionSolver

        Public Sub SolveCollision(collision As Pair(Of IShape)) Implements ICollisionSolver.SolveCollision
            Dim first As IShape = collision.First
            Dim second As IShape = collision.Second

            Dim collisionNormal As Vector = (second.Center - first.Center).ToUnitVec()
            Dim collisionTangent As Vector = New Vector(- collisionNormal.Y, collisionNormal.X)
        
            Dim dpTangent1 As Single = first.Velocity.Dot(collisionTangent)
            Dim dpTangent2 As Single = second.Velocity.Dot(collisionTangent)

            Dim dpNormal1 As Single = first.Velocity.Dot(collisionNormal)
            Dim dpNormal2 As Single = second.Velocity.Dot(collisionNormal)

            Dim momentum1 As Single = (dpNormal1 * (first.Mass - second.Mass) + 2.0F * second.Mass * dpNormal2) / (first.Mass + second.Mass)
            Dim momentum2 As Single = (dpNormal2 * (second.Mass - first.Mass) + 2.0F * first.Mass * dpNormal1) / (first.Mass + second.Mass)
    
            first.Velocity = collisionTangent * dpTangent1 + collisionNormal * momentum1
            second.Velocity = collisionTangent * dpTangent2 + collisionNormal * momentum2
        End Sub

    End Class
End NameSpace