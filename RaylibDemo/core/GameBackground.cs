using PointDefence.Core.Data;
using PointDefence.Core.Models;
using Raylib_cs;
using System;
using System.Numerics;

namespace PointDefence.Core
{
    public class GameBackground : AnimatedObject
    {
        public GameBackground()
        {
            GetFrames(GameData.ImageData.StarrySky);
        }

        public override void draw()
        {
            Raylib.DrawTextureEx(frames[0], new Vector2(0, 0), 0, 1, Color.WHITE);
        }

        public override void update()
        {
            throw new NotImplementedException();
        }
    }
}