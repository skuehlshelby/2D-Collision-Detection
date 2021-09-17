Imports Geometry

Public Class Simulation
    Private Const Second As Integer = 1000
    Private ReadOnly _world As World
    Private ReadOnly _timer As Timer = new Timer()

    Public Sub New()
        InitializeComponent()
        
        particleArea.SetDoubleBuffered()

        _world =  New World(particleArea.Height, particleArea.Width)

        btnFPS.Minimum = 1
        btnFPS.Maximum = 60
        btnFPS.Value = 30

        _timer.Interval = Second \ CInt(btnFPS.Value)
        AddHandler _timer.Tick, AddressOf OnTick
        _timer.Start()
    End Sub

    Private Sub OnTick(sender As Object, e As EventArgs)
        _world.Update(1 / btnFPS.Value)

        particleArea.Refresh()
    End Sub

    Private Sub OnParticleAreaPaint(sender As Object, e As PaintEventArgs) Handles particleArea.Paint
        For Each shape As IShape In _world
            e.Graphics.FillEllipse(new SolidBrush(shape.Color), shape.Bounds().ToDrawingApi(e.ClipRectangle.Height, Width))
        Next
    End Sub

    Private Sub OnNumberOfParticlesChanged(sender As Object, e As EventArgs) Handles particleCount.ValueChanged
        While particleCount.Value > _world.NumberOfParticles
            _world.AddParticle(40, 40, Color.CornflowerBlue, Color.DarkCyan, Color.Goldenrod)
        End While

        While particleCount.Value < _world.Count
            _world.RemoveParticle()
        End While
    End Sub

    Private Sub Simulation_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If _world IsNot Nothing Then
            _world.Bounds = New Rectangle((0.0F, particleArea.Height), (particleArea.Width, 0.0F))
        End If
    End Sub

    Private Sub btnFPS_ValueChanged(sender As Object, e As EventArgs) Handles btnFPS.ValueChanged
        _timer.Interval = Second \ CInt(btnFPS.Value)
    End Sub
End Class
