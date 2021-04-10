using PointDefence.Assets;
using PointDefence.Core.Data;
using PointDefence.Core.Models;
using PointDefence.Player;
using Raylib_cs;
using System;
using System.Linq;
using System.Numerics;
using static PointDefence.Helper.ScreenCalculator;

namespace PointDefence.Enemies
{
    public class Missile : AnimatedObject
    {
        private double time;

        private Vector2 target;
        private float targetXDistance;
        private Vector2 increments;
        private float rotation;

        private bool isAllied;

        public Missile(Vector2 target, bool isAllied = false)
        {
            this.isAllied = isAllied;

            if (isAllied)
            {
                position = new Vector2(GameData.screenWidth / 2, GameData.screenHeight - PercentageH(0.1f));
                this.target = target;
                targetXDistance = (position.X - target.X);

                GetFrames(GameData.ImageData.AlliedMissileFrames);
            }
            else
            {
                position = GenerateRandomXY(true);
                this.target = GenerateRandomXY();
                targetXDistance = -(position.X - target.X);

                GetFrames(GameData.ImageData.EnemyMissileFrames);
            }

            CalculateTrajectory();
            CalculateRotation();

            numberOfFrames = frames.Count() - 1;
            frameTime = 0.2f;
            Console.WriteLine(position + " + " + this.target);
            time = Raylib.GetTime();
        }

        private float CalculateAngle()
        {
            return (float)Math.Atan(targetXDistance / target.Y);
        }

        private void CalculateRotation()
        {
            if (isAllied)
                rotation = (float)(Math.Atan2(target.Y, targetXDistance) * (180 / 3.14f));
            else
                rotation = 90 + (float)(Math.Atan2(target.Y, targetXDistance) * (180 / 3.14f));
        }

        private void CalculateTrajectory()
        {
            var angle = CalculateAngle();
            increments = new Vector2((float)Math.Sin(angle), (float)Math.Cos(angle));
        }

        public override void update()
        {
            if (isAllied)
                AlliedMissileHandler();
            else
                EnemyMissileHandler();
        }

        private void AlliedMissileHandler()
        {
            if (!(position.Y <= target.Y))
            {
                position = new Vector2(position.X - increments.X, position.Y - increments.Y);
            }
            else
            {
                GameData.ExplosionManager.AddExplosionToList(new Explosion(position));
                GameData.AlliedMissileManager.QueueRemoveFromObjectList(this);
            }
        }

        // This is hideous but it will do
        private void EnemyMissileHandler()
        {
            if (!(position.Y >= target.Y))
                position = new Vector2(position.X + increments.X, position.Y + increments.Y);
            else
            {
                PlayerData.health -= 2;
                // Feels hacky, but there should only /ever/ be one of these
                GameData.ExplosionManager.AddExplosionToList(new Explosion(position));
                GameData.EnemyManager.QueueRemoveFromObjectList(this);
            }
        }

        public override void draw()
        {
            DrawMissile();
        }

        private void DrawMissile()
        {
            if (Raylib.GetTime() >= time + frameTime)
            {
                ChangeFrame();
                time = Raylib.GetTime();
            }

            Raylib.DrawTextureEx(frames[currentFrame], position, rotation, 1f, Color.WHITE);
        }
    }
}