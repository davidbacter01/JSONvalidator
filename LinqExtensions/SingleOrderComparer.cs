using System;
using System.Collections.Generic;

namespace LinqExtensions
{
    public class SingleOrderComparer<TElement,TKey> : IComparer<TElement>
    {
        private readonly IComparer<TKey> comparer;
        private readonly Func<TElement, TKey> keySelector;
        public SingleOrderComparer(Func<TElement, TKey> keySelector, IComparer<TKey> comparer)
        {
            this.comparer = comparer;
            this.keySelector = keySelector;
        }
        public int Compare(TElement x, TElement y)
        {
            return (comparer.Compare(keySelector(x), keySelector(y)));
        }
    }
}
