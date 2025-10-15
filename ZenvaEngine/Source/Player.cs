using SFML.Graphics;
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

        public override void OnLoad()
        {
            Sprite2D sprite = new Sprite2D("Assets/idle.png", new Vector2(), new Vector2(16, 16), new Vector2(4, 4), "Player's sprite");
            AddChild(sprite);

            AnimatedSprite2D animator = new AnimatedSprite2D(1f, new Vector2(4, 4), "Player graphics");
            animator.FrameTime = 0.5f;
            Animation2D run = new Animation2D("Assets/Run.png", new Vector2(16, 16), 4);
            animator.AddAnimation("Run", run);
            AddChild(animator);
            Animation2D idle = new Animation2D("Assets/idle.png", new Vector2(16, 16), 1);
            animator.AddAnimation("Idle", idle);
        }

        public override void OnUpdate()
        {
            if (Input.ActionPressed("Right"))
            {
                Position.x += 1;
                animator.FlipH = 1;
                animator.Play("Run");
            }
            else if (Input.ActionPressed("Left"))
            {
                Position.x -= 1;
                animator.FlipH = -1;
                animator.Play("Run");
            }
            else
            {
                animator.Play("Idle");
            }
            currentAnimation.frameRectangle = new IntRect((int)(CurrentFrame * currentAnimation.FrameSize.x), 0, (int)currentAnimation.FrameSize.x, (int)currentAnimation.FrameSize.y);
            currentAnimation.sprite.Position = Position;
            currentAnimation.sprite.Scale = new Vector2(Scale.x * FlipH, Scale.y * FlipV);
            currentAnimation.sprite.TextureRect = currentAnimation.frameRectangle;
            Engine.app.Draw(currentAnimation.sprite);
        }
    }
}
