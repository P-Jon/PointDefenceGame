using PointDefence.Assets;
using PointDefence.Core.Data;
using PointDefence.Core.Models;
using PointDefence.Player;
using Raylib_cs;
using System;
using System.Linq;
using System.Numerics;

namespace PointDefence.Enemies.Models
{
    public class EnemyMissile : Missile
    {
        public EnemyMissile()
        {
            position = GenerateRandomXY(true);
            this.target = GenerateRandomXY();
            targetXDistance = -(position.X - target.X);
            targetYDistance = target.Y;

            GetFrames(GameData.ImageData.EnemyMissileFrames);

            CalculateTrajectory();
            CalculateRotation();

            numberOfFrames = frames.Count() - 1;
            frameTime = 0.2f;
            time = Raylib.GetTime();
        }

        public override void update()
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
            if (Raylib.GetTime() >= time + frameTime)
            {
                ChangeFrame();
                time = Raylib.GetTime();
            }

            Raylib.DrawTextureEx(frames[currentFrame], position, rotation, 1f, Color.WHITE);
        }
    }
}