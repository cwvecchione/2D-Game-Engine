using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nkast.Aether.Physics2D.Dynamics.Contacts;
using nkast.Aether.Physics2D.Dynamics;
using SFML.Graphics;
using CW2DEngine.Source;
using CW2DEngine.Source.Classes;
using CW2DEngine.Source.GameObjects;

namespace CW2DEngine.Source.Scenes
{
    internal class Demo_Scene : Level
    {
        public override string LevelName { get; set; }
        public override bool Init { get; set; }

        Player player;
        int score = 0;
        Label scoreLabel;
        //Point point;
        Point point1, point2, point3, point4;

        public Demo_Scene(string levelName) : base(levelName)
        {

        }


        public override void OnLoad()
        {
            player = new Player(new Vector2(400, 400), new Vector2(50, 50), "player");
            Wall wall1 = new Wall(new Vector2(400, 0), new Vector2(800, 20), "wall");
            Wall wall2 = new Wall(new Vector2(400, 800), new Vector2(800, 20), "wall");
            Wall wall3 = new Wall(new Vector2(0, 400), new Vector2(20, 800), "wall");
            Wall wall4 = new Wall(new Vector2(800, 400), new Vector2(20, 800), "wall");
            scoreLabel = new Label("Score: 0", 32, new Vector2(400, 100), Color.White, "scoreLabel", true);

            point1 = new Point(new Vector2(200, 400), new Vector2(20, 20), "point");
            point1.onCollisionEventHandlers.Add(Collision_OnCollision);
            point2 = new Point(new Vector2(400, 200), new Vector2(20, 20), "point");
            point2.onCollisionEventHandlers.Add(Collision_OnCollision);
            point3 = new Point(new Vector2(400, 600), new Vector2(20, 20), "point");
            point3.onCollisionEventHandlers.Add(Collision_OnCollision);
            point4 = new Point(new Vector2(600, 400), new Vector2(20, 20), "point");
            point4.onCollisionEventHandlers.Add(Collision_OnCollision);
        }

        public override void OnUpdate()
        {
            scoreLabel.Text = $"Score: {score}";
        }

        private bool Collision_OnCollision(Fixture sender, Fixture other, Contact contact)
        {
            score++;
            if (score > 3) { LevelManager.ChangeLevel("Win"); }

            return true;
        }
    }
}
