using PointDefence.Core.Models;
using System.Collections.Generic;

namespace PointDefence.Assets
{
    public class ExplosionManager : ManagerObject<Explosion>
    {
        private List<Explosion> addQueue = new List<Explosion>();

        public void AddExplosionToList(Explosion e)
        {
            ObjectList.Add(e);
        }

        public void QueueAddExplosionToList(Explosion e)
        {
            addQueue.Add(e);
        }

        public override void update()
        {
            addQueue.ForEach(x => ObjectList.Add(x));
            addQueue = new List<Explosion>();
            ObjectList.ForEach(x => x.update());
            RemoveFromObjectList();
        }

        public override void draw()
        {
            ObjectList.ForEach(x => x.draw());
        }
    }
}