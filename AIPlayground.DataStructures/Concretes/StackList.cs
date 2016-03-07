using AIPlayground.DataStructures.Abstracts;
using System;
using System.Collections.Generic;

namespace AIPlayground.DataStructures.Concretes
{
    public class StackList<T> : IStack<T>
    {
        private List<T> _list = new List<T>();

        public int Count => _list.Count;
        
        public bool IsEmpty => _list.Count == 0;
        
        public T Peek()
        {
            return _list[_list.Count - 1];
        }

        public T Pop()
        {
            if (_list.Count == 0) throw new InvalidOperationException("Stack is empty");

            var item = _list[_list.Count - 1];
            _list.RemoveAt(_list.Count - 1);
            return item;
        }

        public void Push(T data)
        {
            _list.Add(data);
        }
    }
}
