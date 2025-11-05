using CW2DEngine.Source.Classes;
using CW2DEngine.Source.Classes.GameObjectClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace CW2DEngine.Source.GameObjects
{
    internal class RedEnemy : Enemy
    {
        public RedEnemy(Vector2 position, Vector2 scale, string tag) : base(position, scale, tag)
        {
            Position = position;
            Scale = scale;
            Tag = tag;
        }

        public override void OnLoad()
        {
            animator = new AnimatedSprite2D(1f, new Vector2(4, 4), "Enemy graphics");
            Animation2D run = new Animation2D("Assets/RedEnemyRun.png", new Vector2(16, 16), 4);
            Animation2D idle = new Animation2D("Assets/RedEnenyIdle.png", new Vector2(16, 16), 1);
            string RunImage = "RedEnemyRun"
            string IdleImage = "RedEnemyIdle"
            AddChild(animator);
            int Speed = 50
            int GoldDrop = 100

            base.OnLoad();
        }

    }
}
