using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPlayground.DataStructures.Abstracts
{
    public interface IPriorityQueue<TData>
        where TData : class
    {
        void Insert(float value, TData data);

        TData ExtractTop();

        TData PeekAtTop();

        bool IsEmpty { get; }

        int Count { get; }
    }
}
