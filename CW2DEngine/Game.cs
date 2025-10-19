using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CW2DEngine.Source;
using CW2DEngine.Source.Classes;
using CW2DEngine.Source.GameObjects;
using CW2DEngine.Source.Scenes;
using SFML.Graphics;

namespace CW2DEngine
{
    internal class Game : Engine
    {
        public Game() : base(800, 800, "Engine Test", Color.Black) { }

        

        public override void OnLoad()
        {
            Demo_Scene level1 = new Demo_Scene("level1");
            Win level2 = new Win("Win");
            LevelManager.ChangeLevel("level1");
            
        }

        public override void OnUpdate()
        {

            base.OnUpdate();
        }
    }
}
