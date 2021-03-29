using PointDefence.Core.Data;
using PointDefence.UI;

using PointDefence.Player;
using Raylib_cs;
using static Raylib_cs.Color;
using PointDefence.Enemies;
using PointDefence.UI.Components;

namespace PointDefence.Core
{
    public class PointDefenceGame
    {
        private PlayerController player;
        private Missile missile;
        private UIHandler _uiHandler;
        private GameBackground _gameBackground;
        private Crosshair _crosshair;

        private static void Main(string[] args)
        {
            new PointDefenceGame();
        }

        public PointDefenceGame()
        {
            Raylib.InitWindow(GameData.screenWidth, GameData.screenHeight, "Point Defence Game");
            Raylib.SetTargetFPS(60);
            Raylib.HideCursor();

            _uiHandler = new UIHandler();
            _gameBackground = new GameBackground();
            _crosshair = new Crosshair();

            player = new PlayerController();
            missile = new Missile();
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
            _crosshair.update();
        }

        private void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(BLACK);
            _gameBackground.draw();

            player.DrawPlayer();
            _uiHandler.DrawUI();
            missile.draw();
            Raylib.DrawText("MISSION: Defend Space Station", 10, 10, 50, MAROON);
            _crosshair.draw();
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