using PointDefence.core.Models;
using Raylib_cs;

namespace PointDefence.UI.Models
{
    public class HUDElement : GameObject
    {
        public Rectangle bar;
        public Color barColour;

        public HUDElement(Rectangle bar, Color barColour)
        {
            this.bar = bar;
            this.barColour = barColour;
        }

        public override void draw()
        {
            Raylib.DrawRectangleRec(bar, barColour);
        }

        public override void update()
        {
            throw new System.NotImplementedException();
        }
    }
}