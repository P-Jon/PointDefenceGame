using Raylib_cs;
using RaylibDemo.UI.Components;

namespace RaylibDemo.UI.Models
{
    public class StatusBar : UIComponent
    {
        private Rectangle bar;
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

        public override void draw()
        {
            Raylib.DrawRectangleRec(bar, Color.BLACK);
            Raylib.DrawRectangleRec(bar, colour);

            if (text != null)
                Raylib.DrawText(text, (int)bar.x - textOffset, (int)bar.y, 24, new Color(255, 255, 255, 255));
        }
    }
}