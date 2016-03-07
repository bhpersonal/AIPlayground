using AIPlayground.DataStructures.Abstracts;
using System;

namespace AIPlayground.DataStructures.Concretes
{
    public class PriorityQueueHeap<TData> : IPriorityQueue<TData>
        where TData : class
    {
        private Tuple<float, TData>[] _heap;

        private int _heapLength;

        private int _bufferLength;

        public PriorityQueueHeap()
        {
            _heapLength = 0;
            _bufferLength = 1;
            _heap = new Tuple<float, TData>[_bufferLength];
        }


        private void UpShuffle(int i)
        {
            var cursor = i;
            while (cursor > 1)
            {
                var index = (int)(cursor / 2);
                
                if (_heap[index].Item1 <= _heap[cursor].Item1)
                    return;

                var temp = _heap[index];
                _heap[index] = _heap[cursor];
                _heap[cursor] = temp;

                cursor = index;
            }
        }

        private void DownShuffle(int i)
        {
            var cursor = i;
            while (cursor < _heapLength)
            {
                var index1 = cursor * 2;
                var index2 = cursor * 2 + 1;
                int index;
                if (index2 <= _heapLength)
                {
                    if (_heap[index1].Item1 < _heap[index2].Item1)
                    {
                        index = index1;
                    }
                    else
                    {
                        index = index2;
                    }
                }
                else if (index1 <= _heapLength)
                {
                    index = index1;
                }
                else
                {
                    return;
                }
                
                if (_heap[index].Item1 >= _heap[cursor].Item1)
                    return;
                
                var temp = _heap[index];
                _heap[index] = _heap[cursor];
                _heap[cursor] = temp;

                cursor = index;
            }
        }

        private void IncreaseBuffer()
        {
            _bufferLength = (_heapLength + 1) * 2 + 1; // wrong bah
            Array.Resize(ref _heap, _bufferLength);
        }
        

        public void Insert(float value, TData data)
        {
            if (1 + _heapLength == _bufferLength)
                IncreaseBuffer();

            _heapLength++;
            _heap[_heapLength] = new Tuple<float, TData>(value, data);
            UpShuffle(_heapLength);
        }

        public TData ExtractTop()
        {
            if (_heapLength == 0) throw new InvalidOperationException("Priority heap is empty");

            var result = _heap[1];
            
            _heap[1] = _heap[_heapLength];
            _heap[_heapLength] = null;
            _heapLength--;

            if (_heapLength > 0)
                DownShuffle(1);

            return result.Item2;
        }

        public TData PeekAtTop()
        {
            if (_heapLength == 0) throw new InvalidOperationException("Priority heap is empty");
            return _heap[1].Item2;
        }

        public bool IsEmpty => _heapLength == 0;

        public int Count => _heapLength;
    }
}
