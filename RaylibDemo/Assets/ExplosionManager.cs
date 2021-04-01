using PointDefence.Core.Models;

namespace PointDefence.Assets
{
    public class ExplosionManager : ManagerObject<Explosion>
    {
        public void AddExplosionToList(Explosion e)
        {
            ObjectList.Add(e);
        }

        public override void update()
        {
            ObjectList.ForEach(x => x.update());
        }

        public override void draw()
        {
            ObjectList.ForEach(x => x.draw());
        }
    }
}