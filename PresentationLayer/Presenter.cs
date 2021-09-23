using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using CollisionDetection.Model;
using CollisionDetection.Model.BVH;
using CollisionDetection.Model.Collision;

namespace CollisionDetection.Presentation
{
    public sealed class Presenter : ISimulationPresenter
    {
        private SceneInfo sceneInfo;
        private RenderOptions renderOptions;
        private readonly IList<TimeSpan> renderTimes = new List<TimeSpan>();
        private TimeSpan averageRenderTime = new TimeSpan();

        public Presenter(IDefaultProvider defaultProvider, ISimulationView view)
        {
            sceneInfo = new SceneInfoBuilder(view.SceneDimensions).Build();
            renderOptions = new RenderOptionsBuilder(defaultProvider).Build();

            view.CollisionDetectionMethodChanged += OnCollisionDetectionMethodChange;
            view.ColorAdded += OnColorAdded;
            view.ColorRemoved += OnColorRemoved;
            view.FrameRateChanged += OnFrameRateChanged;
            view.PauseRequested += OnPauseRequested;
            view.ShapeCountChanged += OnShapeCountChanged;
            view.ShowAverageRenderTimeChanged += OnShowAverageRenderTimeChanged;
            view.ShowBoundingVolumesChanged += OnShowBoundingVolumesChanged;
            view.SplitMethodChanged += OnSplitMethodChanged;
            view.Resized += OnResized;
        }

        IList<Action<Graphics>> ISimulationPresenter.GetScene()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            IList<Action<Graphics>> scene = new List<Action<Graphics>>();

            if (sceneInfo.Shapes.Any())
            {
                if (!renderOptions.Paused)
                {
                    BoundingVolumeHierarchy bvh = new BoundingVolumeHierarchy(sceneInfo.Shapes.ToArray(), renderOptions.SplitMethod);

                    SolveCollisions(renderOptions, sceneInfo, bvh);

                    UpdateShapePositions(renderOptions, sceneInfo.Shapes);
                }

                if (renderOptions.ShowBoundingVolumes)
                {
                    RenderBvhBounds(scene, sceneInfo, new BoundingVolumeHierarchy(sceneInfo.Shapes.ToArray(), renderOptions.SplitMethod).GetBoundingVolumes());
                }

                RenderShapes(scene, renderOptions, sceneInfo);
            }


            if (renderOptions.ShowAverageRenderTime)
            {
                stopwatch.Stop();
                renderTimes.Add(stopwatch.Elapsed);
                RenderDrawTime(scene, renderOptions);
            }

            return scene;
        }

        private void SolveCollisions(RenderOptions renderOptions, SceneInfo sceneInfo, BoundingVolumeHierarchy bvh)
        {
            CollisionSolver solver  = new CollisionSolver();

            foreach (Pair<IShape> collision in renderOptions.CollisionDetectionMethod.GetCollisions(bvh))
            {
                solver.Solve(collision);
                //ExtricateShapes(collision);
            }

            foreach (IShape shape in sceneInfo.Shapes)
            {
                solver.Solve(sceneInfo.WorldBounds, shape);
            }
        }

        private void ExtricateShapes(Pair<IShape> collision)
        {
            while (collision.First.Contains(collision.Second.PointClosestTo(collision.First.Center)))
            {
                Vector firstToSecond = (collision.First.Center - collision.Second.Center).ToUnitVec();
                Vector secondToFirst = (collision.Second.Center - collision.First.Center).ToUnitVec();

                collision.First.Center += secondToFirst;
                collision.Second.Center += firstToSecond;
            }
        }

        private void UpdateShapePositions(RenderOptions renderOptions, IEnumerable<IShape> shapes)
        {
            foreach (IShape shape in shapes)
            {
                if (shape.Velocity != Vector.Zero)
                {
                    shape.Center += shape.Velocity * (1.0F / renderOptions.FramesPerSecond);
                }
            }
        }

        private void RenderBvhBounds(IList<Action<Graphics>> scene, SceneInfo sceneInfo, IEnumerable<Bounds> bounds)
        {
            Pen redDashes = new Pen(Color.Red){ DashStyle = DashStyle.Dash };

            foreach (Bounds b in bounds)
            {
                scene.Add(g => g.DrawRectangle(redDashes, (Rectangle)b));
            }
        }

        private void RenderShapes(IList<Action<Graphics>> scene, RenderOptions renderOptions,  SceneInfo sceneInfo)
        {
            foreach (IShape shape in sceneInfo.Shapes)
            {
                scene.Add(g => g.FillEllipse(new SolidBrush(shape.Color), shape.Bounds()));
            }
        }

        private void RenderDrawTime(IList<Action<Graphics>> scene, RenderOptions renderOptions)
        {
            if (renderTimes.Count >= renderOptions.FramesPerSecond)
            {
                averageRenderTime = new TimeSpan(renderTimes.Aggregate((left, right) => left.Add(right)).Ticks / renderTimes.Count);
                renderTimes.Clear();
            }

            string formattedAverageRenderTime = $"Average Render Time: {averageRenderTime:ffff}µs";

            Brush solidRed = new SolidBrush(Color.Red);
            Font eighteenPointGenericMonoSpace = new Font(FontFamily.GenericMonospace, 18.0F, FontStyle.Regular);

            scene.Add(g => g.DrawString(formattedAverageRenderTime,
                                        eighteenPointGenericMonoSpace,
                                        solidRed,
                                        new RectangleF(new PointF(0.0F, 0.0F), g.MeasureString(formattedAverageRenderTime, eighteenPointGenericMonoSpace))));
        }

        #region Event Handling

        private void OnResized(object sender, Size e)
        {
            sceneInfo = new SceneInfoBuilder(sceneInfo).WithWorldBounds(e).Build();
        }

        private void OnShapeCountChanged(object sender, byte e)
        {
            sceneInfo = new SceneInfoBuilder(sceneInfo).WithShapeCount(e, renderOptions).Build();
        }

        private void OnSplitMethodChanged(object sender, string e)
        {
            renderOptions = new RenderOptionsBuilder(renderOptions).WithSplitMethod(e).Build();
        }

        private void OnShowBoundingVolumesChanged(object sender, bool e)
        {
            renderOptions = new RenderOptionsBuilder(renderOptions).WithBoundingVolumeVisibility(e).Build();
        }

        private void OnShowAverageRenderTimeChanged(object sender, bool e)
        {
            renderOptions = new RenderOptionsBuilder(renderOptions).WithRenderTimeVisibility(e).Build();
        }

        private void OnPauseRequested(object sender, EventArgs e)
        {
            renderOptions = new RenderOptionsBuilder(renderOptions).Paused().Build();
        }

        private void OnFrameRateChanged(object sender, byte e)
        {
            renderOptions = new RenderOptionsBuilder(renderOptions).WithFramesPerSecond(e).Build();
        }

        private void OnColorRemoved(object sender, Color e)
        {
            renderOptions = new RenderOptionsBuilder(renderOptions).WithoutColor(e).Build();
        }

        private void OnColorAdded(object sender, Color e)
        {
            renderOptions = new RenderOptionsBuilder(renderOptions).WithColor(e).Build();
        }

        private void OnCollisionDetectionMethodChange(object sender, string e)
        {
            renderOptions = new RenderOptionsBuilder(renderOptions).WithCollisionDetectionMethod(e).Build();
        }

        #endregion

    }
}
