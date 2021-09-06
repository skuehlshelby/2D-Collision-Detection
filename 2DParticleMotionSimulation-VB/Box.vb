Public Class Box
    Implements IEnumerable(Of Particle)

    Private Readonly _height As Integer
    Private ReadOnly _width As Integer
    Private ReadOnly _particles As ICollection(Of Particle) = New List(Of Particle)

    Sub New(height As Integer, width As Integer)
        _height = height
        _width = width
    End Sub

    Public ReadOnly Property NumberOfParticles As Integer
        Get
            Return _particles.Count
        End Get
    End Property

    Public Sub AddParticle(maxRadius As Integer, maxVelocity As Integer, ParamArray colors As Color())
        _particles.Add(Particle.GetRandom(maxRadius, maxVelocity, _width, _height, colors))
    End Sub

    Public Sub RemoveParticle()
        _particles.Remove(_particles.Last())
    End Sub

    Public Sub Update(changeInTime As Single)
        For Each p As Particle In _particles
            p.Move(changeInTime)

            If p.Velocity.X > 0.0F AndAlso p.Right() >= _width Then
                p.InvertVelocityHorizontal()
            ElseIf p.Velocity.X < 0.0F AndAlso p.Left() <= 0.0F Then
                p.InvertVelocityHorizontal()
            End If

            If p.Velocity.Y > 0.0F AndAlso p.Top() >= _height Then
                p.InvertVelocityVertical()
            ElseIf p.Velocity.Y < 0.0F AndAlso p.Bottom() <= 0.0F Then
                p.InvertVelocityVertical()
            End If
        Next
    End Sub

    Public Function GetEnumerator() As IEnumerator(Of Particle) Implements IEnumerable(Of Particle).GetEnumerator
        Return _particles.GetEnumerator()
    End Function

    Private Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
        Return DirectCast(_particles, IEnumerable).GetEnumerator()
    End Function
End Class