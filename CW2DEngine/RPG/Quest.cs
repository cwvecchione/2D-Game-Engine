using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW2DEngine.RPG
{
    internal class Quest
    {
        public string Name { get; set; }
        public string Objective { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public int RewardGold { get; set; }
    }
}
}
