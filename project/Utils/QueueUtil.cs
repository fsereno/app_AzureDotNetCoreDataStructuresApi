using System.Collections;
using FabioSereno.App_AzureDotNetCoreDataStructuresApi.Interfaces;

namespace FabioSereno.App_AzureDotNetCoreDataStructuresApi.Utils
{
    public class QueueUtil : ICollectionUtil<Queue>
    {
        /// </inheritdoc>
        public void Add(Queue collection, string value)
        {
            collection?.Enqueue(value);
        }

        /// </inheritdoc>
        public void Remove(Queue collection)
        {
            collection?.Dequeue();
        }

        /// </inheritdoc>
        public Queue Create(string[] array = null)
        {
            var collection = array != null ? new Queue(array) : new Queue();

            return collection;
        }
    }
}