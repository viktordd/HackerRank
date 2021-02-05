using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode
{
    [TestClass]
    public class RegularExpressionMatching
    {
        #region Tests

        [DataTestMethod]
        [DataRow("", "", true)]
        [DataRow("aa", "a", false)] //Explanation: "a" does not match the entire string "aa".
        [DataRow("aa", "a*", true)] //Explanation: '*' means zero or more of the preceding element, 'a'. Therefore, by repeating 'a' once, it becomes "aa".
        [DataRow("ab", ".*", true)] //Explanation: ".*" means "zero or more (*) of any character (.)".
        [DataRow("aab", "c*a*b", true)] //Explanation: c can be repeated 0 times, a can be repeated 1 time.Therefore, it matches "aab".
        [DataRow("mississippi", "mis*is*p*.", false)]
        [DataRow("aaa", "aaaa", false)]
        [DataRow("aaa", "a*a", true)]
        public void RegularExpressionMatching_Solutions(string s, string p, bool expected)
        {
            var solution = new Solution();

            var result = solution.IsMatch(s, p);

            Assert.AreEqual(expected, result);
        }

        //Dynamic Programming solution
        //Less space efficient uses stack for recursive calls, but does not go through all possible T*P variations
        class Solution
        {
            bool?[, ] memo;

            public bool IsMatch(string text, string pattern)
            {
                memo = new bool?[text.Length + 1, pattern.Length + 1];
                return dp(0, 0, text, pattern);
            }

            public bool dp(int i, int j, string text, string pattern)
            {
                if (memo[i, j] != null)
                {
                    return memo[i, j].Value;
                }
                bool ans;
                if (j == pattern.Length)
                {
                    ans = i == text.Length;
                }
                else
                {
                    bool first_match = i < text.Length &&
                                           (pattern[j] == text[i] ||
                                            pattern[j] == '.');

                    if (j + 1 < pattern.Length && pattern[j + 1] == '*')
                    {
                        ans = dp(i, j + 2, text, pattern) ||
                              first_match && dp(i + 1, j, text, pattern);
                    }
                    else
                    {
                        ans = first_match && dp(i + 1, j + 1, text, pattern);
                    }
                }
                memo[i, j] = ans;
                return ans;
            }
        }

        //Bottom up Dynamic Programming solution
        //Less time efficient itterates through all possible T*P variations
        class Solution2
        {
            public bool IsMatch(string text, string pattern)
            {
                bool?[,] dp = new bool?[text.Length + 1, pattern.Length + 1];
                dp[text.Length, pattern.Length] = true;

                for (int i = text.Length; i >= 0; i--)
                {
                    for (int j = pattern.Length - 1; j >= 0; j--)
                    {
                        bool firstMatch = i < text.Length && (pattern[j] == text[i] || pattern[j] == '.');
                        if (j + 1 < pattern.Length && pattern[j + 1] == '*')
                        {
                            dp[i, j] = dp[i, j + 2].GetValueOrDefault() || firstMatch && dp[i + 1, j].GetValueOrDefault();
                        }
                        else
                        {
                            dp[i, j] = firstMatch && dp[i + 1, j + 1].GetValueOrDefault();
                        }
                    }
                }
                return dp[0, 0].GetValueOrDefault();
            }
        }

        #endregion

        //public class Solution
        //{
        //    public bool IsMatch(string s, string p)
        //    {
        //        if (s.Length == 0 && s.Length == p.Length)
        //            return true;

        //        List<Pattern> pattern = ParsePattern(p);

        //        int iS = 0;
        //        int iP = 0;
        //        for (; iS < s.Length && iP < pattern.Count; iS++)
        //        {
        //            var patt = pattern[iP];
        //            if (patt.IsMatch(s[iS]))
        //            {
        //                if (patt.MatchStart < 0)
        //                    patt.MatchStart = iS;
        //                if (!patt.IsAnyLength)
        //                    iP++;
        //            }
        //            else
        //            {
        //                if (patt.IsAnyLength)
        //                {
        //                    iP++;
        //                    iS--;
        //                }
        //                else
        //                {
        //                    //check if backtrack needed.
        //                    return false;
        //                }
        //            }
        //        }

        //        while (iP < pattern.Count && pattern[iP].IsAnyLength)
        //            iP++;

        //        return iS == s.Length && iP == pattern.Count;
        //    }

        //    private List<Pattern> ParsePattern(string p)
        //    {
        //        var pattern = new List<Pattern>();

        //        for (int i = 0; i < p.Length; i++)
        //        {
        //            if (p[i] == '*')
        //                pattern[pattern.Count - 1].IsAnyLength = true;
        //            else
        //                pattern.Add(new Pattern { Char = p[i] });
        //        }

        //        return pattern;
        //    }
        //    public class Pattern
        //    {
        //        public char Char { get; set; }
        //        public bool IsAnyChar => Char == '.';
        //        public bool IsAnyLength { get; set; }
        //        public int MatchStart { get; set; } = -1;

        //        public bool IsMatch(char c) => Char == c || IsAnyChar;
        //    }
        //}
    }
}
