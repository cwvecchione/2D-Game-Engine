using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CW2DEngine.Source;
using CW2DEngine.Source.Classes;
using CW2DEngine.Source.Classes.GameObjectClasses;
using SFML.Graphics;

namespace CW2DEngine
{
    internal class Enemy : KinematicBody
    {
        public override Vector2 Position { get; set; }
        public override Vector2 Origin { get; set; }
        public override Vector2 Scale { get; set; }
        public override string Tag { get; set; }
        public override List<GameObject> Children { get; set; }

        public string Name { get; set; }
        public int HP { get; set; }
        public int MaxHP { get; set; }
        public int Attack { get; set; }
        public string RunImage { get; set; }
        public string IdleImage { get; set; }
        public int Speed { get; set; }


        AnimatedSprite2D animator;

        bool LookingRight = true;

        public Enemy(Vector2 position, Vector2 scale, string tag) : base(position, scale, tag)
        {
            Position = position;
            Scale = scale;
            Tag = tag;
        }

        public override void OnLoad()
        {
            animator = new AnimatedSprite2D(1f, new Vector2(4, 4), "Enemy graphics");
            Animation2D run = new Animation2D("Assets/Run.png", new Vector2(16, 16), 4);
            Animation2D idle = new Animation2D("Assets/idle.png", new Vector2(16, 16), 1);
            animator.AddAnimation("Run", run);
            animator.AddAnimation("Idle", idle);
            AddChild(animator);

            base.OnLoad();
        }

        public override void OnUpdate()
        {
            velocity = velocity.Normalize() * new Vector2(speed, speed);

            Move();
            HandleAnimations();

            base.OnUpdate();
        }

        void HandleAnimations()
        {
            if(velocity.x == 0 && velocity.y == 0)
            {
                animator.Play("Idle");
            }
            else
            {
                animator.Play("Run");
            }

            if(velocity.x > 0 && !LookingRight)
            {
                flip();
            }
            if(velocity.x < 0 && LookingRight)
            {
                flip();
            }
        }

        void flip()
        {
            animator.FlipH = -animator.FlipH;
            LookingRight = !LookingRight;
        }
    }
}
