Imports Geometry
Imports Geometry.BVH
Imports Geometry.Collision

Public Class World
    Implements IEnumerable(Of IShape)

    Public Property Bounds As Rectangle
    Private ReadOnly _circles As ICollection(Of IShape) = New List(Of IShape)
    Private ReadOnly _collisionResolver As ICollisionSolver = New DiscreteCollisionSolver
    Private ReadOnly _splitMethod As SplitMethod = SplitMethod.Midpoint
    Private ReadOnly _collisionDetectionMethod As CollisionDetectionMethod = CollisionDetectionMethod.Discrete

    Sub New(height As Single, width As Single)
        Bounds = New Rectangle((0.0F, height), (width, 0.0F))
    End Sub

    Public ReadOnly Property NumberOfParticles As Integer
        Get
            Return _circles.Count
        End Get
    End Property

    Public Sub AddParticle(maxRadius As Integer, maxVelocity As Integer, ParamArray colors As Color())
        _circles.Add(GetRandomShape(maxRadius, maxVelocity, CInt(Bounds.Width()), CInt(Bounds.Height()), colors))
    End Sub

    Public Sub RemoveParticle()
        _circles.Remove(_circles.Last())
    End Sub

    Public Sub Update(changeInTime As Single)
        If _circles.Any() Then

            For Each collision As Pair(Of IShape) In _collisionDetectionMethod.GetCollisions(_circles.ToArray(), _splitMethod)
                _collisionResolver.SolveCollision(collision)
            Next

            For Each circle As IShape In _circles
                If circle.Bounds().TopLeft.X <= 0.0F Then circle.Velocity = New Vector(-circle.Velocity.X, circle.Velocity.Y)
                If circle.Bounds().TopLeft.Y >= Bounds.Height() Then circle.Velocity = New Vector(circle.Velocity.X, -circle.Velocity.Y)
                If circle.Bounds().BottomRight.X >= Bounds.Width() Then circle.Velocity = New Vector(-circle.Velocity.X, circle.Velocity.Y)
                If circle.Bounds().BottomRight.Y <= 0.0F Then circle.Velocity = New Vector(circle.Velocity.X, -circle.Velocity.Y)
            Next

            For Each shape As IShape In _circles
                If shape.Velocity <> Vector.Zero Then
                    shape.Center += shape.Velocity * changeInTime
                End If
            Next
        End If
    End Sub

    Public Function GetEnumerator() As IEnumerator(Of IShape) Implements IEnumerable(Of IShape).GetEnumerator
        Return _circles.GetEnumerator()
    End Function

    Private Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
        Return DirectCast(_circles, IEnumerable).GetEnumerator()
    End Function
End Class