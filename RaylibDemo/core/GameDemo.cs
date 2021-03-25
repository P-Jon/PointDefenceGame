using RaylibDemo.core.Data;
using RaylibDemo.UI;

using RaylibDemo.player;
using Raylib_cs;
using static Raylib_cs.Color;

namespace RaylibDemo.core
{
    public class GameDemo
    {
        private PlayerController player;
        private UIHandler _uiHandler = new UIHandler();

        private static void Main(string[] args)
        {
            new GameDemo();
        }

        public GameDemo()
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