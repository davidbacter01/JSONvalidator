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
