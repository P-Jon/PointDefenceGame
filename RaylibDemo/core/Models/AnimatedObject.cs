using Raylib_cs;
using System.Linq;

namespace PointDefence.Core.Models
{
    public abstract class AnimatedObject : GameObject
    {
        protected Texture2D[] frames;

        protected float frameTime;

        protected int numberOfFrames;
        protected int currentFrame = 0;

        protected void GetFrames(Texture2D[] frames)
        {
            this.frames = frames;
        }

        protected void ChangeFrame()
        {
            currentFrame++;
            if (currentFrame > numberOfFrames)
            {
                currentFrame = 0;
            }
        }
    }
}