using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace CW2DEngine.Source.Classes.GameObjectClasses
{
    internal class AnimatedSprite2D : GameObject
    {
        public override Vector2 Position { get; set; }
        public override Vector2 Origin { get; set; }
        public override Vector2 Scale { get; set; }
        public override string Tag { get; set; }
        public override List<GameObject> Children { get; set; }

        public float FrameTime { get; set; }
        public int FlipH = 1;
        public int FlipV = 1;

        public Animation2D currentAnimation { get; set; }
        public string currentAnimationName { get; set; }


        private Dictionary<string, Animation2D> AllAnimations = new Dictionary<string, Animation2D>();

        private int CurrentFrame = 0;
        private float elapsedTime;

        public AnimatedSprite2D(float frameTime, Vector2 scale, string tag)
        {
            FrameTime = frameTime / 10;
            Scale = scale;
            Position = Vector2.Zero();
            Tag = tag;
        }


        public void Play(string animationName)
        {
            if (animationName.Equals(currentAnimationName)) { return; }
            if (AllAnimations.ContainsKey(animationName))
            {
                currentAnimation = AllAnimations[animationName];
                currentAnimationName = animationName;
                CurrentFrame = 0;
            }
            else
            {
                Log.Error($"Animation {animationName} does not exist!");
            }

        }

        public void AddAnimation(string animationName, Animation2D animation)
        {
            AllAnimations.Add(animationName, animation);
            currentAnimation = animation;
            currentAnimationName = animationName;
        }

        public void RemoveAnimation(string animationName)
        {
            if (AllAnimations.ContainsKey(animationName))
            {
                AllAnimations.Remove(animationName);
            }
        }






        public override void OnDestroy()
        {

        }

        public override void OnLoad()
        {

        }

        public override void OnUpdate()
        {
            if (currentAnimation == null) { return; }

            elapsedTime += Time.deltaTime;

            //Log.Normal($"Current Frame {CurrentFrame}");

            if (elapsedTime >= FrameTime && currentAnimation.TotalFrames != 1)
            {
                CurrentFrame = CurrentFrame == currentAnimation.TotalFrames - 1 ? 0 : CurrentFrame + 1;
                elapsedTime = 0f;
            }

            currentAnimation.frameRectangle = new IntRect((int)(CurrentFrame * currentAnimation.FrameSize.x), 0, (int)currentAnimation.FrameSize.x, (int)currentAnimation.FrameSize.y);

            currentAnimation.sprite.Position = Position;
            currentAnimation.sprite.Scale = new Vector2(Scale.x * FlipH, Scale.y * FlipV);
            currentAnimation.sprite.TextureRect = currentAnimation.frameRectangle;

            Engine.app.Draw(currentAnimation.sprite);
        }
    }
}
