using CollisionDetection.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace CollisionDetection.Presentation
{
    internal sealed class SceneInfoBuilder
    {
        private Bounds worldBounds;
        
        private readonly IList<IShape> shapes;

        public SceneInfoBuilder(Size sceneSize)
        {
            worldBounds = new Bounds((0.0F, 0.0F), (sceneSize.Width, sceneSize.Height));
            shapes = new List<IShape>();
        }

        public SceneInfoBuilder(SceneInfo info)
        {
            worldBounds = info.WorldBounds;
            shapes = info.Shapes.ToList();
        }

        public SceneInfoBuilder WithWorldBounds(Size size)
        {
            worldBounds = new Bounds((0.0F, 0.0F), (size.Width, size.Height));
            return this;
        }

        public SceneInfo Build()
        {
            return new SceneInfo(worldBounds, shapes);
        }

        public SceneInfoBuilder WithShapeCount(int count, RenderOptions options)
        {
            if (count == 0)
            {
                shapes.Clear();
            }

            if (count < 60 && 0 < count)
            {
                while (count < shapes.Count)
                {
                    shapes.Remove(shapes.Last());
                }

                while(shapes.Count < count)
                {
                    shapes.Add(RandomShape(options));
                }
            }

            return this;
        }

        private IShape RandomShape(RenderOptions options)
        {
            Random random = new Random();
            float radius = random.Next(5, 40);
            Color color = options.AvailableColors.ElementAt(random.Next(options.AvailableColors.Count()));
            Model.Point center = (random.Next((int)worldBounds.BottomLeft.X, (int)worldBounds.TopRight.X), random.Next((int)worldBounds.BottomLeft.Y, (int)worldBounds.TopRight.Y));
            Vector velocity = (random.Next(-40, 40), random.Next(-40, 40));

            return new Circle(radius, color, center, velocity);
        }
    }
}
