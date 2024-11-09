using System.Collections.Generic;
using System.Linq;

namespace TheRealIronDuck.Runtime.Helper.List
{
    public static class QueueExtensions
    {
        #region PUBLIC METHODS

        public static void Shuffle<T>(this Queue<T> queue)
        {
            var items = queue.ToList();
            for (var i = 0; i < items.Count; i++)
            {
                var random = UnityEngine.Random.Range(0, items.Count);
                (items[i], items[random]) = (items[random], items[i]);
            }

            queue.Clear();
            foreach (var item in items)
            {
                queue.Enqueue(item);
            }
        }

        #endregion
    }
}