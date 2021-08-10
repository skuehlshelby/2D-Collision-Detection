Public Class Simulation
    Private Const FramesPerSecond As Integer = 30
    Private Const Second As Integer = 1000
    Private ReadOnly _particles As ICollection(Of Particle) = New List(Of Particle)()
    Private ReadOnly _random As Random = New Random()
    Private ReadOnly _particleColors As Color() = { Color.CornflowerBlue, Color.DarkCyan, Color.Goldenrod }
    Private ReadOnly _timer As Timer = new Timer()

    Public Sub New()
        InitializeComponent()
        
        particleArea.SetDoubleBuffered()

        _timer.Interval = Second \ FramesPerSecond
        AddHandler _timer.Tick, AddressOf OnTick
        _timer.Start()
    End Sub

    Private Sub OnTick(sender As Object, e As EventArgs)
        For Each particle As Particle In _particles
            UpdateParticlePosition(particle)
        Next

        particleArea.Refresh()
    End Sub

    Private Sub UpdateParticlePosition(particle As Particle)
        Const changeInTime As Single = 1 / FramesPerSecond

        Dim newX As Single = particle.Position.X + (particle.Velocity.X * changeInTime)
        Dim newY As Single = particle.Position.Y + (particle.Velocity.Y * changeInTime)

        If newX < particle.Radius Or newX > (particleArea.Width - particle.Radius) Then
            particle.InvertVelocityHorizontal()
        ElseIf newY < particle.Radius Or newY > (particleArea.Height - particle.Radius) Then
            particle.InvertVelocityVertical()
        End If

        particle.Position = new PointF(newX, newY)
    End Sub

    Private Sub OnParticleAreaPaint(sender As Object, e As PaintEventArgs) Handles particleArea.Paint
        For Each particle As Particle In _particles
            e.Graphics.FillEllipse(new SolidBrush(particle.Color), particle.BoundingRectangle())
        Next
    End Sub

    Private Sub OnNumberOfParticlesChanged(sender As Object, e As EventArgs) Handles particleCount.ValueChanged
        While particleCount.Value > _particles.Count
            _particles.Add(GetRandomParticle())
        End While

        While particleCount.Value < _particles.Count
            _particles.Remove(_particles.Last())
        End While

        particleArea.Refresh()
    End Sub

    Private Function GetRandomParticle() As Particle
        Return New Particle(GetRandomRadius(), GetRandomColor(), GetRandomStartingPosition(), GetRandomVelocity(), New PointF(0.0, 0.0))
    End Function

    Private Function GetRandomRadius() As Integer
        Return Math.Max(_random.Next() Mod 40, 2)
    End Function

    Private Function GetRandomColor() As Color
        Return _particleColors(_random.Next() Mod _particleColors.Count())
    End Function

    Private Function GetRandomStartingPosition() As PointF
        Return New PointF(_random.Next(40, particleArea.DisplayRectangle.Width - 40), _random.Next(40, particleArea.DisplayRectangle.Height - 40))
    End Function

    Private Function GetRandomVelocity() As PointF
        Return New PointF(_random.Next(-40, 40), _random.Next(-40, 40))
    End Function
End Class
