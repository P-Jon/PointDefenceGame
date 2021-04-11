using PointDefence.Assets;
using PointDefence.Core.Data;
using PointDefence.Core.Models;
using PointDefence.Helper;
using Raylib_cs;
using System.Linq;
using System.Numerics;

namespace PointDefence.Player.Models
{
    public class AlliedMissile : Missile
    {
        public AlliedMissile(Vector2 target)
        {
            position = new Vector2(GameData.screenWidth / 2, GameData.screenHeight - ScreenCalculator.PercentageH(0.1f));
            this.target = target;
            targetXDistance = (position.X - target.X);
            targetYDistance = (position.Y - target.Y);
            GetFrames(GameData.ImageData.AlliedMissileFrames);

            CalculateTrajectory();
            CalculateRotation();

            numberOfFrames = frames.Count() - 1;
            frameTime = 0.2f;
            time = Raylib.GetTime();
        }

        public override void update()
        {
            if (!(position.Y <= target.Y))
            {
                position = new Vector2(position.X - (increments.X * 2), position.Y - (increments.Y * 2));
            }
            else
            {
                GameData.ExplosionManager.AddExplosionToList(new Explosion(position));
                GameData.AlliedMissileManager.QueueRemoveFromObjectList(this);
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