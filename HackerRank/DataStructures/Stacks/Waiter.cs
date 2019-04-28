using System.Collections.Generic;
using Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRank.DataStructures.Stacks
{
    [TestClass]
    public class Waiter
    {
        [TestMethod]
        public void Waiter_Solutions()
        {
            AssertEnumerable.AreEqual(new[] {4, 6, 3, 7, 5}, waiter(new[] {3, 4, 7, 6, 5}, 1));
            AssertEnumerable.AreEqual(new[] {4, 4, 9, 3, 3}, waiter(new[] {3, 3, 4, 4, 9}, 2));
            AssertEnumerable.AreEqual(new[] {4, 4, 9, 3, 3, 5}, waiter(new[] {3, 3, 4, 4, 9, 5}, 3));
        }

        /*
         * Complete the waiter function below.
         */
        static int[] waiter(int[] number, int q)
        {
            List<int> result = new List<int>(number.Length);
            Stack<int> aPrev = new Stack<int>(number);

            for (int i = 0; i < q; i++)
            {
                var a = new Stack<int>();
                var b = new Stack<int>();
                var prime = GetPrime(i);

                while (aPrev.Count > 0)
                {
                    var curr = aPrev.Pop();

                    if (curr % prime == 0)
                        b.Push(curr);
                    else
                        a.Push(curr);
                }

                while (b.Count > 0)
                    result.Add(b.Pop());

                aPrev = a;
            }

            while (aPrev.Count > 0)
                result.Add(aPrev.Pop());

            return result.ToArray();
        }

        private static readonly List<int> Primes = new List<int> { 2 };
        private static int GetPrime(int i)
        {
            if (i < Primes.Count)
                return Primes[i];

            var num = GetPrime(i - 1);

            var isPrime = false;
            while (!isPrime)
            {
                num++;
                isPrime = true;
                for (int j = 0; j < Primes.Count; j++)
                {
                    if (num % Primes[j] > 0) continue;
                    isPrime = false;
                    break;
                }
            }
            Primes.Add(num);

            return num;
        }
    }
}
