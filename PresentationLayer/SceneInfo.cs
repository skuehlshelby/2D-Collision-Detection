using CollisionDetection.Model;
using System.Collections.Generic;

namespace CollisionDetection.Presentation
{
    internal sealed class SceneInfo
    {
        public SceneInfo(Bounds worldBounds, IList<IShape> shapes)
        {
            WorldBounds = worldBounds;
            Shapes = shapes;
        }

        public Bounds WorldBounds {get;}
        
        public IEnumerable<IShape> Shapes {get;}

    }
}
