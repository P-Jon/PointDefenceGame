using PointDefence.Core.Data;
using PointDefence.UI.Components;
using Raylib_cs;
using System.Collections.Generic;

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

            if (GameData.Gameover)
                DisplayGameover();

            headsUpDisplay.draw();
        }

        private void DisplayGameover()
        {
            var halfTextMeasure = (Raylib.MeasureText("Game Over", 64) / 2);
            Raylib.DrawText("Game Over", (GameData.screenWidth / 2) - halfTextMeasure, (GameData.screenHeight / 2) - halfTextMeasure, 64, Color.WHITE);
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