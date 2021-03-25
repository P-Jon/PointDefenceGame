using Raylib_cs;
using RaylibDemo.UI.Components;

namespace RaylibDemo.UI.Models
{
    public class HUDElement : UIComponent
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
    }
}