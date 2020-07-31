using System.Collections.Generic;

namespace LinqExtensions
{
    class FinalComparer<T> : IComparer<T>
    {
        private readonly IComparer<T> first;
        private readonly IComparer<T> second;
        public FinalComparer(IComparer<T> first, IComparer<T> second)
        {
            this.first = first;
            this.second = second;
        }
        public int Compare( T x, T y)
        {
            int result = first.Compare(x, y);
            if (result != 0)
            {
                return result;
            }

            return second.Compare(x, y);
        }
    }
}
