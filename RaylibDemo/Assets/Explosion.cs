using PointDefence.Core.Data;
using PointDefence.Core.Models;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace PointDefence.Assets
{
    public class Explosion : AnimatedObject
    {
        private double startTime;
        private double time;

        public Explosion(Vector2 position)
        {
            this.position = position;
            GetTexturesFromImages(GameData.localDir + "Images/", "Rocket1.png", "Explosion2.png", "Explosion3.png",
                "Explosion4.png", "Explosion5.png", "Explosion6.png", "Explosion7.png");

            numberOfFrames = frames.Count() - 1;

            time = Raylib.GetTime();
            startTime = time;
        }

        public override void draw()
        {
            if (Raylib.GetTime() >= time + 0.2f)
            {
                ChangeFrame();
                time = Raylib.GetTime();
            }

            Raylib.DrawTextureEx(frames[currentFrame], position, 0, 1f, Color.WHITE);
        }

        public override void update()
        {
            if (Raylib.GetTime() >= startTime + 1.3f)
            {
                GameData.ExplosionManager.QueueRemoveFromObjectList(this);
            }
        }
    }
}