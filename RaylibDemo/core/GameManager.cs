using PointDefence.Core.Data;
using Raylib_cs;
using System;

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

            while (GameData.QuitGame == false)
            {
                GameLoop = new PointDefenceGame();
                QuitGame();
                Console.WriteLine("Attemtping Restart... \n QuitGame: " + GameData.QuitGame);
            }
        }

        private void QuitGame()
        {
            GameData.ResetData();

            if (GameData.QuitGame)
            {
                GameData.ImageData.UnloadTextures();
                GameData.AudioManager.CloseAudioDevice();

                Raylib.CloseWindow();        // Close window and OpenGL context
            }
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