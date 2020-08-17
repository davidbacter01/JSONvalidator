using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace LinqExercices
{
    public static class Functions
    {
        public static (int, int) CountConsonantsAndVowels(string text)
        {
            if (text == null)
            {
                throw new InvalidOperationException();
            }

            (int Vowels, int Consonants) count = (0, 0);
            return text.Aggregate(count, (count, x) =>
            {
                _ = "aeiouAEIOU".Contains(x) ? count.Vowels++ : count.Consonants++;
                return count;
            });
        }

        public static char GetFirstNonRepetedChar(string text)
        {
            if (text == null)
            {
                throw new InvalidOperationException();
            }

            return text.GroupBy(x => x).First(group => group.Count() == 1).Key;
            //return text.FirstOrDefault(c => text.Count(x => x == c) == 1);
        }

        public static bool TryStringToInt(string number, out int result)
        {
            if (number == null)
            {
                throw new InvalidOperationException();
            }

            if (number.All(x => x <= '9' && x >= '0'))
            {
                result = number.Aggregate(0, (x, y) => x * 10 + y - '0');
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

            return Enumerable.Range(1, text.Length)
                .SelectMany(x => Enumerable.Range(0, text.Length - x + 1)
                    .Select(y => text.Substring(y, x)))
                .Where(partition => partition.SequenceEqual(partition.Reverse())).ToList();
        }

        public static IEnumerable<IEnumerable<int>> GetValuesWithSum(IEnumerable<int> numbers, int sum)
        {
            if (numbers == null)
            {
                throw new InvalidOperationException();
            }

            return Enumerable.Range(1, numbers.Count())
                .SelectMany(x => Enumerable.Range(0, numbers.Count() - x + 1)
                    .Select(y => numbers.Skip(y).Take(x)))
                .Where(x => x.Sum() <= sum);
        }

        public static IEnumerable<string> GetValidSequenceOfSigns(int n, int k)
        {
            string[] signs = { "+", "-" };
            return GetPermutations(signs, n).Where(perm =>
            Enumerable.Range(1, n).Aggregate(0, (seed, en) =>
              seed += perm.ElementAt(en - 1) == "+" ? en : 0 - en) == k)
            .Select(x => Enumerable.Range(1, n)
            .Aggregate("", (seed, num) => seed + x.ElementAt(num - 1) + num) + $"={k}");
        }

        public static IEnumerable<IEnumerable<int>> GetTriplets(int[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException();
            }

            return GetPermutations(numbers, 3).Where(res =>
                res.ElementAt(0) * res.ElementAt(0)
                + res.ElementAt(1) * res.ElementAt(1)
                == res.ElementAt(2) * res.ElementAt(2)
            );
        }

        public static IEnumerable<ProductQ> GetWithMinimumOneFeature(IEnumerable<ProductQ> products, ICollection<Feature> features)
        {
            if (products == null || features == null)
            {
                throw new ArgumentNullException();
            }

            return products.Where(p => p.Features
                .Select(f => f.Id)
                .Any(id => features.Select(e => e.Id).Contains(id)));
        }

        public static IEnumerable<ProductQ> GetWithAllFeatures(IEnumerable<ProductQ> products, ICollection<Feature> features)
        {
            if (products == null || features == null)
            {
                throw new ArgumentNullException();
            }

            return products.Where(p => p.Features
                .Select(f => f.Id)
                .All(id => features.Select(e => e.Id).Contains(id)));
        }

        public static IEnumerable<ProductQ> GetWithNoFeatures(IEnumerable<ProductQ> products, ICollection<Feature> features)
        {
            if (products == null || features == null)
            {
                throw new ArgumentNullException();
            }

            return products.Where(p => !p.Features
                .Select(f => f.Id)
                .Any(id => features.Select(e => e.Id).Contains(id)));
        }

        public static IEnumerable<ProductS> MergeLists(IEnumerable<ProductS> first, IEnumerable<ProductS> second)
        {
            return first.Concat(second)
                .GroupBy(x => x.Name)
                .Select(p =>
                    new ProductS
                    {
                        Name = p.First().Name,
                        Quantity = p.Aggregate(0, (quant, prod) => quant + prod.Quantity)
                    });
        }

        public static IEnumerable<TestResults> RemoveLowerScores(IEnumerable<TestResults> tests)
        {
            return tests.GroupJoin(
                tests, t => t.FamilyId,
                t2 => t2.FamilyId,
                (tRes, results) =>
                    results.Aggregate(tRes, (seed, res) =>
                         seed = seed.Score < res.Score ? res : seed)
                    ).Distinct();
        }

        public static IEnumerable<string> GetMostUsedWords(string text)
        {
            var words = text.Split(new char[] { ' ', '.', ',', '!', '?', ';', ':', '\n', '\0' }, StringSplitOptions.RemoveEmptyEntries);
            return words.GroupBy(word => word)
                .OrderByDescending(g => g.Count())
                .Select(gr => $"{gr.Key} : {gr.Count()}");
        }

        public static bool IsValidSudoku(IEnumerable<IEnumerable<int>> sudokuBoard)
        {
            if (sudokuBoard == null)
            {
                throw new ArgumentNullException();
            }

            var columns = Enumerable.Range(0, 9)
                .Select(lineCount => Enumerable.Range(0, 9)
                .Select(columnCount => sudokuBoard
                    .ElementAt(columnCount)
                    .ElementAt(lineCount)
                    ));
            var groups = Enumerable.Range(0, 3).SelectMany(gy =>
             Enumerable.Range(0, 3).Select(gx =>
                 sudokuBoard.Skip(gy * 3).Take(3).Select(row =>
                     row.Skip(gx * 3).Take(3)
                 )
             )).Select(group => group.SelectMany(n => n));

            return columns.All(IsValidGroup) &&
                sudokuBoard.All(IsValidGroup) &&
                groups.All(IsValidGroup);
        }

        public static double PostfixCalculator(string equation)
        {
            if (equation == null)
            {
                throw new ArgumentNullException();
            }

            IEnumerable<double> operands = new double[] { };
            return equation.Split(' ')
                .Aggregate(operands,
                    (seed, element) =>
                        double.TryParse(element, out var num)
                            ? seed.Append(num)
                            : seed.SkipLast(2).Append(GetEquationResult(seed.TakeLast(2), element))
                ).First();
        }

        private static double GetEquationResult(IEnumerable<double> operands, string eqOperator)
        {
            var first = operands.ElementAt(0);
            var second = operands.ElementAt(1);
            return eqOperator switch
            {
                "+" => first + second,
                "-" => first - second,
                "*" => first * second,
                "/" => first / second,
                _ => throw new InvalidOperationException()
            };
        }
        private static bool IsValidGroup(IEnumerable<int> group)
        {
            return group.Distinct().Count() == group.Count() &&
                   group.All(x => x <= 9 && x > 0) &&
                   group.Count() == 9;
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
