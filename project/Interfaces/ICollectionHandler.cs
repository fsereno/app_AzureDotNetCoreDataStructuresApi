namespace FS.Interfaces
{
    public interface ICollectionHandler<T>
    {
        void Add(T collection, string value);
        void Remove(T collection);
    }
}