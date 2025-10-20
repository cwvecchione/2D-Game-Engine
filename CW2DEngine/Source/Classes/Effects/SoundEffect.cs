using SFML.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW2DEngine.Source.Classes.Effects
{
    internal class SoundEffect
    {
        SoundBuffer Buffer;
        public Sound SoundPlayer;
        public string Tag;

        public SoundEffect(string filePath, string Tag)
        {
            this.Tag = Tag;
            try
            {
                Buffer = new SoundBuffer(filePath);
            }
            catch (Exception ex)
            {
                Log.Error($"Sound File {Tag} was not found, Error {ex}");
                return;
            }

            SoundPlayer = new Sound(Buffer);
        }

    }
}
