using CW2DEngine.GameObjects;
using CW2DEngine.RPG;
using CW2DEngine.Source;
using CW2DEngine.Source.Classes;
using nkast.Aether.Physics2D.Dynamics;
using nkast.Aether.Physics2D.Dynamics.Contacts;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW2DEngine.Levels
{
    internal class Lose : Level
    {
        public override string LevelName { get; set; }
        public override bool Init { get; set; }

        Enemy red;
        Label LoseLabel;

        public Lose(string levelName) : base(levelName)
        {

        }


        public override void OnLoad()
        {
            red = new Enemy(new Vector2(400, 400), new Vector2(50, 50), "red", 50, new StatBlock("Red Bandit", 10, 10, 5, 0, ["sword"]), "Assets/RedEnemyRun.png", "");
            Wall wall1 = new Wall(new Vector2(400, 0), new Vector2(800, 20), "wall");
            Wall wall2 = new Wall(new Vector2(400, 800), new Vector2(800, 20), "wall");
            Wall wall3 = new Wall(new Vector2(0, 400), new Vector2(20, 800), "wall");
            Wall wall4 = new Wall(new Vector2(800, 400), new Vector2(20, 800), "wall");
            LoseLabel = new Label("You Lose! Please try again.", 32, new Vector2(400, 100), Color.White, "scoreLabel", true);
        }

        public override void OnUpdate()
        {

        }
    }
}
