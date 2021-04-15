using PointDefence.Core.Data;
using Raylib_cs;

namespace PointDefence.Core
{
    public class GameManager
    {
        private PointDefenceGame GameLoop;

        private static void Main(string[] args)
        {
            new GameManager();
        }

        public GameManager()
        {
            SetupGameWindow();

            GameLoop = new PointDefenceGame();

            if ()
        }

        private void SetupGameWindow()
        {
            Raylib.InitWindow(GameData.ScreenWidth, GameData.ScreenHeight, "Point Defence Game");
            Raylib.SetTargetFPS(60);
            Raylib.HideCursor();
            GameData.ImageData.SetWindowIcon();
        }
    }
}