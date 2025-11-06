using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CW2DEngine.Source;
using SFML.Graphics;

namespace CW2DEngine.GameObjects
{
    internal class Player : KinematicBody
    {
        public override Vector2 Position { get; set; }
        public override Vector2 Origin { get; set; }
        public override Vector2 Scale { get; set; }
        public override string Tag { get; set; }
        public override List<GameObject> Children { get; set; }

        int speed = 200;
        bool LookingRight = true;
        public int Level { get; set; } = 1;
        public int XP { get; set; } = 0;
        public int HP { get; set; } = 100;
        public int MaxHP { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Agility { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Magic { get; set; } = 10;
        public int Gold { get; set; } = 50;
        public Dictionary<string, int> Inventory { get; set; } = new Dictionary<string, int> { { "Potion", 2 }, { "Sword", 1 } };
        public List<string> Equipment { get; set; } = new List<string>();
        public List<string> Abilities { get; set; } = new List<string> { "Fireball", "Heal" };
        AnimatedSprite2D animator;
        Camera cam;

        public Player(Vector2 position, Vector2 scale, string tag) : base(position, scale, tag)
        {
            Position = position;
            Scale = scale;
            Tag = tag;
        }

        public override void OnLoad()
        {
            animator = new AnimatedSprite2D(1f, new Vector2(4, 4), "Player Graphics");
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
            if (velocity.x == 0 && velocity.y == 0)
            {
                animator.Play("Idle");
            }
            else
            {
                animator.Play("Run");
            }

            if (velocity.x > 0 && !LookingRight)
            {
                flip();
            }
            if (velocity.x < 0 && LookingRight)
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
