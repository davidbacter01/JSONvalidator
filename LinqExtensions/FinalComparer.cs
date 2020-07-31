using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace LinqExtensions
{
    class FinalComparer<T> : IComparer<T>
    {
        private readonly IComparer<T> first;
        private readonly IComparer<T> second;
        public FinalComparer(IComparer<T> first,IComparer<T> second)
        {
            this.first = first;
            this.second = second;
        }
        public int Compare( T x, T y)
        {
            if (first.Compare(x, y) != 0)
            {
                return first.Compare(x, y);
            }

            return second.Compare(x, y);
        }
    }
}
