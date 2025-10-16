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

        Player player;
    
        public override void OnLoad()
        {
            player = new Player(new Vector2(), new Vector2(), "player");
            Demo_Scene level1 = new Demo_Scene("level1");
            Demo_Scene_2 level2 = new Demo_Scene_2("level2");
            LevelManager.ChangeLevel("level1");
        }
        public override void OnUpdate()
        {
            Log.Info($"Player Position: {player.Position.x}, {player.Position.y}");

            base.OnUpdate();

            if (Input.ActionJustPressed("Up"))
            {
                LevelManager.ChangeLevel("level2");
            }
            if (Input.ActionJustPressed("Down"))
            {
                LevelManager.ChangeLevel("level1");
            }
        }
    }
}