Namespace Collision
    Public Class CollisionSolver

        Public Sub Solve(collision As Pair(Of IShape))
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

        Public Sub Solve(worldBounds As Bounds, shape As IShape)
            If shape.Bounds().BottomLeft.X <= 0.0F AndAlso shape.Velocity.X < 0.0F Then shape.Velocity = New Vector(-shape.Velocity.X, shape.Velocity.Y)
            If shape.Bounds().BottomLeft.Y <= 0.0F AndAlso shape.Velocity.Y < 0.0F Then shape.Velocity = New Vector(shape.Velocity.X, -shape.Velocity.Y)
            If shape.Bounds().TopRight.X >= worldBounds.Width() AndAlso shape.Velocity.X > 0.0F Then shape.Velocity = New Vector(-shape.Velocity.X, shape.Velocity.Y)
            If shape.Bounds().TopRight.Y >= worldBounds.Height() AndAlso shape.Velocity.Y > 0.0F Then shape.Velocity = New Vector(shape.Velocity.X, -shape.Velocity.Y)
        End Sub

    End Class
End NameSpace