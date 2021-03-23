using Raylib_cs;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using RaylibDemo.core;

namespace RaylibDemo.player
{
    public class PlayerController
    {
        private int width = 50;
        private int height = 50;

        // Init Values
        private int posX;

        private int posY;

        // Icon Data
        private Rectangle playerIcon;

        private Color playerColor;

        public PlayerController()
        {
            posX = (GameData.screenWidth / 2) - width;
            posY = (GameData.screenHeight / 2) - height;

            playerIcon = new Rectangle(posX, posY, width, height);
            playerColor = new Color(73, 82, 208, 225);
        }

        public void DrawPlayer()
        {
            DrawRectangleRec(playerIcon, playerColor);
        }
    }
}