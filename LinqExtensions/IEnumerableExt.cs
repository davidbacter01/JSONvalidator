using System;
using System.Collections.Generic;

namespace LinqExtensions
{
    public static class IEnumerableExt
    {
        public static bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            ManageExceptions(source);

            foreach (TSource el in source)
            {
                if (!predicate(el))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool Any<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            ManageExceptions(source);
            foreach (TSource el in source)
            {
                if (predicate(el))
                {
                    return true;
                }
            }

            return false;
        }

        public static TSource First<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            ManageExceptions(source);
            foreach (TSource el in source)
            {
                if (predicate(el))
                {
                    return el;
                }
            }

            throw new InvalidOperationException();
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            ManageExceptions(source);
            foreach (TSource el in source)
            {
                yield return selector(el);
            }
        }

        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
        {
            ManageExceptions(source);
            foreach (TSource el in source)
            {
                foreach (TResult res in selector(el))
                {
                    yield return res;
                }
            }
        }

        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            ManageExceptions(source, predicate);
            foreach (TSource el in source)
            {
                if (predicate(el))
                {
                    yield return el;
                }
            }
        }

        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector)
        {
            ManageExceptions(source);
            var result = new Dictionary<TKey, TElement>();
            foreach (TSource el in source)
            {
                result.Add(keySelector(el), elementSelector(el));
            }

            return result;
        }


        private static void ManageExceptions(object first, object second)
        {
            if (first == null || second == null)
            {
                throw new ArgumentNullException();
            }
        }

        private static void ManageExceptions(object first)
        {
            if (first == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
