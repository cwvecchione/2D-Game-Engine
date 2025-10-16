using nkast.Aether.Physics2D.Dynamics;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ZenvaEngine.Source
{
    internal class StaticBody : GameObject
    {
        public override Vector2 Position { get; set; }
        public override Vector2 Origin { get; set; }
        public override Vector2 Scale { get; set; }
        public override string Tag { get; set; }
        public override List<GameObject> Children { get; set; }

        public Body body;
        public bool collisionDisabled = false;
        public bool collisionDebug = false;
        private Shape2D shape;

        public StaticBody(Vector2 position, Vector2 scale, string tag)
        {
            this.Position = position;
            this.Scale = scale;
            this.Tag = tag;
            shape = new Shape2D(Shape2D.SHAPES.RECTANGLE, Position, Scale, tag, Color.Transparent, Color.Transparent);
        }

        public override void OnDestroy()
        {
            shape.DestorySelf();
        }
    }
}