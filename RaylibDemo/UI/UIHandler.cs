using System;
using System.Collections.Generic;

using Raylib_cs;
using static Raylib_cs.Color;
using RaylibDemo.UI.Components;

namespace RaylibDemo.UI
{
    public class UIHandler
    {
        private List<Button> buttons = new List<Button>
        {
            new Button("New Game", new Rectangle(300,300,100,40), 24, new Color(0,0,0,255), new Color(50,168,82,255))
        };

        public UIHandler()
        {
        }

        public void DrawUI()
        {
            RenderButtons();
        }

        private void RenderTitle()
        {
        }

        private void RenderButtons()
        {
            buttons.ForEach(x => x.draw());
        }
    }
}