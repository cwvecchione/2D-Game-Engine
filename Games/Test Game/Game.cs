using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Game.Source;
using Test_Game.Source.Classes;
using Test_Game.Source.Scenes;

namespace Test_Game
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
