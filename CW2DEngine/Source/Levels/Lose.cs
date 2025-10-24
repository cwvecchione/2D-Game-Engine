using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nkast.Aether.Physics2D.Dynamics.Contacts;
using nkast.Aether.Physics2D.Dynamics;
using SFML.Graphics;
using CW2DEngine.Source.Classes;
using CW2DEngine.Source.Classes.GameObjectClasses;
using CW2DEngine.Source.GameObjects;

namespace CW2DEngine.Source.Levels
{
    internal class Lose : Level
    {
        public override string LevelName { get; set; }
        public override bool Init { get; set; }

        RedEnemy red1;
        Label LoseLabel;

        public Lose(string levelName) : base(levelName)
        {

        }


        public override void OnLoad()
        {
            red1 = new RedEnemy(new Vector2(400, 400), new Vector2(50, 50), "player");
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
