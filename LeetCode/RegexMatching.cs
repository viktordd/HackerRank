using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode
{
    [TestClass]
    public class RegexMatchingTest
    {
        [DataTestMethod]
        [DataRow("", "", true)]
        [DataRow("aa", "a", false)] //Explanation: "a" does not match the entire string "aa".
        [DataRow("aa", "a*", true)] //Explanation: '*' means zero or more of the preceding element, 'a'. Therefore, by repeating 'a' once, it becomes "aa".
        [DataRow("ab", ".*", true)] //Explanation: ".*" means "zero or more (*) of any character (.)".
        [DataRow("aab", "c*a*b", true)] //Explanation: c can be repeated 0 times, a can be repeated 1 time.Therefore, it matches "aab".
        [DataRow("mississippi", "mis*is*p*.", false)]
        [DataRow("aaa", "aaaa", false)]
        [DataRow("aaa", "a*a", true)]
        public void Test(string s, string p, bool expected)
        {
            var solution = new RegexMatchingClass();
            var result = solution.IsMatch(s, p);
            Assert.AreEqual(expected, result, $"{s}, {p}");
        }
    }

    /*
    Check if memo is filled,
    Check if pattern index is at the end == to pattern length, if t is also at text length than return true;
        Check if curr char matches or is '.'
            check if next char in pattern is '*'
                if it is then call back with 0 length match (p + 2)
                if not and curr char matches call back with (t + 1)
        if curr matches and next not a start call continue (t+1, p+1)

    */
    public class RegexMatchingClass
    {
        private bool?[,] memo;

        public bool IsMatch(string text, string pattern)
        {
            memo = new bool?[text.Length + 1, pattern.Length + 1];
            return helper(0, 0, text, pattern);
        }

        private bool helper(int t, int p, string text, string pattern)
        {
            if (memo[t, p] != null)
            {
                return memo[t, p].Value;
            }

            bool ans = false;
            if (p == pattern.Length)
            {
                ans = t == text.Length;
                memo[t, p] = ans;
                return ans;
            }

            bool currMatch = t < text.Length && (text[t] == pattern[p] || pattern[p] == '.');
            bool nextIsStar = p + 1 < pattern.Length && pattern[p + 1] == '*';

            if (nextIsStar)
            {
                ans = helper(t, p + 2, text, pattern) ||
                        currMatch && helper(t + 1, p, text, pattern);
            }
            else
            {
                ans = currMatch && helper(t + 1, p + 1, text, pattern);
            }


            memo[t, p] = ans;
            return ans;
        }
    }
}