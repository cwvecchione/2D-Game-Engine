using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nkast.Aether.Physics2D.Dynamics.Contacts;
using nkast.Aether.Physics2D.Dynamics;
using SFML.Graphics;
using CW2DEngine.Source.Classes;
using CW2DEngine.Source.Classes.GameObjects;
using CW2DEngine.Source.Objects;

namespace CW2DEngine.Source.Scenes
{
    internal class Win : Level
    {
        public override string LevelName { get; set; }
        public override bool Init { get; set; }

        Player player;
        Label WinLabel;

        public Win(string levelName) : base(levelName)
        {

        }


        public override void OnLoad()
        {
            player = new Player(new Vector2(400, 400), new Vector2(50, 50), "player");
            Wall wall1 = new Wall(new Vector2(400, 0), new Vector2(800, 20), "wall");
            Wall wall2 = new Wall(new Vector2(400, 800), new Vector2(800, 20), "wall");
            Wall wall3 = new Wall(new Vector2(0, 400), new Vector2(20, 800), "wall");
            Wall wall4 = new Wall(new Vector2(800, 400), new Vector2(20, 800), "wall");
            WinLabel = new Label("You Won!", 32, new Vector2(400, 100), Color.White, "scoreLabel", true);
        }

        public override void OnUpdate()
        {

        }
    }
}
