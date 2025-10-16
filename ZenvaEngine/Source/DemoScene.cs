using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenvaEngine.Source
{
    internal class Demo_Scene : Level
    {
        public override string LevelName { get; set; }
        public override bool Init { get; set; }
        public Demo_Scene(string levelName) : base(levelName)
        {
        }
        public override void OnLoad()
        {
            // Initialize game objects and set up the scene
        }
        public override void OnUpdate()
        {
            // Update game objects and handle game logic
        }
    }
}
