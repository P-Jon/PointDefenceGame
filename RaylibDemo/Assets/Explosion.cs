using PointDefence.Core.Data;
using PointDefence.Core.Models;
using Raylib_cs;
using System.Linq;
using System.Numerics;

namespace PointDefence.Assets
{
    public class Explosion : AnimatedObject
    {
        private double startTime;
        private double time;

        public Explosion(Vector2 position)
        {
            this.position = position;
            GetTexturesFromImages(GameData.localDir + "Images/", "Explosion1.png", "Explosion2.png", "Explosion3.png",
                "Explosion4.png", "Explosion5.png", "Explosion6.png", "Explosion7.png");

            numberOfFrames = frames.Count() - 1;
            frameTime = 0.1f;
            time = Raylib.GetTime();
            startTime = time;
        }

        public override void draw()
        {
            if (Raylib.GetTime() >= time + frameTime)
            {
                ChangeFrame();
                time = Raylib.GetTime();
            }
            Raylib.DrawTextureEx(frames[currentFrame], new Vector2(position.X - 128, position.Y - 128), 0, 1f, Color.WHITE);
        }

        public override void update()
        {
            if (Raylib.GetTime() >= startTime + (frameTime * 7))
            {
                GameData.ExplosionManager.QueueRemoveFromObjectList(this);
            }
        }
    }
}