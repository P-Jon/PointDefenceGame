using System;
using System.Collections.Generic;

using Raylib_cs;
using static Raylib_cs.Color;
using PointDefence.UI.Components;
using PointDefence.core.Data;

namespace PointDefence.UI
{
    public class UIHandler
    {
        private List<Button> buttons = new List<Button>
        {
            new Button("New Game", new Rectangle(300,200,100,60), 40, new Color(0,0,0,255), new Color(50,168,82,255)),
            new Button("Settings", new Rectangle(300,300,100,60), 40, new Color(0,0,0,255), new Color(50,168,82,255)),
            new Button("Exit", new Rectangle(300,400,100,60), 40, new Color(0,0,0,255), new Color(50,168,82,255)),
        };

        private HUD headsUpDisplay;

        public UIHandler()
        {
            headsUpDisplay = new HUD();
        }

        public void UpdateUI()
        {
            headsUpDisplay.update();
        }

        public void DrawUI()
        {
            if (GameData.inGameLoop)
                RenderTitleScreen();

            headsUpDisplay.draw();
        }

        private void RenderTitleScreen()
        {
            RenderButtons();
        }

        private void RenderButtons()
        {
            buttons.ForEach(x => x.draw());
        }
    }
}