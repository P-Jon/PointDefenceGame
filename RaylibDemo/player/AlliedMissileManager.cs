using PointDefence.Core.Models;
using PointDefence.Player.Models;
using System.Numerics;

namespace PointDefence.Player
{
    public class AlliedMissileManager : ManagerObject<Missile>
    {
        public AlliedMissileManager()
        {
        }

        public override void draw()
        {
            DrawMissiles();
        }

        public override void update()
        {
            UpdateMissiles();
            RemoveFromObjectList();
        }

        public void InstantiateMissile(Vector2 pointedPosition)
        {
            ObjectList.Add(new AlliedMissile(pointedPosition));
        }

        private void UpdateMissiles()
        {
            ObjectList.ForEach(x => x.update());
        }

        private void DrawMissiles()
        {
            ObjectList.ForEach(x => x.draw());
        }
    }
}