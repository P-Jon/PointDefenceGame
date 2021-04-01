using System.Collections.Generic;

namespace PointDefence.Core.Models
{
    public abstract class ManagerObject<T> : GameObject
    {
        protected List<T> ObjectList = new List<T>();

        protected List<T> ObjectDestroyList = new List<T>();

        public void QueueRemoveFromObjectList(T obj)
        {
            ObjectDestroyList.Add(obj);
        }

        protected void RemoveFromObjectList()
        {
            ObjectDestroyList.ForEach(x => ObjectList.Remove(x));
            ObjectDestroyList = new List<T>();
        }
    }
}