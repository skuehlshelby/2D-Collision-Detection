Public Class DiscreteCollisionSolver
    Implements ICollisionSolver

    Public Sub SolveCollision(candidates As IShape()) Implements ICollisionSolver.SolveCollision
        If candidates.Length > 2 Then
            Throw New ArgumentException("Cannot solve collisions for more than two objects at a time.")
        End If

        If candidates.Length = 2 Then
            SolveCollision(candidates(0), candidates(1))
        End If
    End Sub

    Private Shared Sub SolveCollision(first As IShape, second As IShape)
        Dim hasCollision As Boolean = first.Contains(second.PointClosestTo(first.Center))

        If hasCollision Then
            Dim collisionNormal As Vector2DF = (second.Center - first.Center).ToUnitVec()
            Dim collisionTangent As Vector2DF = New Vector2DF(- collisionNormal.Y, collisionNormal.X)
            Dim dotProductOfTangentAndVelocityFirst As Single = first.Velocity.Dot(collisionTangent)
            Dim dotProductOfTangentAndVelocitySecond As Single = second.Velocity.Dot(collisionTangent)

            first.Velocity *= dotProductOfTangentAndVelocityFirst
            second.Velocity *= dotProductOfTangentAndVelocitySecond
        End If
    End Sub

End Class