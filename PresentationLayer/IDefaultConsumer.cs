using System.Drawing;
using System.Collections.Generic;

public interface IDefaultConsumer
{
    void SetDefaultParticleCount(byte count);

    void SetDefaultFrameRate(byte fps);

    void SetDefaultBoundingVolumeVisibility(bool visible);

    void SetDefaultAverageRenderTimeVisibility(bool visible);

    void SetDefaultBVHSplitMethod(string methodName);

    void SetDefaultBVHSplitMethods(string[] methodNames);

    void SetDefaultCollisionDetectionMethod(string methodName);

    void SetDefaultCollisionDetectionMethods(string[] methodNames);

    void SetDefaultParticleColors(IEnumerable<Color> colors);
}

