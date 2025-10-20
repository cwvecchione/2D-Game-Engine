using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Game.Source.Classes.Effects;

namespace Test_Game.Source.Classes
{
    internal class SoundEffectPlayer
    {
        public string Tag;
        public int Volume = 100;
        public Dictionary<string, SoundEffect> AllSounds = new Dictionary<string, SoundEffect>();

        public SoundEffectPlayer(int volume)
        {
            Volume = volume;
        }

        public void AddSFX(SoundEffect sfx)
        {
            AllSounds.Add(sfx.Tag, sfx);
        }

        public void RemoveSFX(SoundEffect sfx)
        {
            if (!AllSounds.ContainsKey(sfx.Tag)) { return; }
            AllSounds.Remove(sfx.Tag);
        }

        public void Play(string sfxName)
        {
            if (!AllSounds.ContainsKey(sfxName)) { return; }
            AllSounds[sfxName].SoundPlayer.Volume = Volume;
            AllSounds[sfxName].SoundPlayer.Play();
        }
    }
}
