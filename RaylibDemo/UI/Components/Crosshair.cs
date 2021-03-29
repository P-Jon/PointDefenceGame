using PointDefence.Core.Data;
using PointDefence.Core.Models;
using Raylib_cs;
using System;
using System.Numerics;

namespace PointDefence.UI.Components
{
    public class Crosshair : AnimatedObject
    {
        private Vector2 Position;

        public Crosshair()
        {
            GetTexturesFromImages(GameData.localDir + "Images/", "Crosshair.png");
        }

        public override void update()
        {
            Position = Raylib.GetMousePosition();
            Position = new Vector2(Position.X - 33f, Position.Y - 33f);
        }

        public override void draw()
        {
            Raylib.DrawTextureEx(frames[0], Position, 0, 0.25f, Color.WHITE);
        }
    }
}