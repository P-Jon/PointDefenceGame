using System;
using System.Numerics;

namespace PointDefence.Core.Models
{
    public abstract class Missile : AnimatedObject
    {
        protected double time;

        protected Vector2 target;
        protected float targetXDistance;
        protected Vector2 increments;
        protected float rotation;

        protected float CalculateAngle()
        {
            return (float)Math.Atan(targetXDistance / target.Y);
        }

        protected abstract void CalculateRotation();

        protected void CalculateTrajectory()
        {
            var angle = CalculateAngle();
            increments = new Vector2((float)Math.Sin(angle), (float)Math.Cos(angle));
        }
    }
}