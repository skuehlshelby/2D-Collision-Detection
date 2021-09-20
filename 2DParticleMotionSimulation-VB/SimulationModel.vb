Imports System.Drawing.Drawing2D
Imports Geometry
Imports Geometry.BVH
Imports Geometry.Collision

Friend NotInheritable Class SimulationModel

    Private ReadOnly _averageRenderTime As Queue(Of TimeSpan) = New Queue(Of TimeSpan)()

#Region "Rendering"

    Public Function GetScene(options As RenderOptions, info As SceneInfo) As Queue(Of Action(Of Graphics))
        If options.CalculateRenderTime Then
            With options.RenderTimeStopwatch
                .Reset()
                .Start()
            End With
        End If

        Dim scene As Queue(Of Action(Of Graphics)) = New Queue(Of Action(Of Graphics))()

        If Not options.Paused Then
            Dim bvh As BoundingVolumeHierarchy = New BoundingVolumeHierarchy(info.Shapes.ToArray(), options.SceneSplitMethod)

            SolveCollisions(options, info, bvh)

            UpdateShapePositions(options, info.Shapes)
        End If

        If options.ShowBoundingVolumes Then
            RenderBvhBounds(scene, info, New BoundingVolumeHierarchy(info.Shapes.ToArray(), options.SceneSplitMethod).Leaves.Select(Function(leaf) leaf.Bounds))
        End If

        RenderShapes(scene, info)

        If options.CalculateRenderTime Then
            With options.RenderTimeStopwatch
                .Stop()
                _averageRenderTime.Enqueue(.Elapsed)
            End With
            
            RenderDrawTime(scene, options)
        End If

        If _averageRenderTime.Count > 0 Then
            Dim discard As TimeSpan = _averageRenderTime.Dequeue()
        End If

        Return scene
    End Function

    Private Shared Sub RenderBvhBounds(scene As Queue(Of Action(Of Graphics)), info As SceneInfo, volumes As IEnumerable(Of Bounds))
        Dim redDashes As Pen = New Pen(Color.Red) With { 
                .DashStyle = DashStyle.Dash 
                }

        Dim transformedVolumes As IEnumerable(Of Bounds) = volumes.Select(Function(volume) Bounds.WorldCoordinateTransform.Invoke(volume))
        Dim volumesAsRectangles As IEnumerable(Of Rectangle) = transformedVolumes.Select(Function(transformedVolume) transformedVolume.ToRectangle(CInt(info.WorldBounds.Height())))

        For Each volume As Rectangle In volumesAsRectangles
            scene.Enqueue(Sub(g) g.DrawRectangle(redDashes, volume))
        Next
    End Sub

    Private Shared Sub SolveCollisions(options As RenderOptions, info As SceneInfo, bvh As BoundingVolumeHierarchy)
        Dim solver As CollisionSolver = New CollisionSolver()

        For Each collision As Pair(Of IShape) In options.CollisionDetectionMethod.GetCollisions(bvh)
            solver.Solve(collision)
            ExtricateShapes(collision)
        Next

        For Each shape As IShape In info.Shapes
            solver.Solve(info.WorldBounds, shape)
        Next
    End Sub

    Private Shared Sub ExtricateShapes(collision As Pair(Of IShape))
        While collision.First.Contains(collision.Second.PointClosestTo(collision.First.Center))
            Dim firstToSecond As Vector = (collision.First.Center - collision.Second.Center).ToUnitVec()
            Dim secondToFirst As Vector = (collision.Second.Center - collision.First.Center).ToUnitVec()

            collision.First.Center += secondToFirst
            collision.Second.Center += firstToSecond
        End While
    End Sub

    Private Shared Sub UpdateShapePositions(options As RenderOptions, shapes As IEnumerable(Of IShape))
        For Each shape As IShape In shapes
            If shape.Velocity <> Vector.Zero Then
                shape.Center += shape.Velocity * options.TimeStep
            End If
        Next
    End Sub

    Private Sub RenderShapes(scene As Queue(Of Action(Of Graphics)), info As SceneInfo)
        Dim brushes As IDictionary(Of Color, Brush) = info.ShapeColors.ToDictionary(Function(color) color, Function(color) CType(New SolidBrush(color), Brush))

        For Each shape As IShape In info.Shapes
            scene.Enqueue(Sub(g) g.FillEllipse(brushes.Item(shape.Color), shape.Bounds().ToRectangleF(CInt(info.WorldBounds.Height()))))
        Next
    End Sub

    Private Sub RenderDrawTime(scene As Queue(Of Action(Of Graphics)), options As RenderOptions)
        Dim averageRenderTime As TimeSpan = _averageRenderTime.Aggregate(Function(left, right) left.Add(right)).Divide(_averageRenderTime.Count)
        Dim formattedAverageRenderTime As String = $"Average Render Time: {averageRenderTime:ffff}µs"

        Dim solidRed As Brush = New SolidBrush(Color.Red)
        Dim eighteenPointGenericMonoSpace As Font = New Font(FontFamily.GenericMonospace, 18.0F, FontStyle.Regular)

        scene.Enqueue(
            Sub(g) g.DrawString(formattedAverageRenderTime, eighteenPointGenericMonoSpace, solidRed,
                                      New RectangleF(New PointF(0.0F, 0.0F),
                                                     g.MeasureString(formattedAverageRenderTime,
                                                                     eighteenPointGenericMonoSpace))))
    End Sub

#End Region

    Public Sub RestrictShapes(worldBounds As Bounds, shapes As IEnumerable(Of IShape))
        For Each shape As IShape In shapes
            Dim shapeBounds As Bounds = shape.Bounds()
            Dim x As Single = shape.Center.X
            Dim y As Single = shape.Center.Y

            If shapeBounds.BottomLeft.X < worldBounds.BottomLeft.X Then x = worldBounds.BottomLeft.X + (shapeBounds.Width() / 2)
            If shapeBounds.BottomLeft.Y < worldBounds.BottomLeft.Y Then y = worldBounds.BottomLeft.Y + (shapeBounds.Height() / 2)
            If worldBounds.TopRight.X < shapeBounds.TopRight.X Then x = worldBounds.TopRight.X - (shapeBounds.Width() / 2)
            If worldBounds.TopRight.Y < shapeBounds.TopRight.Y Then y = worldBounds.TopRight.Y - (shapeBounds.Height() / 2)

            shape.Center = (x, y)
        Next
    End Sub

    Public Sub UpdateShapeCount(count As Integer, info As SceneInfo)
        If count >= 0 Then
            While count > info.Shapes.Count
                AddShape(info)
            End While

            While count < info.Shapes.Count
                RemoveShape(info)
            End While
        End If 
    End Sub

    Private Shared Sub AddShape(info As SceneInfo)
        info.Shapes.Add(GetRandomShape(info.MaxShapeSize, info.MaxShapeSpeed, CInt(info.WorldBounds.Width()),
                                  CInt(info.WorldBounds.Height()), info.ShapeColors.ToArray()))
    End Sub

    Private Shared Sub RemoveShape(info As SceneInfo)
        If info.Shapes.Count > 0 Then
            info.Shapes.Remove(info.Shapes.Last())
        End If
    End Sub

End Class