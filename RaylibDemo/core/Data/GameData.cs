using PointDefence.Enemies;
using System.IO;

namespace PointDefence.Core.Data
{
    public class GameData
    {
        public const int screenWidth = 1280;
        public const int screenHeight = 720;
        public static bool inGameLoop = false;
        public static string localDir = Directory.GetCurrentDirectory() + "/../../../";

        public static EnemySpawnManager EnemyManager = new EnemySpawnManager(30);
    }
}