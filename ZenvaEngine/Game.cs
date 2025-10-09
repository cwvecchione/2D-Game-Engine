using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using ZenvaEngine.Source;
namespace ZenvaEngine
{
    internal class Game : Engine
    {
        public Game() : base((uint)800, (uint)800, "Engine Test", Color.Black) { }

        public override void OnLoad()
        {
            // Implement your loading logic here
        }
        public override void OnUpdate()
        {
            base.OnUpdate();
        }
    }
}