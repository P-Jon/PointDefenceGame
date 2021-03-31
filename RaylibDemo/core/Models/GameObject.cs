using PointDefence.Core.Data;
using PointDefence.Helper;
using System;
using System.Numerics;

namespace PointDefence.Core.Models
{
    public abstract class GameObject
    {
        protected Vector2 position;

        protected Vector2 GenerateRandomXY(bool isTop = false)
        {
            Random r = new Random();
            if (isTop)
                return new Vector2(r.Next(GameData.screenWidth), 0);
            else
                return new Vector2(r.Next(GameData.screenWidth), GameData.screenHeight - ScreenCalculator.PercentageH(0.098f));
        }

        public abstract void update();

        public abstract void draw();
    }
}