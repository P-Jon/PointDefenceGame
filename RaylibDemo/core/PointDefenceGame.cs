using PointDefence.core.Data;
using PointDefence.UI;

using PointDefence.player;
using Raylib_cs;
using static Raylib_cs.Color;

namespace PointDefence.core
{
    public class PointDefenceGame
    {
        private PlayerController player;
        private UIHandler _uiHandler = new UIHandler();

        private static void Main(string[] args)
        {
            new PointDefenceGame();
        }

        public PointDefenceGame()
        {
            Raylib.InitWindow(GameData.screenWidth, GameData.screenHeight, "DemoGame");
            Raylib.SetTargetFPS(60);

            player = new PlayerController();

            while (!Raylib.WindowShouldClose())    // Detect window close button or ESC key
            {
                Update();

                Draw();
            }

            Raylib.CloseWindow();        // Close window and OpenGL context
        }

        private void Update()
        {
            handleMouseInput();
            handleKeyboardInput();
            _uiHandler.UpdateUI();
        }

        private void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(RAYWHITE);

            player.DrawPlayer();
            _uiHandler.DrawUI();

            Raylib.DrawText("Welcome", 10, 10, 50, MAROON);

            Raylib.EndDrawing();
        }

        private void handleMouseInput()
        {
            if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
            {
                player.ChangePosition(Raylib.GetMouseX(), Raylib.GetMouseY());
            }
        }

        private void handleKeyboardInput()
        {
        }
    }
}