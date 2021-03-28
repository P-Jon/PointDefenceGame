using PointDefence.core.Models;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PointDefence.enemies
{
    public class Missile : GameObject
    {
        private Texture2D[] frames;

        private int numberOfFrames;
        private int currentFrame = 0;

        private double time;

        public Missile()
        {
            GetTexturesFromImages(Directory.GetCurrentDirectory() + "/../../../Images/", "Rocket1.png", "Rocket2.png");
            numberOfFrames = frames.Count() - 1;
            time = Raylib.GetTime();
        }

        // Taking from CPU/RAM and putting to GPU/VRAM
        private void GetTexturesFromImages(string route, params string[] filenames)
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

        private void ChangeFrame()
        {
            currentFrame++;
            if (currentFrame > numberOfFrames)
            {
                currentFrame = 0;
            }
        }
    }
}