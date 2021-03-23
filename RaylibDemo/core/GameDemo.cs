using System;
using System.Collections.Generic;
using System.Text;
using RaylibDemo.player;
using Raylib_cs;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;

namespace RaylibDemo.core
{
    public class GameDemo
    {
        private static void Main(string[] args)
        {
            new GameDemo();
        }

        public GameDemo()
        {
            Raylib.InitWindow(GameData.screenWidth, GameData.screenHeight, "DemoGame");
            var player = new PlayerController();
            while (!WindowShouldClose())    // Detect window close button or ESC key
            {
                // Update
                //----------------------------------------------------------------------------------
                handleMouseInput();
                handleKeyboardInput();

                // Draw
                //----------------------------------------------------------------------------------
                BeginDrawing();
                ClearBackground(RAYWHITE);

                player.DrawPlayer();
                DrawText("Welcome", 10, 10, 50, MAROON);

                EndDrawing();
                //----------------------------------------------------------------------------------
            }

            // De-Initialization
            //--------------------------------------------------------------------------------------
            CloseWindow();        // Close window and OpenGL context
            //--------------------------------------------------------------------------------------
        }

        private void handleMouseInput()
        {
        }

        private void handleKeyboardInput()
        {
        }
    }
}