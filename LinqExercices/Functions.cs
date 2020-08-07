using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Immutable;

namespace LinqExercices
{
    public static class Functions
    {
        public static Dictionary<string,int> CountConsonantsAndVowels(string text)
        {
            if (text == null)
            {
                throw new InvalidOperationException();
            }

            var result = new Dictionary<string, int>() { { "vowels", 0 }, { "consonants", 0 } };
            result["vowels"] = text.Count(x => "aeiouAEIOU".Contains(x));
            result["consonants"] = text.Count(x => !"aeiouAEIOU".Contains(x));
            return result;
        }

        public static char GetFirstNonRepetedChar(string text)
        {
            if (text == null)
            {
                throw new InvalidOperationException();
            }

            return text.FirstOrDefault(c => text.IndexOf(c) == text.LastIndexOf(c));
        }

        public static bool TryStringToInt(string number,out int result)
        {
            if (number == null)
            {
                throw new InvalidOperationException();
            }

            if (number.All(x => x <= '9' && x >= '0'))
            {
                result = number.Aggregate(0, (x, y) => x * 10 + y - 48);
                return true;
            }

            result = -1;
            return false;
        }

        public static char GetMaximumOccurencesChar(string text)
        {
            if (text == null)
            {
                throw new InvalidOperationException();
            }

            return text.GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key;
        }

        public static IEnumerable<string> GetPalindromes(string text)
        {
            if (text == null)
            {
                throw new InvalidOperationException();
            }

            var substrings = from x in Enumerable.Range(0, text.Length)
                             from y in Enumerable.Range(0, text.Length - x + 1)
                             where y >= 1
                             select text.Substring(x, y);
            return substrings.Where(x => x.SequenceEqual(x.Reverse()));
        }

        public static IEnumerable<IEnumerable<int>> GetValuesWithSum(IEnumerable<int> numbers, int sum)
        {
            if (numbers == null)
            {
                throw new InvalidOperationException();
            }

            var pairs = from x in Enumerable.Range(0, numbers.Count())
                        from y in Enumerable.Range(0, numbers.Count() - x + 1)
                        where y >= 1
                        select numbers.Skip(x).Take(y);
            return pairs.Where(x => x.Sum() <= sum);
        }

        public static IEnumerable<string> GetValidSequenceOfSigns(int n, int k)
        {
            var signs = new List<string>() { "+","-"};
            return GetPermutations(signs, n).Where(permutations =>
            {
                int i = 1;
                int result = 0;
                foreach (var sign in permutations)
                {
                    result += sign == "+" ? i : 0 - i;
                    i++;
                }

                return result == k;
            }).Select(x=> 
            {
                var result = "";
                int i = 1;
                foreach (var sign in x)
                {
                    result += sign + i.ToString();
                    i++;
                }

                result += $"={k}";
                return result;
            });
        }

        public static IEnumerable<IEnumerable<int>> GetTriplets(int[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException();
            }

            return GetPermutations(numbers, 3).Where(triplet => 
            {
                var res = triplet.ToArray();
                return res[0] * res[0] + res[1] * res[1] == res[2] * res[2];
            });
        }

        public static IEnumerable<ProductQ> GetWithMinimumOneFeature(IEnumerable<ProductQ> products,ICollection<Feature> features)
        {
            if (products == null || features == null)
            {
                throw new ArgumentNullException();
            }

            return products.Where(product => product
            .Features.Select(feat=>feat.Id)
            .Intersect(
                features.Select(feat=>feat.Id))
            .Count() >= 1);
        }

        public static IEnumerable<ProductQ> GetWithAllFeatures(IEnumerable<ProductQ> products, ICollection<Feature> features)
        {
            if (products == null || features == null)
            {
                throw new ArgumentNullException();
            }

            return products.Where(product => product
            .Features.Select(feat => feat.Id)
            .Intersect(
                features.Select(feat => feat.Id))
            .Count() ==features.Count());
        }

        public static IEnumerable<ProductQ> GetWithNoFeatures(IEnumerable<ProductQ> products, ICollection<Feature> features)
        {
            if (products == null || features == null)
            {
                throw new ArgumentNullException();
            }

            return products.Where(product => product
            .Features.Select(feat => feat.Id)
            .Intersect(
                features.Select(feat => feat.Id))
            .Count() == 0);
        }

        public static IEnumerable<ProductS> MergeLists(IEnumerable<ProductS> first, IEnumerable<ProductS> second)
        {
            var grouped = first.Concat(second);
            return grouped.GroupJoin(
                grouped,
                prod => prod.Name,
                prod => prod.Name,
                (prod, prodList) => new ProductS()
                {
                    Name = prod.Name,
                    Quantity = prodList.Select(p => p.Quantity).Sum()
                }).Distinct();
        }

        public static IEnumerable<TestResults> RemoveLowerScores(IEnumerable<TestResults> tests)
        {
            return tests.GroupJoin(
                tests,
                result => result.FamilyId,
                result => result.FamilyId,
                (result, resultList) =>
                    resultList.Where(
                        res=>res.Score == resultList.Select(
                            res => res.Score).Max()).First()
                ).Distinct();
        }

        public static IEnumerable<string> GetMostUsedWords(string text)
        {
            var words = text.Split(new char[] { ' ', '.', ',', '!', '?', ';', ':', '\n', '\0' }, StringSplitOptions.RemoveEmptyEntries);
            return words.GroupJoin(
                words,
                word => word,
                word => word,
                (word, wordList) =>
                new { Word = word, wordCount = wordList.Count() })
                .Distinct()
                .OrderByDescending(x => x.wordCount)
                .Select(x => $"{x.Word} : {x.wordCount}");                
        }

        private static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });
            return GetPermutations(list, length - 1)
                .SelectMany(t => list,
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }
    }

    public struct ProductS
    {
        public string Name;
        public int Quantity;
    }

    public class ProductQ
    {
        public string Name { get; set; }
        public ICollection<Feature> Features { get; set; }
    }

    public class Feature
    {
        public int Id { get; set; }
    }

    public class TestResults
    {
        public string Id { get; set; }
        public string FamilyId { get; set; }
        public int Score { get; set; }
    }
}
