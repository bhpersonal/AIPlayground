using AIPlayground.DataStructures.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AIPlayground.DataStructures.Concretes
{
    public class QueueLinkedList<T> : IQueue<T>
    {
        private LinkedList<T> _linkedList = new LinkedList<T>();

        public int Count => _linkedList.Count;

        public bool IsEmpty => _linkedList.Count == 0;

        public T Dequeue()
        {
            if (_linkedList.Count == 0) throw new InvalidOperationException("Queue is empty");

            var item = _linkedList.First();
            _linkedList.RemoveFirst();
            return item;
        }

        public void Enqueue(T data)
        {
            _linkedList.AddLast(data);
        }

        public T Peek()
        {
            return _linkedList.First();
        }
    }
}
