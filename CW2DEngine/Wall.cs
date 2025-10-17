using CW2DEngine.Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW2DEngine
{
    internal class Wall : StaticBody
    {
        public Wall(Vector2 position, Vector2 scale, string tag) : base(position, scale, tag)
        {
            Position = position;
            Scale = scale;
            Tag = tag;
        }

        public override void OnLoad()
        {
            AddChild(new Shape2D(Shape2D.SHAPES.RECTANGLE, new Vector2(), Scale, Tag));


            base.OnLoad();
        }
    }
}
