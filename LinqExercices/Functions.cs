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

            return text.FirstOrDefault(c => text.Count(x => x == c) == 1);
        }

        public static bool TryStringToInt(string number,out int result)
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

        public static IEnumerable<ProductQ> GetWithMinimumOneFeature(IEnumerable<ProductQ> products,ICollection<Feature> features)
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

        public static bool IsValidSudoku(IEnumerable<IEnumerable<int>> sudokuBoard)
        {
            if (sudokuBoard == null)
            {
                throw new ArgumentNullException();
            }

            var columns = Enumerable.Range(0, 9)
                .Select(lineCount => Enumerable.Range(0,9)
                .Select(columnCount=>sudokuBoard
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
            var extendedEquation = equation.Split(' ');
            if (equation == null)
            {
                throw new ArgumentNullException();
            }

            return extendedEquation.Aggregate(new Stack<double>(), GetStackState).Pop();
        }

        private static Stack<double> GetStackState(Stack<double> operands, string eqOperator)
        {
            if (!double.TryParse(eqOperator, out double number)&&
                !new[] { "+", "-", "*", "/" }.Contains(eqOperator))
            {
                throw new ArgumentException("Equation format is unkown!");
            }
            else
            {
                switch (eqOperator)
                {
                    case "+":
                        operands.Push(operands.Pop() + operands.Pop());
                        break;
                    case "-":
                        double toSubtract = operands.Pop();
                        operands.Push(operands.Pop() - toSubtract);
                        break;
                    case "*":
                        operands.Push(operands.Pop() * operands.Pop());
                        break;
                    case "/":
                        double divider = operands.Pop();
                        operands.Push(operands.Pop() / divider);
                        break;
                    default:
                        operands.Push(number);
                        break;
                }
            }

            return operands;
        }
        private static bool IsValidGroup(IEnumerable<int> group)
        {
            return group.Distinct().Count() == group.Count()&&
                   group.All(x => x <= 9 && x > 0)&&
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
