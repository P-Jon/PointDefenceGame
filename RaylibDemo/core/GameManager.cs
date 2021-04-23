using PointDefence.Core.Data;
using PointDefence.Player;
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
            }
        }

        private void QuitGame()
        {
            GameData.ResetData();
            PlayerData.ResetStats();

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