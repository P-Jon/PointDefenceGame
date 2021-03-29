using Raylib_cs;
using System.Linq;

namespace PointDefence.Core.Models
{
    public abstract class AnimatedObject : GameObject
    {
        protected Texture2D[] frames;

        protected int numberOfFrames;
        protected int currentFrame = 0;

        // Taking from CPU/RAM and putting to GPU/VRAM
        protected void GetTexturesFromImages(string route, params string[] filenames)
        {
            frames = new Texture2D[filenames.Count()];
            int i = 0;
            foreach (string file in filenames)
            {
                var image = Raylib.LoadImage(route + file);
                frames[i] = Raylib.LoadTextureFromImage(image);
                Raylib.UnloadImage(image);
                i++;
            }
        }

        public void UnloadTextures()
        {
            frames.ToList().ForEach(x => Raylib.UnloadTexture(x));
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