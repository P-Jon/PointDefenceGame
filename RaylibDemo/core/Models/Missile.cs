using PointDefence.Player.Models;
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
    }
}