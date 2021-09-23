using CollisionDetection.Model.BVH;
using CollisionDetection.Model.Collision;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace CollisionDetection.Presentation
{
    internal sealed class RenderOptionsBuilder : IDefaultConsumer
    {
        private bool paused;
        private bool showAverageRenderTime;
        private bool showBoundingVolumes;
        private SplitMethod splitMethod;
        private CollisionDetectionMethod collisionDetectionMethod;
        private byte framesPerSecond;
        private readonly ICollection<Color> availableColors;

        public RenderOptionsBuilder(IDefaultProvider defaultProvider)
        {
            availableColors = new List<Color>();
            defaultProvider.SetDefaults(this);
        }

        public RenderOptionsBuilder(RenderOptions options)
        {
            paused = options.Paused;
            showAverageRenderTime = options.ShowAverageRenderTime;
            showBoundingVolumes = options.ShowBoundingVolumes;
            splitMethod = options.SplitMethod;
            collisionDetectionMethod = options.CollisionDetectionMethod;
            framesPerSecond = options.FramesPerSecond;
            availableColors = options.AvailableColors.ToList();
        }

        public RenderOptions Build()
        {
            return new RenderOptions(paused, showAverageRenderTime, showBoundingVolumes, splitMethod, collisionDetectionMethod, framesPerSecond, availableColors);
        }

        public RenderOptionsBuilder Paused()
        {
            paused = !paused;
            return this;
        }

        public RenderOptionsBuilder WithRenderTimeVisibility(bool visibility)
        {
            showAverageRenderTime = visibility;
            return this;
        }

        public RenderOptionsBuilder WithBoundingVolumeVisibility(bool visibility)
        {
            showBoundingVolumes = visibility;
            return this;
        }

        public RenderOptionsBuilder WithSplitMethod(string methodName)
        {
            splitMethod = SplitMethod.Parse(methodName);
            return this;
        }

        public RenderOptionsBuilder WithCollisionDetectionMethod(string methodName)
        {
            collisionDetectionMethod = CollisionDetectionMethod.Parse(methodName);
            return this;
        }

        public RenderOptionsBuilder WithFramesPerSecond(byte fps)
        {
            framesPerSecond = fps;
            return this;
        }

        public RenderOptionsBuilder WithColor(Color color)
        {
            availableColors.Add(color);
            return this;
        }

        public RenderOptionsBuilder WithoutColor(Color color)
        {
            if (availableColors.Contains(color))
            {
                availableColors.Remove(color);
            }

            return this;
        }

        #region IDefaultConsumer Interface Implementation

        void IDefaultConsumer.SetDefaultAverageRenderTimeVisibility(bool visible)
        {
            showAverageRenderTime = visible;
        }

        void IDefaultConsumer.SetDefaultBoundingVolumeVisibility(bool visible)
        {
            showBoundingVolumes = visible;
        }

        void IDefaultConsumer.SetDefaultBVHSplitMethod(string methodName)
        {
            splitMethod = SplitMethod.Parse(methodName);
        }

        void IDefaultConsumer.SetDefaultBVHSplitMethods(string[] methodNames)
        {
            return;
        }

        void IDefaultConsumer.SetDefaultCollisionDetectionMethod(string methodName)
        {
            collisionDetectionMethod = CollisionDetectionMethod.Parse(methodName);
        }

        void IDefaultConsumer.SetDefaultCollisionDetectionMethods(string[] methodNames)
        {
            return;
        }

        void IDefaultConsumer.SetDefaultFrameRate(byte fps)
        {
            framesPerSecond = fps;
        }

        void IDefaultConsumer.SetDefaultParticleColors(IEnumerable<Color> colors)
        {
            foreach (Color color in colors)
            {
                availableColors.Add(color);
            }
        }

        void IDefaultConsumer.SetDefaultParticleCount(byte count)
        {
            return;
        }

        #endregion
    }
}
