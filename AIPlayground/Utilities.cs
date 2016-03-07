using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPlayground
{
    public static class Utilities
    {
        private static Random _random = new Random();

        public static IEnumerable<T> RandomizeOrder<T>(this IEnumerable<T> source)
        {
            return source.OrderBy(x => _random.Next(10000));
        }
    }
}
