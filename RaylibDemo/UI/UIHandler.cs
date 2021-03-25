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
            new Button("New Game", new Rectangle(300,300,100,60), 40, new Color(0,0,0,255), new Color(50,168,82,255)),
            new Button("Settings", new Rectangle(300,400,100,60), 40, new Color(0,0,0,255), new Color(50,168,82,255)),
            new Button("Exit", new Rectangle(300,500,100,60), 40, new Color(0,0,0,255), new Color(50,168,82,255)),
            new Button("Credits", new Rectangle(300,600,100,60), 40, new Color(0,0,0,255), new Color(50,168,82,255)),
        };

        private HUD headsUpDisplay;

        public UIHandler()
        {
            headsUpDisplay = new HUD();
        }

        public void DrawUI()
        {
            RenderButtons();
            headsUpDisplay.draw();
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