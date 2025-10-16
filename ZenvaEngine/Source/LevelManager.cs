using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenvaEngine.Source
{
    internal class LevelManager
    {
        public static List<Level> AllLevels = new List<Level>();
        public static Level currentLevel = null;
        public static void ChangeLevel(string levelName)
        {
            foreach (Level level in AllLevels)
            {
                if (level.LevelName == levelName)
                {
                    if (currentLevel != null) { currentLevel.OnDestroy(); }
                    currentLevel = level;
                    return;
                }
            }
            Log.Error($"Level {levelName} Does not exist!");
        }

        public static void ChangeLevel(string levelName)
        {
            foreach (Level level in AllLevels)
            {
                if (level.LevelName == levelName)
                {
                    if (currentLevel != null) { currentLevel.OnDestroy(); }
                    currentLevel = level;
                    InitLevel();
                    return;
                }
            }
            Log.Error($"Level {levelName} Does not exist!");
        }

        public static void InitLevel()
        {
            Log.Info("Loading level: " + currentLevel.LevelName);
            if (currentLevel.Init)
            {
                currentLevel.Destroy();
            }
            currentLevel.OnLoad();
        }

        public static void UpdateLevel()
        {
            if (currentLevel == null) { return; }
            currentLevel.OnUpdate();
        }
    }
}
