using PointDefence.Core.Data;
using PointDefence.Core.Models;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace PointDefence.Enemies
{
    public class Missile : AnimatedObject
    {
        private double time;

        private Vector2 target;
        private Vector2 increments;

        public Missile()
        {
            position = GenerateRandomXY(true);
            target = GenerateRandomXY();

            CalculateTrajectory();

            Console.WriteLine("PosX: " + position.X + " PosY: " + position.Y);
            Console.WriteLine("TarX: " + target.X + " TarY: " + target.Y);

            GetTexturesFromImages(GameData.localDir + "Images/", "Rocket1.png", "Rocket2.png");
            numberOfFrames = frames.Count() - 1;

            time = Raylib.GetTime();
        }

        private void RemoveObject()
        {
            // Feels hacky, but there should only /ever/ be one of these
            GameData.EnemyManager.RemoveFromMissileList(this);
        }

        private float CalculateAngle()
        {
            return (float)Math.Tan((position.X + target.X) / target.Y);
        }

        private float CalculateRotation()
        {
            return 180 + (CalculateAngle() * 10);
        }

        private void CalculateTrajectory()
        {
            var angle = CalculateAngle();

            if (position.X > target.X)
                target.X = -target.X;

            Console.WriteLine("Angle: " + angle);
            increments = new Vector2((float)Math.Sin(angle), (float)Math.Cos(angle));
            Console.WriteLine("PosX: " + position.X + " PosY: " + position.Y);
        }

        public override void update()
        {
            position = new Vector2(position.X + increments.X, position.Y + increments.Y);
        }

        public override void draw()
        {
            if (Raylib.GetTime() >= time + 0.2f)
            {
                ChangeFrame();
                time = Raylib.GetTime();
            }

            Raylib.DrawTextureEx(frames[currentFrame], position, CalculateRotation(), 1f, Color.WHITE);
        }
    }
}