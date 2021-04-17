using PointDefence.Assets;
using PointDefence.Core.Data;
using PointDefence.Player;
using PointDefence.Player.Models;
using Raylib_cs;
using System;
using System.Numerics;

namespace PointDefence.Core.Models
{
    public abstract class Missile : AnimatedObject
    {
        protected double time;

        protected Vector2 target;

        protected float targetYDistance;
        protected float targetXDistance;
        protected Vector2 increments;
        protected float rotation;

        protected float CalculateAngle()
        {
            return (float)Math.Atan(targetXDistance / targetYDistance);
        }

        protected void CalculateRotation()
        {
            var baseRotation = 90;

            if (this is AlliedMissile)
                baseRotation = -baseRotation;

            rotation = baseRotation + (float)(Math.Atan2(targetYDistance, targetXDistance) * (180 / 3.14f));
        }

        protected void CalculateTrajectory()
        {
            var angle = CalculateAngle();
            increments = new Vector2((float)Math.Sin(angle), (float)Math.Cos(angle));
        }

        public void CheckCollision(Vector2 circleCenter, int radius)
        {
            if (Raylib.CheckCollisionPointCircle(position, circleCenter, radius))
            {
                GameData.ExplosionManager.QueueAddExplosionToList(new Explosion(position));

                if (this is AlliedMissile)
                    GameData.AlliedMissileManager.QueueRemoveFromObjectList(this);
                else
                {
                    CheckBaseHit(radius);

                    GameData.EnemyManager.QueueRemoveFromObjectList(this);
                    PlayerData.score += 10;
                }
            }
        }

        // Hacky hardcode will bite me somewhere I reckon, will change when I figure out how to make it consistent
        public void CheckBaseHit(int radius)
        {
            if (position.Y + 200 >= target.Y)
                PlayerData.health -= 10;
        }
    }
}