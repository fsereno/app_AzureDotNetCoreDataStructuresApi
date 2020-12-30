using System.Collections;
using FabioSereno.App_AzureDotNetCoreDataStructuresApi.Interfaces;

namespace FabioSereno.App_AzureDotNetCoreDataStructuresApi.Utils
{
    public class StackHandler<T> : ICollectionHandler<T> where T : Stack, new()
    {
        /// </inheritdoc>
        public void Add(T collection, string value)
        {
            collection?.Push(value);
        }

        /// </inheritdoc>
        public void Remove(T collection)
        {
            collection?.Pop();
        }

        public T Create(string[] array = null)
        {
            var collection = new T();

            if (array != null)
            {
                for (var i = array.Length - 1; i >= 0; i--)
                {
                    Add(collection, array[i]);
                }
            }

            return collection;
        }
    }
}