using PointDefence.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;

namespace PointDefence.Enemies
{
    public class EnemySpawnManager : GameObject
    {
        public List<Missile> missileList = new List<Missile>();

        private List<Missile> missileDestroyList = new List<Missile>();

        private int maxEnemies;
        private double time;

        public EnemySpawnManager(int maxEnemies)
        {
            this.maxEnemies = maxEnemies;
            time = Raylib.GetTime();
        }

        public override void update()
        {
            UpdateMissiles();
            InstantiateMissile();
            RemoveFromMissileList();
        }

        public override void draw()
        {
            DrawMissiles();
        }

        public void InstantiateMissile()
        {   // This will get progressively harder, but is a good POC for now.
            if (!(missileList.Count >= maxEnemies) && Raylib.GetTime() >= time + 1.5f)
            {
                missileList.Add(new Missile());
                time = Raylib.GetTime();
            }
        }

        private void UpdateMissiles()
        {
            missileList.ForEach(x => x.update());
        }

        private void DrawMissiles()
        {
            missileList.ForEach(x => x.draw());
        }

        /// <summary>
        /// Will Queue Object Removals
        /// </summary>
        /// <param name="missile"></param>
        public void QueueRemoveFromMissileList(Missile missile)
        {
            missileDestroyList.Add(missile);
        }

        private void RemoveFromMissileList()
        {
            missileDestroyList.ForEach(x => missileList.Remove(x));
            missileDestroyList = new List<Missile>();
        }
    }
}