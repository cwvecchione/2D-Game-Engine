using SFML.Graphics;

namespace ZenvaEngine.Source
{
    internal class Animation2D
    {
        public Sprite sprite { get; set; }
        public Texture texture { get; set; }
        public Vector2 FrameSize { get; set; }
        public int TotalFrames { get; set; }
        public string tag { get; set; }
        public IntRect frameRectangle { get; set; }

        public Animation2D(string spriteSheetPath, Vector2 frameSize, int totalFrames)
        {
            this.FrameSize = frameSize;
            this.TotalFrames = totalFrames;
            try
            {
                texture = new Texture(spriteSheetPath);
            }
            catch (Exception ex)
            {
                Log.Error($"SpriteSheet Was not found!, Error: {ex}");
            }
            sprite = new Sprite(texture);
            frameRectangle = new IntRect((int)frameSize.x, 0, (int)frameSize.x, (int)
            frameSize.y);
            sprite.Origin = frameSize * new Vector2(0.5f, 0.5f);
            Log.Info("Animation2D has registered!");
        }
    }
}
