using AIPlayground.DataStructures.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPlayground.DataStructures.Concretes
{
    public class QueueCircularList<T> : IQueue<T>
    {
        private int _startPosition = 0;

        private int _endPosition = 0;

        private int _count = 0;

        private int _listCount = 10;

        private List<T> _list;

        public QueueCircularList()
        {
            _list = new List<T>(_listCount);
        }

        public int Count => _count;
        
        public T Dequeue()
        {
            if (_count == 0) throw new InvalidOperationException("Queue is empty");

            var item =  _list[_startPosition];
            _list[_startPosition] = default(T);
            _startPosition = (_startPosition + 1) % _listCount;
            _count--;
            return item;
        }

        public void Enqueue(T data)
        {
            if (IsAtCapacity)
                IncreaseCapacity();

            _startPosition = (_startPosition + 1) % _listCount; // Theoretically should never need modulus
            _list[_startPosition] = data;
            _count++;

        }

        public T Peek()
        {
            if (_count == 0) throw new InvalidOperationException("Queue is empty");

            return _list[_startPosition];
        }
        
        private bool IsAtCapacity
        {
            get { return _count == _listCount; }
        }
        
        private void IncreaseCapacity()
        {

            // Could be optimized further - copy the looped items instead of blank

            var increaseByCount = _listCount; // Double in size

            for (var i = 0; i < increaseByCount; i++)
                _list.Add(default(T));

            if (IsLooped)
            {
                for (var i = _listCount - 1; i >= _startPosition; i--)
                {
                    _list[i + increaseByCount] = _list[i];
                    _list[i] = default(T);
                }

                _startPosition += increaseByCount;
            }

            _listCount = _list.Count;

            _count++;
        }

        private bool IsLooped => _startPosition > _endPosition;

        public bool IsEmpty => _count == 0;
    }
}


