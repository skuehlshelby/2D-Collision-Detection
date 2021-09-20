Public Class Simulation
    Private Const Second As Integer = 1000
    Private ReadOnly _controller As SimulationController
    Private ReadOnly _timer As Timer = new Timer()

    Public Sub New()
        InitializeComponent()
        
        particleArea.SetDoubleBuffered()

        btnFPS.Minimum = 1
        btnFPS.Maximum = 60
        btnFPS.Value = 30

        _controller = New SimulationController(1 / btnFPS.Value, particleArea.Height, particleArea.Width)

        cbxCollisionDetectionMethod.Items.AddRange(_controller.GetCollisionDetectionMethods().ToArray())
        cbxSplitMethod.Items.AddRange(_controller.GetSceneSplitMethods().ToArray())

        _timer.Interval = Second \ CInt(btnFPS.Value)
        AddHandler _timer.Tick, AddressOf OnTick
        _timer.Start()
    End Sub

    Private Sub OnTick(sender As Object, e As EventArgs)
        particleArea.Refresh()
    End Sub

    Private Sub OnParticleAreaPaint(sender As Object, e As PaintEventArgs) Handles particleArea.Paint
        For Each action As Action(Of Graphics) In _controller.GetScene()
            action.Invoke(e.Graphics)
        Next
    End Sub

    Private Sub OnNumberOfParticlesChanged(sender As Object, e As EventArgs) Handles particleCount.ValueChanged
        _controller.SetNumberOfShapes(CInt(particleCount.Value))
    End Sub

    Private Sub Simulation_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If _controller IsNot Nothing Then
            _controller.SetWorldSize(particleArea.Height, particleArea.Width)
        End If
    End Sub

    Private Sub btnFPS_ValueChanged(sender As Object, e As EventArgs) Handles btnFPS.ValueChanged
        _timer.Interval = Second \ CInt(btnFPS.Value)

        If _controller IsNot Nothing Then
            _controller.UpdateTimeStep(1 / btnFPS.Value)
        End If
    End Sub

    Private Sub cbxSplitMethod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxSplitMethod.SelectedIndexChanged
        _controller.SetSceneSplitMethod(cbxSplitMethod.SelectedItem.ToString())
    End Sub

    Private Sub btnPause_Click(sender As Object, e As EventArgs) Handles btnPause.Click
        _controller.Paused = Not _controller.Paused
        btnPause.Text = If(_controller.Paused, "Continue", "Pause")
    End Sub

    Private Sub cbxShowBoundingVolumes_CheckedChanged(sender As Object, e As EventArgs) Handles cbxShowBoundingVolumes.CheckedChanged
        _controller.ShowBoundingVolumes = cbxShowBoundingVolumes.Checked
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles cbxShowRenderTime.CheckedChanged
        _controller.CalculateRenderTime = cbxShowRenderTime.Checked
    End Sub

End Class
