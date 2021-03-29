using System.IO;

namespace PointDefence.core.Data
{
    public class GameData
    {
        public const int screenWidth = 1280;
        public const int screenHeight = 720;
        public static bool inGameLoop = false;
        public static string localDir = Directory.GetCurrentDirectory() + "/../../../";
    }
}