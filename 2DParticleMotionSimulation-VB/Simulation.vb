Public Class Simulation
    Private Const FramesPerSecond As Integer = 30
    Private Const Second As Integer = 1000
    Private ReadOnly _box As Box
    Private ReadOnly _timer As Timer = new Timer()

    Public Sub New()
        InitializeComponent()
        
        particleArea.SetDoubleBuffered()

        _box =  New Box(particleArea.Height, particleArea.Width)

        _timer.Interval = Second \ FramesPerSecond
        AddHandler _timer.Tick, AddressOf OnTick
        _timer.Start()
    End Sub

    Private Sub OnTick(sender As Object, e As EventArgs)
        _box.Update(1 / FramesPerSecond)

        particleArea.Refresh()
    End Sub

    Private Sub OnParticleAreaPaint(sender As Object, e As PaintEventArgs) Handles particleArea.Paint
        For Each particle As Particle In _box
            e.Graphics.FillEllipse(new SolidBrush(particle.Color), particle.BoundingRectangle())
        Next
    End Sub

    Private Sub OnNumberOfParticlesChanged(sender As Object, e As EventArgs) Handles particleCount.ValueChanged
        While particleCount.Value > _box.NumberOfParticles
            _box.AddParticle(40, 40, Color.CornflowerBlue, Color.DarkCyan, Color.Goldenrod)
        End While

        While particleCount.Value < _box.Count
            _box.RemoveParticle()
        End While

        particleArea.Refresh()
    End Sub

End Class
