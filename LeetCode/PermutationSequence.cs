using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode
{
    [TestClass]
    public class PermutationSequence
    {
        #region Tests
        [DataTestMethod]
        [DataRow(1, 1, "1")]
        [DataRow(3, 2, "132")]
        [DataRow(3, 3, "213")]
        [DataRow(3, 6, "321")]
        [DataRow(4, 9, "2314")]
        [DataRow(4, 1, "1234")]
        public void GetPermutation_Solutions(int n, int k, string expected)
        {
            var solution = new Solution();

            var result = solution.GetPermutation(n, k);

            Assert.AreEqual(expected, result);
        }
        #endregion

        public class Solution
        {
            public string GetPermutation(int n, int k)
            {
                var result = new List<int>();

                var list = new LinkedList<int>(Enumerable.Range(1, n));

                var a = list.Select(b=>b).ToList();

                var f = Factorial(n - 1);

                Dfs(n, k - 1, f, list, result);

                return string.Join("", result);
            }

            private void Dfs(int n, int k, int f, LinkedList<int> list, List<int> result)
            {
                int subPath = k / f;

                LinkedListNode<int> node = list.First;
                for (int i = 0; i < subPath; i++)
                    node = node.Next;

                result.Add(node.Value);
                list.Remove(node);

                n -= 1;
                k %= f;

                if (n > 0)
                    Dfs(n, k, f / n, list, result);
            }

            private int Factorial(int number)
            {
                int result = 1;
                while (number > 1)
                {
                    result *= number;
                    number -= 1;
                }
                return result;
            }
        }

        public class Solution2
        {
            public string GetPermutation(int n, int k)
            {
                var result = new List<int>();

                bool[] used = new bool[n];

                var f = Factorial(n - 1);

                Dfs(n, k, f, used, result);

                return string.Join("", result);
            }

            private void Dfs(int n, int k, int f, bool[] used, List<int> result)
            {
                int curr = 0;
                int sub = 0;
                for (; sub < n; sub++, curr++)
                {
                    while (used[curr]) curr++;
                    if (k <= (sub + 1) * f)
                        break;
                }

                result.Add(curr + 1);
                used[curr] = true;

                n -= 1;
                k -= sub * f;

                if (n > 0)
                    Dfs(n, k, f / n, used, result);
            }

            private int Factorial(int number)
            {
                int result = 1;
                while (number > 1)
                {
                    result *= number;
                    number -= 1;
                }
                return result;
            }
        }
    }
}