using PointDefence.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PointDefence.Enemies
{
    public class EnemySpawnManager : GameObject
    {
        public List<Missile> missileList;

        private int maxEnemies;

        public EnemySpawnManager(int maxEnemies)
        {
            this.maxEnemies = maxEnemies;
        }

        public override void update()
        {
            throw new NotImplementedException();
        }

        public override void draw()
        {
            throw new NotImplementedException();
        }

        public void InstantiateMissile()
        {
            var newMissile = new Missile();
        }

        public void RemoveFromMissileList(Missile missile)
        {
            missileList.Remove(missile);
        }
    }
}