using PointDefence.Core.Data;
using PointDefence.Core.Models;
using Raylib_cs;
using System;
using System.Linq;
using System.Numerics;

namespace PointDefence.Assets
{
    public class Explosion : AnimatedObject
    {
        private double startTime;
        private double time;

        private int radius = 32;

        public Explosion(Vector2 position)
        {
            this.position = position;

            GetFrames(GameData.ImageData.ExplosionFrames);

            numberOfFrames = frames.Count() - 1;
            frameTime = 0.1f;
            time = Raylib.GetTime();
            startTime = time;
            GameData.AudioManager.PlaySound("Explosion");
        }

        public override void draw()
        {
            if (Raylib.GetTime() >= time + frameTime)
            {
                ChangeFrame();
                time = Raylib.GetTime();
            }

            Raylib.DrawCircle((int)position.X, (int)position.Y, radius, new Color(255, 0, 0, 128));
            //Raylib.DrawTextureEx(frames[currentFrame], new Vector2(position.X - 128, position.Y - 128), 0, 1f, Color.WHITE);
        }

        public override void update()
        {
            if (!(radius >= 200))
                radius += 2;
            GameData.EnemyManager.CheckCollision(position, radius);
            if (Raylib.GetTime() >= startTime + (frameTime * 7))
            {
                //Console.WriteLine(radius);
                GameData.ExplosionManager.QueueRemoveFromObjectList(this);
            }
        }
    }
}