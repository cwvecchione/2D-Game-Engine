using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW2DEngine.Source.Classes.GameObjectClasses
{
    internal class Sprite2D : GameObject
    {
        public override Vector2 Position { get; set; }
        public override Vector2 Origin { get; set; }
        public override Vector2 Scale { get; set; }
        public override string Tag { get; set; }
        public override List<GameObject> Children { get; set; }
        private Texture Texture { get; set; }
        private Vector2 FrameSize { get; set; }
        public Sprite sprite { get; set; }


        public Sprite2D(string texturePath, Vector2 position, Vector2 frameSize, Vector2 scale, string tag)
        {
            Position = position;
            FrameSize = frameSize;
            Scale = scale;
            Tag = tag;

            try
            {
                Texture = new Texture(texturePath);
            }
            catch (Exception ex)
            {
                Log.Error($"Sprite2D Texture was not found, Error: {ex}");
            }

            sprite = new Sprite(Texture);
            sprite.Origin = frameSize * new Vector2(0.5f, 0.5f);
        }

        public override void OnDestroy()
        {

        }

        public override void OnLoad()
        {

        }

        public override void OnUpdate()
        {
            sprite.Position = Position;
            sprite.Scale = Scale;
            Engine.app.Draw(sprite);
        }
    }
}
