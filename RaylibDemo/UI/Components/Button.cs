using System;
using Raylib_cs;
using static Raylib_cs.Color;

namespace RaylibDemo.UI.Components
{
    public class Button : UIComponent
    {
        private Rectangle buttonBody;
        private Color buttonColor;

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
        /// <param name="color">Colour of Button</param>
        public Button(string text, Rectangle rect, int fontSize, Color textColor, Color buttonColor)
        {
            textWidth = Raylib.MeasureText(text, fontSize);
            buttonText = text;

            this.buttonColor = buttonColor;
            this.textColor = textColor;
            this.fontSize = fontSize;

            if (fontSize > rect.width)
                rect.width = fontSize + (fontSize / 2);

            buttonBody = rect;
        }

        public override void draw()
        {
            var textY = (int)buttonBody.y + (((int)buttonBody.height / 2) - (fontSize / 2)); // Drawing to the middle of the button height
            var textX = buttonBody.x + (fontSize * 2);
            Raylib.DrawRectangleRec(buttonBody, buttonColor);

            Raylib.DrawText(buttonText, (int)buttonBody.x + 5, textY, fontSize, textColor);
        }
    }
}