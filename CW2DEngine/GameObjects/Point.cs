using nkast.Aether.Physics2D.Dynamics;
using nkast.Aether.Physics2D.Dynamics.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using CW2DEngine.Source;

namespace CW2DEngine.GameObjects
{
    internal class Point : StaticBody
    {

        SoundEffectPlayer soundEffectPlayer;

        public Point(Vector2 position, Vector2 scale, string tag) : base(position, scale, tag)
        {
            Position = position;
            Scale = scale;
            Tag = tag;
        }

        public override void OnLoad()
        {
            AddChild(new Shape2D(Shape2D.SHAPES.RECTANGLE, Position, Scale, Tag, Color.Green, Color.Green));
            onCollisionEventHandlers.Add(Collision_OnCollision);

            soundEffectPlayer = new SoundEffectPlayer(100);
            soundEffectPlayer.AddSFX(new SoundEffect("Assets/sfx.ogg", "point"));


            base.OnLoad();
        }

        private bool Collision_OnCollision(Fixture sender, Fixture other, Contact contact)
        {
            soundEffectPlayer.Play("point");
            Log.Info("playing sfx");
            DestorySelf();
            return true;
        }
    }
}
