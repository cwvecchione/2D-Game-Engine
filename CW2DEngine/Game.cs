using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CW2DEngine.Levels;
using CW2DEngine.Source;
using SFML.Graphics;

namespace CW2DEngine
{
    internal class Game : Engine
    {
        public Game() : base(800, 800, "RPG Engine Test", Color.Black) { }

        

        public override void OnLoad()
        {
            DemoScene level1 = new DemoScene("level1");
            Win level2 = new Win("Win");
            LevelManager.ChangeLevel("level1");
            
        }

        public override void OnUpdate()
        {

            base.OnUpdate();
        }
    }
}
