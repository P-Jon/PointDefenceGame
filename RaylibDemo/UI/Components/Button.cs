using Raylib_cs;
using static PointDefence.Helper.TextAlignment;
using System.Linq;
using PointDefence.core.Models;

namespace PointDefence.UI.Components
{
    public class Button : GameObject
    {
        private Rectangle buttonBody;
        private Color buttonColor;
        private int halfFontSize;
        private string buttonText;
        private int fontSize;
        private Color textColor;

        private int textWidth;

        /// <summary>
        /// Creates a button at with text at X,Y co-ordinates, with a given font size and colour.
        /// </summary>
        /// <param name="text">Button Text</param>
        /// <param name="rect">Button Rectangle Parameters</param>
        /// <param name="fontSize">Font Size</param>
        /// <param name="textColor">Colour of Text</param>
        /// <param name="buttonColor">Colour of Button</param>
        public Button(string text, Rectangle rect, int fontSize, Color textColor, Color buttonColor)
        {
            // int textWidth = Raylib.MeasureText(text, fontSize); Returns 0, seems to be Raylibs fault

            // Trying to compensate for the broken function
            halfFontSize = fontSize / 2;
            var spacings = text.Count(char.IsWhiteSpace) * halfFontSize;

            textWidth = ((text.Length * halfFontSize) + halfFontSize) + spacings;
            // -- end compensate --

            buttonText = text;
            this.buttonColor = buttonColor;
            this.textColor = textColor;
            this.fontSize = fontSize;

            rect.width = textWidth + halfFontSize;

            buttonBody = rect;
        }

        public override void draw()
        {
            var textY = MiddleYAlignmentRect(buttonBody, fontSize); // Drawing to the middle of the button height
            var textX = (int)buttonBody.x + ((int)buttonBody.width / 2) - (textWidth / 2);

            Raylib.DrawRectangleRec(buttonBody, buttonColor);

            Raylib.DrawText(buttonText, textX, textY, fontSize, textColor);
        }

        public override void update()
        {
            throw new System.NotImplementedException();
        }
    }
}