using nkast.Aether.Physics2D.Dynamics;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW2DEngine.Source.Classes
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

        public List<OnCollisionEventHandler> onCollisionEventHandlers = new List<OnCollisionEventHandler>();
        public List<OnSeparationEventHandler> onSeparationEventHandlers = new List<OnSeparationEventHandler>();


        public StaticBody(Vector2 position, Vector2 scale, string tag)
        {
            Position = position;
            Scale = scale;
            Tag = tag;
            shape = new Shape2D(Shape2D.SHAPES.RECTANGLE, Position, Scale, tag, Color.Transparent, Color.Transparent);
        }

        public override void OnDestroy()
        {
            shape.DestorySelf();
            if (Engine.world.BodyList.Contains(body)) { Engine.world.Remove(body); }
        }

        public override void OnLoad()
        {
            body = Engine.world.CreateBody(Position);
            body.CreateRectangle(Scale.x, Scale.y, 1f, new Vector2());
            body.BodyType = BodyType.Static;
            body.IgnoreGravity = true;
            body.IgnoreCCD = collisionDisabled;
            body.FixtureList[0].Tag = Tag;

            onCollisionEventHandlers.Add(Body_OnCollision);
            onSeparationEventHandlers.Add(Body_OnSeparation);

            foreach (OnCollisionEventHandler handler in onCollisionEventHandlers)
            {
                body.OnCollision += handler;
            }

            foreach (OnSeparationEventHandler handler in onSeparationEventHandlers)
            {
                body.OnSeparation += handler;
            }

        }


        public override void OnUpdate()
        {
            Position = new Vector2(body.Position.X, body.Position.Y);
            shape.Position = Position;
        }

        public void CollisionDebug(bool debugValue)
        {
            collisionDebug = debugValue;

            if (collisionDebug) { shape.color = Color.Green; }
            else { shape.color = Color.Transparent; }
        }

        private void Body_OnSeparation(Fixture sender, Fixture other, nkast.Aether.Physics2D.Dynamics.Contacts.Contact contact)
        {

        }

        private bool Body_OnCollision(Fixture sender, Fixture other, nkast.Aether.Physics2D.Dynamics.Contacts.Contact contact)
        {
            return true;
        }
    }
}
