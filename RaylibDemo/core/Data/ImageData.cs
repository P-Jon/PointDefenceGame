using Raylib_cs;
using System.Linq;

namespace PointDefence.Core.Data
{
    public class ImageData
    {
        // Make this a dictionary?

        public Texture2D[] EnemyMissileFrames;
        public Texture2D[] AlliedMissileFrames;

        public Texture2D[] ExplosionFrames;
        public Texture2D[] CannonFrames;

        public Texture2D[] StarrySky;
        public Texture2D[] Crosshair;

        private string ImageDir = GameData.localDir + "Images/";
        // This will have to do until I can resolve a better solution - decent as a POC though.

        public ImageData()
        {
            EnemyMissileFrames = GetTexturesFromImages(ImageDir, "Rocket1.png", "Rocket2.png");

            AlliedMissileFrames = GetTexturesFromImages(ImageDir, "AlliedRocket1.png", "AlliedRocket2.png");

            ExplosionFrames = GetTexturesFromImages(ImageDir, "Explosion1.png", "Explosion2.png", "Explosion3.png",
                "Explosion4.png", "Explosion5.png", "Explosion6.png", "Explosion7.png");

            CannonFrames = GetTexturesFromImages(ImageDir, "Cannon_Unfired.png", "Cannon_Fired.png");

            StarrySky = GetTexturesFromImages(ImageDir, "StarrySky.png");

            Crosshair = GetTexturesFromImages(ImageDir, "Crosshair.png");
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

        public void SetWindowIcon()
        {
            var img = GetImage(ImageDir + "PointDefenceIcon.png");
            Raylib.SetWindowIcon(img);
            Raylib.UnloadImage(img);
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
            UnloadTextures(EnemyMissileFrames);
            UnloadTextures(AlliedMissileFrames);
            UnloadTextures(ExplosionFrames);
            UnloadTextures(CannonFrames);
            UnloadTextures(StarrySky);
            UnloadTextures(Crosshair);
        }

        private void UnloadTextures(Texture2D[] frames)
        {
            frames.ToList().ForEach(x => Raylib.UnloadTexture(x));
        }
    }
}