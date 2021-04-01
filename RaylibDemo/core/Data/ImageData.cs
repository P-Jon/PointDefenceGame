using Raylib_cs;
using System.Linq;

namespace PointDefence.Core.Data
{
    public class ImageData
    {
        // Make this a dictionary?

        public Texture2D[] MissileFrames;
        public Texture2D[] ExplosionFrames;
        public Texture2D[] StarrySky;
        public Texture2D[] Crosshair;

        // This will have to do until I can resolve a better solution - decent as a POC though.

        public ImageData()
        {
            MissileFrames = GetTexturesFromImages(GameData.localDir + "Images/", "Rocket1.png", "Rocket2.png");

            ExplosionFrames = GetTexturesFromImages(GameData.localDir + "Images/", "Explosion1.png", "Explosion2.png", "Explosion3.png",
                "Explosion4.png", "Explosion5.png", "Explosion6.png", "Explosion7.png");

            StarrySky = GetTexturesFromImages(GameData.localDir + "Images/", "StarrySky.png");

            Crosshair = GetTexturesFromImages(GameData.localDir + "Images/", "Crosshair.png");
        }

        // Taking from CPU/RAM and putting to GPU/VRAM
        protected Texture2D[] GetTexturesFromImages(string route, params string[] filenames)
        {
            var frames = new Texture2D[filenames.Count()];
            int i = 0;
            foreach (string file in filenames)
            {
                var image = GetImage(route + file);
                frames[i] = Raylib.LoadTextureFromImage(image);
                Raylib.UnloadImage(image);
                i++;
            }

            return frames;
        }

        // Just incase...
        private Image GetImage(string path, bool flipVertical = false, bool flipHorizontal = false)
        {
            var image = Raylib.LoadImage(path);

            if (flipVertical)
                Raylib.ImageFlipVertical(ref image);

            if (flipHorizontal)
                Raylib.ImageFlipHorizontal(ref image);

            return image;
        }

        public void UnloadTextures()
        {
            UnloadTextures(MissileFrames);
            UnloadTextures(ExplosionFrames);
            UnloadTextures(StarrySky);
            UnloadTextures(Crosshair);
        }

        private void UnloadTextures(Texture2D[] frames)
        {
            frames.ToList().ForEach(x => Raylib.UnloadTexture(x));
        }
    }
}