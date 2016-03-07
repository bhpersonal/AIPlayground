namespace AIPlayground.DataStructures.Abstracts
{
    public interface IQueue<T>
    {
        void Enqueue(T data);

        T Peek();

        T Dequeue();

        int Count { get; }

        bool IsEmpty { get; }
    }
}
