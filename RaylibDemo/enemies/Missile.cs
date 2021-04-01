using PointDefence.Assets;
using PointDefence.Core.Data;
using PointDefence.Core.Models;
using Raylib_cs;
using System;
using System.Linq;
using System.Numerics;

namespace PointDefence.Enemies
{
    public class Missile : AnimatedObject
    {
        private double time;

        private Vector2 target;
        private float targetXDistance;
        private Vector2 increments;
        private float rotation;

        public Missile()
        {
            position = GenerateRandomXY(true);
            target = GenerateRandomXY();
            targetXDistance = -(position.X - target.X);
            CalculateTrajectory();
            CalculateRotation();

            GetFrames(GameData.ImageData.MissileFrames);

            numberOfFrames = frames.Count() - 1;
            frameTime = 0.2f;

            time = Raylib.GetTime();
        }

        private float CalculateAngle()
        {
            return (float)Math.Atan(targetXDistance / target.Y);
        }

        private void CalculateRotation()
        {
            rotation = 90 + (float)(Math.Atan2(target.Y, targetXDistance) * (180 / 3.14f));
        }

        private void CalculateTrajectory()
        {
            var angle = CalculateAngle();
            increments = new Vector2((float)Math.Sin(angle), (float)Math.Cos(angle));
        }

        public override void update()
        {
            if (!(position.Y >= target.Y))
            {
                position = new Vector2(position.X + increments.X, position.Y + increments.Y);
            }
            else
            {
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