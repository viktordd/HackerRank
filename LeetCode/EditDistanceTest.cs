using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode
{
    [TestClass]
    public class EditDistanceTest
    {
        [DataTestMethod]
        [DataRow("", "", 0)]
        [DataRow("horse", "", 5)]
        [DataRow("", "ros", 3)]
        [DataRow("horse", "ros", 3)]
        [DataRow("intention", "execution", 5)]
        public void EditDistance_Solutions(string word1, string word2, int expected)
        {
            var solution = new EditDistanceClass();
            var result1 = solution.MinDistanceDp1(word1, word2);
            var result2 = solution.MinDistanceDp2(word1, word2);
            var result3 = solution.MinDistanceDp3(word1, word2);
            Assert.AreEqual(expected, result1);
            Assert.AreEqual(expected, result2);
            Assert.AreEqual(expected, result3);
        }
    }

    // https://leetcode.com/problems/edit-distance/
    public class EditDistanceClass
    {
        public int MinDistanceDp3(string word1, string word2)
        {
            var m = word1.Length + 1;
            var n = word2.Length + 1;

            int[] memo = new int[n];

            for (int i = 0; i < n; i++)
            {
                memo[i] = i;
            }

            int pre;
            for (int i = 1; i < m; i++)
            {
                pre = memo[0];
                memo[0] = i;
                for (int j = 1; j < n; j++)
                {
                    int temp = memo[j];
                    if (word1[i - 1] == word2[j - 1])
                        memo[j] = pre;
                    else
                        memo[j] = 1 + Math.Min(memo[j], Math.Min(memo[j - 1], pre));

                    pre = temp;
                }
            }

            return memo[^1];
        }

        public int MinDistanceDp2(string word1, string word2)
        {
            var m = word1.Length + 1;
            var n = word2.Length + 1;

            int[,] memo = new int[2, n];

            int prev = 0;
            int curr = 0;
            for (int i = 0; i < n; i++)
            {
                memo[prev, i] = i;
            }

            for (int i = 1; i < m; i++)
            {
                prev = (i - 1) % 2;
                curr = i % 2;
                memo[curr, 0] = i;
                for (int j = 1; j < n; j++)
                {
                    if (word1[i - 1] == word2[j - 1])
                        memo[curr, j] = memo[prev, j - 1];
                    else
                        memo[curr, j] = 1 + Math.Min(memo[prev, j], Math.Min(memo[curr, j - 1], memo[prev, j - 1]));
                }
            }

            return memo[curr, n - 1];
        }

        public int MinDistanceDp1(string word1, string word2)
        {
            var m = word1.Length + 1;
            var n = word2.Length + 1;

            int[,] memo = new int[m, n];

            for (int i = 0; i < m; i++)
            {
                memo[i, 0] = i;
            }
            for (int i = 0; i < n; i++)
            {
                memo[0, i] = i;
            }


            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (word1[i - 1] == word2[j - 1])
                        memo[i, j] = memo[i - 1, j - 1];
                    else
                        memo[i, j] = 1 + Math.Min(memo[i - 1, j], Math.Min(memo[i, j - 1], memo[i - 1, j - 1]));
                }
            }

            return memo[m - 1, n - 1];
        }

        public int MinDistanceRecursive(string word1, string word2)
        {
            if (word1.Length == 0 && word2.Length == 0)
                return 0;

            if (word1.Length == 0)
                return word2.Length;

            if (word2.Length == 0)
                return word1.Length;

            if (word1[0] == word2[0])
                return MinDistanceRecursive(word1.Substring(1), word2.Substring(1));

            int insert = MinDistanceRecursive(word1, word2.Substring(1));
            int delete = MinDistanceRecursive(word1.Substring(1), word2);
            int replace = MinDistanceRecursive(word1.Substring(1), word2.Substring(1));

            return 1 + Math.Min(insert, Math.Min(delete, replace));
        }
    }
}