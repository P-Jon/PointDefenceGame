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
        private float targetXDistance;
        // private Vector2 increments;

        public Missile()
        {
            position = GenerateRandomXY(true);
            target = GenerateRandomXY();
            targetXDistance = -(position.X - target.X);
            CalculateTrajectory();
            Console.WriteLine("---- STARTING VALUES ----");
            Console.WriteLine("Distance: " + targetXDistance);
            Console.WriteLine("PosX: " + position.X + " PosY: " + position.Y);
            Console.WriteLine("TarX: " + target.X + " TarY: " + target.Y);
            Console.WriteLine("---- //STARTING VALUES// ----");

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
            return (float)Math.Atan(targetXDistance / target.Y);
        }

        private float CalculateRotation()
        {
            return 180 + ((float)Math.Atan(targetXDistance / target.Y));
        }

        private Vector2 CalculateTrajectory()
        {
            var angle = CalculateAngle();
            return new Vector2((float)Math.Sin(angle), (float)Math.Cos(angle));
        }

        public override void update()
        {
            if (!(position.Y >= target.Y))
            {
                var increments = CalculateTrajectory();
                position = new Vector2(position.X + increments.X, position.Y + increments.Y);
            }
            else // For Debugging
                Console.WriteLine("PosX: " + position.X + " PosY: " + position.Y + "\nTarX:" + target.X + " TarY: " + target.Y);
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