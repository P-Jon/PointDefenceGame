﻿using Raylib_cs;
using RaylibDemo.core.Data;
using RaylibDemo.UI.Models;
using System.Collections.Generic;
using static RaylibDemo.Helper.ScreenCalculator;

namespace RaylibDemo.UI.Components
{
    public class HUD : UIComponent
    {
        private HUDElement bottomBar;

        private string HP = "HP:";
        private StatusBar healthBar;

        private string Stamina = "STAMINA:";
        private StatusBar staminaBar;

        public HUD()
        {
            bottomBar = new HUDElement(new Rectangle(0, GameData.screenHeight - PercentageH(0.1f), GameData.screenWidth, PercentageH(0.1f)), new Color(0, 58, 88, 255));
            healthBar = new StatusBar(new Rectangle(PercentageW(0.1f), GameData.screenHeight - PercentageH(0.065f), 100, PercentageH(0.025f)), new Color(175, 10, 10, 255));
            healthBar.SetStatusString("HP:", 30, PercentageW(0.05f));
            staminaBar = new StatusBar(new Rectangle(PercentageW(0.25f), GameData.screenHeight - PercentageH(0.065f), 100, PercentageH(0.025f)), new Color(255, 229, 58, 255));
        }

        public override void draw()
        {
            bottomBar.draw();
            healthBar.draw();
            staminaBar.draw();
        }
    }
}