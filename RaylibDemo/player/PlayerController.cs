using PointDefence.Core.Data;
using PointDefence.Core.Models;
using PointDefence.Enemies;
using Raylib_cs;

namespace PointDefence.Player
{
    public class PlayerController : ManagerObject<Missile>
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

        public override void update()
        {
            throw new System.NotImplementedException();
        }

        public override void draw()
        {
            throw new System.NotImplementedException();
        }
    }
}