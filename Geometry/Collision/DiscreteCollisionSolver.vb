Namespace Collision
    Public Class DiscreteCollisionSolver
        Implements ICollisionSolver

        Public Sub SolveCollision(candidates As IShape()) Implements ICollisionSolver.SolveCollision
            If candidates.Length = 2 Then
                SolveCollision(candidates(0), candidates(1))
            End If

            If candidates.Length > 2 Then
                SolveCollisions(candidates)
            End If
        End Sub

        Private Shared Sub SolveCollisions(candidates As IShape())
            For i As Integer = 0 To candidates.Length - 2
                For j As Integer = i + 1 To candidates.Length - 1
                    SolveCollision(candidates(i), candidates(j))
                Next
            Next
        End Sub

        Private Shared Sub SolveCollision(first As IShape, second As IShape)
            Dim hasCollision As Boolean = first.Contains(second.PointClosestTo(first.Center))

            If hasCollision Then
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
            End If
        End Sub

    End Class
End NameSpace