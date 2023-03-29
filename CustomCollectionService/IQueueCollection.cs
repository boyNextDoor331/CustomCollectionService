namespace CustomCollectionService
{
    public interface IQueueCollection<T> : IEnumerable<T>
    {
        void Enqueue(T value);
        T Dequeue();
    }
}
