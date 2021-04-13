using PointDefence.Assets;
using PointDefence.Core.Data;
using PointDefence.Core.Models;
using System.Numerics;
using static PointDefence.Helper.ScreenCalculator;
using Raylib_cs;
using System;

namespace PointDefence.Player
{
    public class PlayerController : AnimatedObject
    {
        private double time;
        private bool reloading = false;

        public PlayerController()
        {
            position = new Vector2((GameData.screenWidth / 2), GameData.screenHeight - PercentageH(0.1f));

            GetFrames(GameData.ImageData.CannonFrames);

            time = Raylib.GetTime();
        }

        public override void update()
        {
            handleMouseInput();
            handleKeyboardInput();

            if (reloading)
                Reload();
        }

        public override void draw()
        {
            Raylib.DrawTextureEx(frames[currentFrame], new Vector2(position.X, position.Y), 0, 1f, Color.WHITE);
        }

        private void handleMouseInput()
        {
            if (!reloading && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
            {
                PlayerData.ammo -= 5;
                GameData.AlliedMissileManager.InstantiateMissile(Raylib.GetMousePosition());
                GameData.AudioManager.PlaySound("Shooting2");
            }
        }

        private void handleKeyboardInput()
        {
            if (reloading != true && Raylib.IsKeyPressed(KeybindData.ReloadKey))
            {
                time = Raylib.GetTime();
                reloading = true;
            }
        }

        public void Reload()
        {
            if (PlayerData.ammo != 100 && Raylib.GetTime() >= time + 0.05f)
            {
                time = Raylib.GetTime();

                PlayerData.ammo = PlayerData.ammo + 1;
            }
            else if (PlayerData.ammo >= 100)
            {
                GameData.AudioManager.PlaySound("Reloaded");
                reloading = false;
            }
        }
    }
}