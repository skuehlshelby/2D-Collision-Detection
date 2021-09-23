Imports System.Reflection
Imports CollisionDetection.Presentation

Public Class Simulation
    Implements ISimulationView
    Implements IDefaultConsumer

    Private Const Second As Integer = 1000
    Private ReadOnly presenter As ISimulationPresenter
    Private ReadOnly _timer As Timer = New Timer()

    Public Sub New(defaults As IDefaultProvider)
        InitializeComponent()

        SetDoubleBuffered(particleArea)

        presenter = New Presenter(defaults, Me)
        defaults.SetDefaults(Me)

        ConfigureFPSButton()

        ConfigureEvents()

        ConfigureTimer()
    End Sub

    Public Event PauseRequested As EventHandler Implements ISimulationView.PauseRequested
    Public Event ShapeCountChanged As EventHandler(Of Byte) Implements ISimulationView.ShapeCountChanged
    Public Event FrameRateChanged As EventHandler(Of Byte) Implements ISimulationView.FrameRateChanged
    Public Event ShowBoundingVolumesChanged As EventHandler(Of Boolean) Implements ISimulationView.ShowBoundingVolumesChanged
    Public Event ShowAverageRenderTimeChanged As EventHandler(Of Boolean) Implements ISimulationView.ShowAverageRenderTimeChanged
    Public Event SplitMethodChanged As EventHandler(Of String) Implements ISimulationView.SplitMethodChanged
    Public Event CollisionDetectionMethodChanged As EventHandler(Of String) Implements ISimulationView.CollisionDetectionMethodChanged
    Public Event ColorAdded As EventHandler(Of Color) Implements ISimulationView.ColorAdded
    Public Event ColorRemoved As EventHandler(Of Color) Implements ISimulationView.ColorRemoved
    Public Event Resized As EventHandler(Of Size) Implements ISimulationView.Resized

    Public ReadOnly Property SceneDimensions As Size Implements ISimulationView.SceneDimensions
        Get
            Return particleArea.Size
        End Get
    End Property

#Region "Control Configuration"

    Private Sub ConfigureFPSButton()
        With btnFPS
            .Minimum = 1
            .Maximum = 60
        End With
    End Sub

    Private Sub ConfigureTimer()
        With _timer
            .Interval = Second \ CInt(btnFPS.Value)
            AddHandler .Tick, AddressOf OnTick
            .Start()
        End With
    End Sub

#End Region

#Region "Event Configuration"
    Private Sub ConfigureEvents()
        AddHandler particleCount.ValueChanged, Sub() RaiseEvent ShapeCountChanged(particleCount, CByte(particleCount.Value))
        AddHandler btnPause.Click, Sub() RaiseEvent PauseRequested(btnPause, EventArgs.Empty)
        AddHandler btnPause.Click, Sub() btnPause.Text = If(btnPause.Text = "Pause", "Continue", "Pause")
        AddHandler btnFPS.ValueChanged, Sub() RaiseEvent FrameRateChanged(btnFPS, CByte(btnFPS.Value))
        AddHandler btnFPS.ValueChanged, Sub() _timer.Interval = Second \ CInt(btnFPS.Value)
        AddHandler cbxShowBoundingVolumes.CheckStateChanged, Sub() RaiseEvent ShowBoundingVolumesChanged(cbxShowBoundingVolumes, cbxShowBoundingVolumes.Checked)
        AddHandler cbxShowRenderTime.CheckStateChanged, Sub() RaiseEvent ShowAverageRenderTimeChanged(cbxShowRenderTime, cbxShowRenderTime.Checked)
        AddHandler cbxSplitMethod.SelectedValueChanged, Sub() RaiseEvent SplitMethodChanged(cbxSplitMethod, cbxSplitMethod.SelectedItem.ToString())
        AddHandler cbxCollisionDetectionMethod.SelectedValueChanged, Sub() RaiseEvent CollisionDetectionMethodChanged(cbxCollisionDetectionMethod, cbxCollisionDetectionMethod.SelectedItem.ToString())
        AddHandler particleArea.SizeChanged, Sub() RaiseEvent Resized(particleArea, particleArea.DisplayRectangle.Size)
        AddHandler colorPanel.Click, AddressOf OnColorPanelClick
    End Sub
#End Region

#Region "Defaults"

    Private Sub SetDefaultParticleCount(count As Byte) Implements IDefaultConsumer.SetDefaultParticleCount
        particleCount.Value = count
    End Sub

    Private Sub SetDefaultFrameRate(fps As Byte) Implements IDefaultConsumer.SetDefaultFrameRate
        btnFPS.Value = fps
    End Sub

    Private Sub SetDefaultBoundingVolumeVisibility(visible As Boolean) Implements IDefaultConsumer.SetDefaultBoundingVolumeVisibility
        cbxShowBoundingVolumes.Checked = visible
    End Sub

    Private Sub SetDefaultAverageRenderTimeVisibility(visible As Boolean) Implements IDefaultConsumer.SetDefaultAverageRenderTimeVisibility
        cbxShowRenderTime.Checked = visible
    End Sub

    Private Sub SetDefaultBVHSplitMethod(methodName As String) Implements IDefaultConsumer.SetDefaultBVHSplitMethod
        cbxSplitMethod.SelectedItem = methodName
    End Sub

    Public Sub SetDefaultBVHSplitMethods(methodNames() As String) Implements IDefaultConsumer.SetDefaultBVHSplitMethods
        With cbxSplitMethod.Items
            .Clear()
            .AddRange(methodNames)
        End With
    End Sub

    Private Sub SetDefaultCollisionDetectionMethod(methodName As String) Implements IDefaultConsumer.SetDefaultCollisionDetectionMethod
        cbxCollisionDetectionMethod.SelectedItem = methodName
    End Sub

    Public Sub SetDefaultCollisionDetectionMethods(methodNames() As String) Implements IDefaultConsumer.SetDefaultCollisionDetectionMethods
        With cbxCollisionDetectionMethod.Items
            .Clear()
            .AddRange(methodNames)
        End With
    End Sub

    Private Sub SetDefaultParticleColors(colors As IEnumerable(Of Color)) Implements IDefaultConsumer.SetDefaultParticleColors
        For Each color As Color In colors
            AddColorOption(color)
        Next

        ArrangeColorOptions()
    End Sub

#End Region

#Region "Vanity"
    Private Sub SetDoubleBuffered(panel As Panel)
        panel.GetType().InvokeMember("DoubleBuffered",
                                        BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.SetProperty,
                                        Nothing, panel, New Object() {True})
    End Sub

    Private Sub AddColorOption(color As Color)
        Dim lblColor As Label = New Label With {
            .BackColor = color,
            .Height = 10,
            .Width = 10
        }

        AddHandler lblColor.Click, AddressOf RemoveColorOption

        RaiseEvent ColorAdded(Me, color)

        colorPanel.Controls.Add(lblColor)

        ArrangeColorOptions()
    End Sub

    Private Sub RemoveColorOption(sender As Object, e As EventArgs)
        If sender IsNot Nothing AndAlso TypeOf sender Is Control Then
            Dim c As Control = DirectCast(sender, Control)

            RaiseEvent ColorRemoved(Me, c.BackColor)

            colorPanel.Controls.Remove(c)

            ArrangeColorOptions()
        End If
    End Sub

    Private Sub ArrangeColorOptions()
        Dim optionMargin As Integer = 5
        Dim optionWidth As Integer = colorPanel.Controls.Item(0).Width + optionMargin

        For index As Integer = 0 To colorPanel.Controls.Count - 1
            colorPanel.Controls.Item(index).Left = optionMargin + (index * optionWidth)
        Next
    End Sub
#End Region

    Private Sub OnTick(sender As Object, e As EventArgs)
        particleArea.Refresh()
    End Sub

    Private Sub OnParticleAreaPaint(sender As Object, e As PaintEventArgs) Handles particleArea.Paint
        For Each action As Action(Of Graphics) In presenter.GetScene()
            action.Invoke(e.Graphics)
        Next
    End Sub

    Private Sub OnColorPanelClick(sender As Object, e As EventArgs)
        With New ColorDialog
            
            If .ShowDialog(Me) = DialogResult.OK Then
                AddColorOption(.Color)
            End If
        End With
    End Sub
End Class
