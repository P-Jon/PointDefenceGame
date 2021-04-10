using PointDefence.Assets;
using PointDefence.Core.Data;
using PointDefence.Core.Models;
using System.Numerics;
using static PointDefence.Helper.ScreenCalculator;
using Raylib_cs;

namespace PointDefence.Player
{
    public class PlayerController : AnimatedObject
    {
        public PlayerController()
        {
            position = new Vector2((GameData.screenWidth / 2), GameData.screenHeight - PercentageH(0.1f));

            GetFrames(GameData.ImageData.CannonFrames);
        }

        public override void update()
        {
            handleMouseInput();
        }

        public override void draw()
        {
            Raylib.DrawTextureEx(frames[currentFrame], new Vector2(position.X, position.Y), 0, 1f, Color.WHITE);
        }

        private void handleMouseInput()
        {
            if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
            {
                //player.ChangePosition(Raylib.GetMouseX(), Raylib.GetMouseY());
                //GameData.ExplosionManager.AddExplosionToList(new Explosion(Raylib.GetMousePosition()));
                GameData.AlliedMissileManager.InstantiateMissile(Raylib.GetMousePosition());
                GameData.AudioManager.PlaySound("Shooting2");
            }
        }

        private void handleKeyboardInput()
        {
        }
    }
}