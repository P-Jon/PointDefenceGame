using PointDefence.core.Data;
using Raylib_cs;
using static Raylib_cs.Color;

namespace PointDefence.player
{
    public class PlayerController
    {
        private int width = 50;
        private int height = 50;

        private int offsetX;
        private int offsetY;
        private int posX;
        private int posY;

        private Color playerColor;

        public PlayerController()
        {
            posX = (GameData.screenWidth / 2) - width;
            posY = (GameData.screenHeight / 2) - height;
            offsetX = width / 2;
            offsetY = height / 2;
            playerColor = new Color(73, 82, 208, 225);
        }

        public void ChangePosition(int x, int y)
        {
            posX = x - offsetX;
            posY = y - offsetY;
        }

        public void DrawPlayer()
        {
            Raylib.DrawRectangle(posX, posY, width, height, playerColor);
        }
    }
}