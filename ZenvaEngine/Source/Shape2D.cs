using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ZenvaEngine.Source
{
    internal class Shape2D : GameObject
    {
        public override Vector2 Position { get; set; }
        public override Vector2 Origin { get; set; }
        public override Vector2 Scale { get; set; }
        public override string Tag { get; set; }
        public override List<GameObject> Children { get; set; }
        public enum SHAPES
        {
            RECTANGLE,
            CIRCLE
        }
        public SHAPES shape;

        public Color color = Color.White;
        public Color outLineColor = Color.White;
        public float OutLineThickness = 1.0f;

        public Shape2D(SHAPES shape, Vector2 position, Vector2 scale, string tag, Color color, Color outlinecolor)
        {
            this.shape = shape;
            this.Position = position;
            this.Scale = scale;
            this.Tag = tag;
            this.color = color;
            this.outLineColor = outlinecolor;
            Log.Info($"SHAPE2D {tag} has been registerd!");
        }
        public Shape2D(SHAPES shape, Vector2 position, Vector2 scale, string tag)
        {
            this.shape = shape;
            this.Position = position;
            this.Scale = scale;
            this.Tag = tag;
            Log.Info($"SHAPE2D {tag} has been registerd!");
        }
        public override void OnDestroy()
        {

        }

        public override void OnLoad()
        {

        }

        public override void OnUpdate()
        {
            if (shape == SHAPES.RECTANGLE)
            {
                RectangleShape graphics = new RectangleShape(Scale);
                graphics.Origin = Scale * new Vector2(0.5f, 0.5f);
                graphics.Position = Position;
                graphics.FillColor = color;
                graphics.OutlineColor = outLineColor;
                graphics.OutlineThickness = OutLineThickness;
                Engine.app.Draw(graphics);
            }
            else
            {
                CircleShape graphics = new CircleShape(Scale.x);
                graphics.Origin = Scale * new Vector2(0.5f, 0.5f);
                graphics.Position = Position;
                graphics.FillColor = color;
                graphics.OutlineColor = outLineColor;
                graphics.OutlineThickness = OutLineThickness;
                Engine.app.Draw(graphics);
            }
        }
    }
}