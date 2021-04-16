using PointDefence.Core.Data;
using PointDefence.Player;
using PointDefence.UI;
using PointDefence.UI.Components;
using Raylib_cs;
using System;
using static Raylib_cs.Color;

namespace PointDefence.Core
{
    public class PointDefenceGame
    {
        private PlayerController player;
        private UIHandler _uiHandler;

        private GameBackground _gameBackground;
        private Crosshair _crosshair;

        private bool Restart = false;

        public PointDefenceGame()
        {
            _uiHandler = new UIHandler();
            _gameBackground = new GameBackground();
            _crosshair = new Crosshair();

            player = new PlayerController();

            GameLoop();

            GameData.QuitGame = !Restart;
        }

        private void GameLoop()
        {
            while (!Raylib.WindowShouldClose())    // Detect window close button or ESC key
            {
                if (Raylib.IsWindowFocused())
                {
                    CheckGameover();

                    if (!GameData.Gameover)
                    {
                        Update();
                        Draw();
                    }
                    else if (CheckRestart())
                        break;
                    else
                        PollInput();
                }
                else
                    PollInput();
            }
        }

        // This HAS to be used to enable input to be grabbed
        private void PollInput()
        {
            Raylib.BeginDrawing();
            Raylib.EndDrawing();
        }

        private void CheckGameover()
        {
            if (!GameData.Gameover && PlayerData.health <= 0)
            {
                GameData.Gameover = true;
                GameData.AudioManager.PlaySound("Gameover2");

                Update();
                DrawUI(true);
            }
        }

        private bool CheckRestart()
        {
            if (GameData.Gameover && Raylib.IsKeyPressed(KeybindData.RestartKey))
            {
                Restart = true;
                return true;
            }
            DrawUI(true);

            return false;
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

            DrawUI();
            _crosshair.draw();

            Raylib.EndDrawing();
        }

        private void DrawUI(bool drawCall = false)
        {
            if (drawCall)
                Raylib.BeginDrawing();

            _uiHandler.DrawUI();
            Raylib.DrawText("MISSION: Defend Space Station", 10, 10, 50, MAROON);

            if (drawCall)
                Raylib.EndDrawing();
        }
    }
}