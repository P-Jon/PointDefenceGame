using Raylib_cs;
using PointDefence.Core.Data;
using PointDefence.Player;
using PointDefence.UI.Models;
using static PointDefence.Helper.ScreenCalculator;
using PointDefence.Core.Models;

namespace PointDefence.UI.Components
{
    public class HUD : GameObject
    {
        private HUDElement bottomBar;

        private StatusBar healthBar;

        private StatusBar staminaBar;

        public HUD()
        {
            bottomBar = new HUDElement(new Rectangle(0, GameData.screenHeight - PercentageH(0.1f), GameData.screenWidth, PercentageH(0.1f)), new Color(0, 58, 88, 255));

            healthBar = new StatusBar(new Rectangle(PercentageW(0.1f), GameData.screenHeight - PercentageH(0.065f), 100, PercentageH(0.025f)), new Color(175, 10, 10, 255));
            healthBar.SetStatusString("HP:", 30, PercentageW(0.05f));

            staminaBar = new StatusBar(new Rectangle(PercentageW(0.32f), GameData.screenHeight - PercentageH(0.065f), 100, PercentageH(0.025f)), new Color(255, 229, 58, 255));
            staminaBar.SetStatusString("AMMO:", 30, PercentageW(0.1f));
        }

        public override void update()
        {
            healthBar.SetStatusValue(PlayerData.health);
            staminaBar.SetStatusValue(PlayerData.stamina);
        }

        public override void draw()
        {
            bottomBar.draw();
            healthBar.draw();
            staminaBar.draw();
        }
    }
}