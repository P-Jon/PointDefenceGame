﻿using PointDefence.Assets;
using PointDefence.Core.Data;
using PointDefence.Player;
using PointDefence.UI;
using PointDefence.UI.Components;
using Raylib_cs;
using static Raylib_cs.Color;

namespace PointDefence.Core
{
    public class PointDefenceGame
    {
        private PlayerController player;
        private UIHandler _uiHandler;

        private GameBackground _gameBackground;
        private Crosshair _crosshair;

        private static void Main(string[] args)
        {
            new PointDefenceGame();
        }

        public PointDefenceGame()
        {
            SetupGame();

            _uiHandler = new UIHandler();
            _gameBackground = new GameBackground();
            _crosshair = new Crosshair();

            player = new PlayerController();

            while (!Raylib.WindowShouldClose())    // Detect window close button or ESC key
            {
                Update();

                Draw();
            }

            QuitGame();
        }

        private void SetupGame()
        {
            Raylib.InitWindow(GameData.screenWidth, GameData.screenHeight, "Point Defence Game");
            Raylib.SetTargetFPS(60);
            Raylib.HideCursor();
            GameData.ImageData.SetWindowIcon();
        }

        private void QuitGame()
        {
            GameData.ImageData.UnloadTextures();
            GameData.AudioManager.CloseAudioDevice();

            Raylib.CloseWindow();        // Close window and OpenGL context
        }

        private void Update()
        {
            _uiHandler.UpdateUI();

            player.update();
            _crosshair.update();

            GameData.AlliedMissileManager.update();
            GameData.EnemyManager.update();
            GameData.ExplosionManager.update();
        }

        private void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(BLACK);
            _gameBackground.draw();

            GameData.EnemyManager.draw();
            GameData.AlliedMissileManager.draw();

            GameData.ExplosionManager.draw();

            player.draw();

            _uiHandler.DrawUI();
            Raylib.DrawText("MISSION: Defend Space Station", 10, 10, 50, MAROON);
            _crosshair.draw();
            Raylib.EndDrawing();
        }
    }
}