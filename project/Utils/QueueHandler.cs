using System.Collections;
using FabioSereno.App_AzureDotNetCoreDataStructuresApi.Interfaces;

namespace FabioSereno.App_AzureDotNetCoreDataStructuresApi.Utils
{
    public class QueueHandler<T> : ICollectionHandler<T> where T : Queue, new()
    {
        public void Add(T collection, string value)
        {
            collection.Enqueue(value);
        }

        public void Remove(T collection)
        {
            collection.Dequeue();
        }

        public T Create(string[] array)
        {
            var collection = new T();

            for (var i = 0; i <  array.Length; i++)
            {
                Add(collection, array[i]);
            }

            return collection;
        }
    }
}