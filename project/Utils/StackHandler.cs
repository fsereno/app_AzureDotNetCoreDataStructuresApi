using System.Collections;
using FabioSereno.App_AzureDotNetCoreDataStructuresApi.Interfaces;

namespace FabioSereno.App_AzureDotNetCoreDataStructuresApi.Utils
{
    public class StackHandler<T> : ICollectionHandler<T> where T : Stack
    {
        /// </inheritdoc>
        public void Add(T collection, string value)
        {
            collection.Push(value);
        }

        /// </inheritdoc>
        public void Remove(T collection)
        {
            collection.Pop();
        }
    }
}