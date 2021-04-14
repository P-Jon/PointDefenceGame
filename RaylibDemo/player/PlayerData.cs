using Raylib_cs;

namespace PointDefence.Player
{
    public class PlayerData
    {
        public static int health = 100;
        public static int ammo = 100;
        public static ulong score = 0;

        public static void ResetStats()
        {
            health = 100;
            ammo = 100;
            score = 0;
        }
    }
}