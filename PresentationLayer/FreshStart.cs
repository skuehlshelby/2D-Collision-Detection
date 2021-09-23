using CollisionDetection.Model.BVH;
using CollisionDetection.Model.Collision;
using System.Drawing;
using System.Linq;

namespace CollisionDetection.Presentation
{
    public sealed class FreshStart : IDefaultProvider
    {
        void IDefaultProvider.SetDefaults(IDefaultConsumer consumer)
        {
            consumer.SetDefaultAverageRenderTimeVisibility(visible: false);
            consumer.SetDefaultBoundingVolumeVisibility(visible: false);
            consumer.SetDefaultBVHSplitMethod(SplitMethod.Midpoint.Name);
            consumer.SetDefaultBVHSplitMethods(SplitMethod.Values().Select(method => method.Name).ToArray());
            consumer.SetDefaultCollisionDetectionMethod(CollisionDetectionMethod.Discrete.Name);
            consumer.SetDefaultCollisionDetectionMethods(CollisionDetectionMethod.Values().Select(method => method.Name).ToArray());
            consumer.SetDefaultFrameRate(fps: 30);
            consumer.SetDefaultParticleColors(new Color[] {Color.CornflowerBlue, Color.Goldenrod, Color.DarkCyan });
            consumer.SetDefaultParticleCount(0);
        }
    }
}
