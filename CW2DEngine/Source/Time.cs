using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW2DEngine.Source
{
    internal class Time
    {
        public static Clock clock = new Clock();
        public static float deltaTime;

        public static void UpdateTime()
        {
            deltaTime = clock.Restart().AsSeconds();
        }
    }
}
