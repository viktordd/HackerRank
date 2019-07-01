using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode
{
    [TestClass]
    public class RomanToInteger
    {
        #region Tests
        [DataTestMethod]
        [DataRow("III", 3)]
        [DataRow("IV", 4)]
        [DataRow("VI", 6)]
        [DataRow("IX", 9)]
        [DataRow("MMMCMXCIX", 3999)]
        [DataRow("MMMCDXLIV", 3444)]
        public void IntegerToRoman_Solutions(string input, int expected)
        {
            var solution = new Solution2();
            var result = solution.RomanToInt(input);
            Assert.AreEqual(expected, result);
        }

        #endregion

        public class Solution2
        {
            public int RomanToInt(string s)
            {
                int result = 0;

                Dictionary<char, int> map = new Dictionary<char, int>
                {
                    { 'I', 1 }, { 'V', 5 },
                    { 'X', 10 }, { 'L', 50 },
                    { 'C', 100 }, { 'D', 500 },
                    { 'M', 1000 },
                };

                int prev = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    var curr = map[s[i]];

                    if (curr > prev)
                        result += curr - prev * 2;
                    else
                        result += curr;

                    prev = curr;
                }

                return result;
            }
        }

        public class Solution
        {
            public int RomanToInt(string s)
            {
                int result = 0;

                Dictionary<char, (int val, char remove)> map = new Dictionary<char, (int, char)>
                {
                    { 'M', (1000, 'C') },
                    { 'D', (500, 'C') },
                    { 'C', (100, 'X') },
                    { 'L', (50, 'X') },
                    { 'X', (10, 'I') },
                    { 'V', (5, 'I') },
                    { 'I', (1, '0') },
                };

                for (int i = 0; i < s.Length; i++)
                {
                    var curr = map[s[i]];

                    if (i > 0 && curr.remove == s[i - 1])
                        result += curr.val - map[curr.remove].val * 2;
                    else
                        result += curr.val;
                }

                return result;
            }
        }
    }
}
