using PointDefence.Core.Models;
using PointDefence.Enemies;
using System;
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
            ObjectList.Add(new Missile(pointedPosition, true));
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