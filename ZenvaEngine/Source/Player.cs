using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ZenvaEngine.Source
{
    internal class Player : GameObject
    {
        public override Vector2 Position { get; set; }
        public override Vector2 Origin { get; set; }
        public override Vector2 Scale { get; set; }
        public override string Tag { get; set; }
        public override List<GameObject> Children { get; set; }

        public Player(Vector2 position, Vector2 scale, string tag) : base(position, scale, tag)
        {
            this.Position = position;
            this.Scale = scale;
            this.Tag = tag;
        }

        public override void OnUpdate()
        {
            if (Input.ActionPressed("Right"))
            {
                player.Position.x += 1;
            }
            if (Input.ActionPressed("Left"))
            {
                player.Position.x -= 1;
            }
        }
    }
}
