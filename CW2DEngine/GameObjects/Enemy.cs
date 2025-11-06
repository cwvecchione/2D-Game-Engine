using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CW2DEngine.RPG;
using CW2DEngine.Source;
using SFML.Graphics;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace CW2DEngine.GameObjects
{
    internal class Enemy : KinematicBody
    {
        public override Vector2 Position { get; set; }
        public override Vector2 Origin { get; set; }
        public override Vector2 Scale { get; set; }
        public override string Tag { get; set; }
        public override List<GameObject> Children { get; set; }
        public int Speed { get; set; }
        public StatBlock Stats { get; set; }
        public string Image { get; set; }
        public string IdleImage { get; set; }

        AnimatedSprite2D animator;
        bool LookingRight = true;

        public Enemy(Vector2 position, Vector2 scale, string tag, int speed, StatBlock stats, string image, string idleImage) : base(position, scale, tag)
        {
            Position = position;
            Scale = scale;
            Tag = tag;
            Speed = speed;
            Image = image;
            IdleImage = idleImage;
            Stats = stats;
        }

        public override void OnLoad()
        {
            animator = new AnimatedSprite2D(1f, new Vector2(4, 4), "Enemy Graphics");
            Animation2D run = new Animation2D(Image, new Vector2(16, 16), 4);
            animator.AddAnimation("Run", run);

            if (IdleImage != null)
            {
                Animation2D idle = new Animation2D(IdleImage, new Vector2(16, 16), 1);
                animator.AddAnimation("Idle", idle);
            }
            
            AddChild(animator);

            base.OnLoad();
        }

        public override void OnUpdate()
        {
            velocity = velocity.Normalize() * new Vector2(Speed, Speed);

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
