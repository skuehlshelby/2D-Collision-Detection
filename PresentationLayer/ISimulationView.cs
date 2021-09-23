
using System;
using System.Drawing;

public interface ISimulationView
{
    event EventHandler PauseRequested;

    event EventHandler<byte> ShapeCountChanged;

    event EventHandler<byte> FrameRateChanged;

    event EventHandler<bool> ShowBoundingVolumesChanged;

    event EventHandler<bool> ShowAverageRenderTimeChanged;

    event EventHandler<string> SplitMethodChanged;

    event EventHandler<string> CollisionDetectionMethodChanged;

    event EventHandler<Color> ColorAdded;

    event EventHandler<Color> ColorRemoved;

    event EventHandler<Size> Resized;

    Size SceneDimensions { get; }
}


