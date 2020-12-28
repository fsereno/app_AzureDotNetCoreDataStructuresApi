using System.Collections;
using FabioSereno.App_AzureDotNetCoreDataStructuresApi.Interfaces;

namespace FabioSereno.App_AzureDotNetCoreDataStructuresApi.Utils
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