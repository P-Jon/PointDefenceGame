using Raylib_cs;
using PointDefence.UI.Components;
using System;
using static PointDefence.Helper.TextAlignment;

namespace PointDefence.UI.Models
{
    public class StatusBar : UIComponent
    {
        private Rectangle bar;
        private int statusValue = 50;
        private Color colour;

        private string text = null;
        private int fontSize;
        private int textOffset;

        public StatusBar(Rectangle statusBar, Color barColour)
        {
            bar = statusBar;
            colour = barColour;
        }

        public void SetStatusString(string statusText, int fontSize = 24, int offset = 0)
        {
            text = statusText;
            textOffset = offset;
            this.fontSize = fontSize;
        }

        public void SetStatusValue(int statusValue)
        {
            this.statusValue = statusValue;
        }

        public override void draw()
        {
            Raylib.DrawRectangleRec(bar, Color.BLACK);

            if (statusValue != 100)
                Raylib.DrawRectangleRec(new Rectangle(bar.x, bar.y, (int)(bar.width * (float)(statusValue / 100m)), bar.height), colour);
            else
                Raylib.DrawRectangleRec(bar, colour);

            if (text != null)
                Raylib.DrawText(text, (int)bar.x - textOffset, MiddleYAlignmentRect(bar, fontSize), fontSize, new Color(255, 255, 255, 255));
        }

        public override void update()
        {
            throw new System.NotImplementedException();
        }
    }
}