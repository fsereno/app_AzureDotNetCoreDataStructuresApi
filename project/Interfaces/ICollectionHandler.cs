namespace FS.Interfaces
{
    public interface ICollectionHandler<T>
    {
        /// <summary>
        /// Adds an item to the collection
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="value">Takes a collection of type T</param>
        void Add(T collection, string value);

        /// <summary>
        /// Removes an item to the collection
        /// </summary>
        /// <param name="collection">Takes a collection of type T</param>
        void Remove(T collection);
    }
}