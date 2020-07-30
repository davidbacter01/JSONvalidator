using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace LinqExtensions
{
    public static class IEnumerableExt
    {
        public static bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            TestArgumentNullExceptions(source);

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
            TestArgumentNullExceptions(source);
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
            TestArgumentNullExceptions(source);
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
            TestArgumentNullExceptions(source);
            foreach (TSource el in source)
            {
                yield return selector(el);
            }
        }

        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
        {
            TestArgumentNullExceptions(source);
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
            TestArgumentNullExceptions(source, predicate);
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
            TestArgumentNullExceptions(source);
            var result = new Dictionary<TKey, TElement>();
            foreach (TSource el in source)
            {
                result.Add(keySelector(el), elementSelector(el));
            }

            return result;
        }

        public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> first,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, TResult> resultSelector)
        {
            TestArgumentNullExceptions(first, second);
            IEnumerator<TFirst> firstEnumerator = first.GetEnumerator();
            IEnumerator<TSecond> secondEnumerator = second.GetEnumerator();
            while (firstEnumerator.MoveNext() && secondEnumerator.MoveNext())
            {
                yield return resultSelector(firstEnumerator.Current, secondEnumerator.Current);
            }
        }

        public static TAccumulate Aggregate<TSource, TAccumulate>(
            this IEnumerable<TSource> source,
            TAccumulate seed,
            Func<TAccumulate, TSource, TAccumulate> func)
        {
            TestArgumentNullExceptions(source, seed);
            foreach (var el in source)
            {
                seed = func(seed, el);
            }

            return seed;
        }

        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(
            this IEnumerable<TOuter> outer,
            IEnumerable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TOuter, TInner, TResult> resultSelector)
        {
            TestArgumentNullExceptions(inner, outer);
            foreach (var outerEl in outer)
            {
                foreach (var innerEl in inner)
                {
                    if (outerKeySelector(outerEl).Equals(innerKeySelector(innerEl)))
                    {
                        yield return resultSelector(outerEl, innerEl);
                    }
                }
            }
        }

        public static IEnumerable<TSource> Distinct<TSource>(
            this IEnumerable<TSource> source,
            IEqualityComparer<TSource> comparer)
        {
            TestArgumentNullExceptions(source);
            var uniques = new HashSet<TSource>(comparer);
            foreach (var el in source)
            {
                if (uniques.Add(el))
                {
                    yield return el;
                }
            }
        }

        public static IEnumerable<TSource> Union<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer)
        {
            TestArgumentNullExceptions(first, second);
            var uniques = new HashSet<TSource>(comparer);
            foreach (var el in first)
            {
                if (uniques.Add(el))
                {
                    yield return el;
                }
            }

            foreach (var el in second)
            {
                if (uniques.Add(el))
                {
                    yield return el;
                }
            }
        }

        public static IEnumerable<TSource> Intersect<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer)
        {
            HashSet<TSource> secondUniques = new HashSet<TSource>(second, comparer);
            foreach (TSource item in first)
            {
                if (secondUniques.Remove(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<TSource> Except<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer)
        {
            HashSet<TSource> commonElements = new HashSet<TSource>(second, comparer);
            foreach (TSource item in first)
            {
                if (commonElements.Add(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            Func<TKey, IEnumerable<TElement>, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
        {
            TestArgumentNullExceptions(source, keySelector);
            TestArgumentNullExceptions(elementSelector, resultSelector);
            var result = new Dictionary<TKey, List<TElement>>(comparer);
            foreach (var element in source)
            {
                var key = keySelector(element);
                if (result.ContainsKey(key))
                {
                    result[key].Add(elementSelector(element));
                }
                else
                {
                    result.Add(key, new List<TElement>() { elementSelector(element) });
                }
            }

            foreach (var keyEnum in result)
            {
                yield return resultSelector(keyEnum.Key, keyEnum.Value);
            }
        }

        public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            IComparer<TKey> comparer)
        {
            TestArgumentNullExceptions(source, keySelector);
            return new OrderedEnumerable<TSource, TKey>(source, comparer, keySelector);
        }

        public static IOrderedEnumerable<TSource> ThenBy<TSource, TKey>(
            this IOrderedEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            IComparer<TKey> comparer)
        {
            TestArgumentNullExceptions(source, keySelector);
            return source.CreateOrderedEnumerable(keySelector, comparer, false);
        }

        private static void TestArgumentNullExceptions(object first, object second)
        {
            if (first == null || second == null)
            {
                throw new ArgumentNullException();
            }
        }

        private static void TestArgumentNullExceptions(object first)
        {
            if (first == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
