namespace AIPlayground.DataStructures.Abstracts
{
    public interface IStack<T>
    {
        void Push(T data);

        T Pop();

        T Peek();

        int Count { get; }

        bool IsEmpty { get; }
    }
}
