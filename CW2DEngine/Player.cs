using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CW2DEngine.Source;
using CW2DEngine.Source.Classes;
using SFML.Graphics;

namespace CW2DEngine
{
    internal class Player : KinematicBody
    {
        public override Vector2 Position { get; set; }
        public override Vector2 Origin { get; set; }
        public override Vector2 Scale { get; set; }
        public override string Tag { get; set; }
        public override List<GameObject> Children { get; set; }

        AnimatedSprite2D animator;
        Camera cam;
        int speed = 200;

        bool LookingRight = true;

        public Player(Vector2 position, Vector2 scale, string tag) : base(position, scale, tag)
        {
            Position = position;
            Scale = scale;
            Tag = tag;
        }

        public override void OnLoad()
        {
            animator = new AnimatedSprite2D(1f, new Vector2(4, 4), "Player graphics");
            Animation2D run = new Animation2D("Assets/Run.png", new Vector2(16, 16), 4);
            Animation2D idle = new Animation2D("Assets/idle.png", new Vector2(16, 16), 1);
            animator.AddAnimation("Run", run);
            animator.AddAnimation("Idle", idle);
            AddChild(animator);
            cam = new Camera(true, "player camera");
            AddChild(cam);

            base.OnLoad();
        }

        public override void OnUpdate()
        {
            velocity.x = Convert.ToInt32(Input.ActionPressed("Right")) - Convert.ToInt32(Input.ActionPressed("Left"));
            velocity.y = Convert.ToInt32(Input.ActionPressed("Down")) - Convert.ToInt32(Input.ActionPressed("Up"));

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
