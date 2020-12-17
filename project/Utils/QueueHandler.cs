using System.Collections;
using FS.Interfaces;

namespace FS.Utils
{
    public class QueueHandler<T> : ICollectionHandler<T> where T : Queue
    {
        public void Add(T collection, string value)
        {
            collection.Enqueue(value);
        }

        public void Remove(T collection)
        {
            collection.Dequeue();
        }
    }
}