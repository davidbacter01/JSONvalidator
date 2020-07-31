using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace LinqExtensions
{
    public class OrderedEnumerable<TSource, TKey> : IOrderedEnumerable<TSource>
    {
        private readonly TSource[] source;
        private readonly IComparer<TSource> comparer;
        public OrderedEnumerable(IEnumerable<TSource> source,IComparer<TSource> singleOrderComparer)
        {
            this.source = source.ToArray();
            comparer = singleOrderComparer;
            Array.Sort(this.source, comparer);
        }
        public IOrderedEnumerable<TSource> CreateOrderedEnumerable<TKey1>(Func<TSource, TKey1> keySelector, IComparer<TKey1> comparer, bool descending)
        {
            if (keySelector == null || comparer == null)
            {
                throw new ArgumentNullException();
            }

            IComparer<TSource> secondaryComparer = new SingleOrderComparer<TSource, TKey1>(keySelector, comparer);
            IComparer<TSource> finalComparer = new FinalComparer<TSource>(this.comparer, secondaryComparer);
            return new OrderedEnumerable<TSource, TKey1>(source, finalComparer);
        }

        public IEnumerator<TSource> GetEnumerator()
        {
            foreach (var el in source)
            {
                yield return el;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private TKey[] GetKeys(TSource[] source, Func<TSource, TKey> keySelector)
        {
            TKey[] keys = new TKey[source.Length];
            int i = 0;
            foreach (var el in source)
            {
                keys[i] = keySelector(el);
                i++;
            }

            return keys;
        }
    }
}
