using PointDefence.Core.Data;
using PointDefence.Core.Models;
using Raylib_cs;
using System.Linq;

namespace PointDefence.Enemies
{
    public class Missile : AnimatedObject
    {
        private double time;

        public Missile()
        {
            GetTexturesFromImages(GameData.localDir + "Images/", "Rocket1.png", "Rocket2.png");
            numberOfFrames = frames.Count() - 1;
            time = Raylib.GetTime();
        }

        public override void update()
        {
            throw new System.NotImplementedException();
        }

        public override void draw()
        {
            if (Raylib.GetTime() >= time + 0.2f)
            {
                ChangeFrame();
                time = Raylib.GetTime();
            }

            Raylib.DrawTexture(frames[currentFrame], 400, 400, Color.WHITE);
        }
    }
}