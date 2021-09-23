using CollisionDetection.Model.BVH;
using CollisionDetection.Model.Collision;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace CollisionDetection.Presentation
{
    internal sealed class RenderOptions
    {
        public RenderOptions(bool paused, bool showAverageRenderTime, bool showBoundingVolumes, SplitMethod splitMethod, CollisionDetectionMethod collisionDetectionMethod, byte framesPerSecond, IEnumerable<Color> availableColors)
        {
            Paused = paused;
            ShowAverageRenderTime = showAverageRenderTime;
            ShowBoundingVolumes = showBoundingVolumes;
            SplitMethod = splitMethod;
            CollisionDetectionMethod = collisionDetectionMethod;
            FramesPerSecond = framesPerSecond;
            AvailableColors = availableColors;
        }

        public bool Paused {get;}

        public bool ShowAverageRenderTime { get; }
        
        public bool ShowBoundingVolumes { get; }
        
        public SplitMethod SplitMethod { get; }
        
        public CollisionDetectionMethod CollisionDetectionMethod { get; }
        
        public byte FramesPerSecond { get; }

        public IEnumerable<Color> AvailableColors { get; }

    }
}
