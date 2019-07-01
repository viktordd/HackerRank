using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode
{
    [TestClass]
    public class IntegerToRoman
    {
        #region Tests
        [DataTestMethod]
        [DataRow(3, "III")]
        [DataRow(4, "IV")]
        [DataRow(6, "VI")]
        [DataRow(9, "IX")]
        [DataRow(3999, "MMMCMXCIX")]
        public void IntegerToRoman_Solutions(int input, string expected)
        {
            var solution = new Solution2();
            var result = solution.IntToRoman(input);
            Assert.AreEqual(expected, result);
        }

        #endregion

        public class Solution2
        {
            public string IntToRoman(int num)
            {
                char[,] roman = new[,] {
                    { 'I', 'V' }, // 1, 5
                    { 'X', 'L' }, // 10, 50
                    { 'C', 'D' }, // 100, 500
                    { 'M', '\0' } // 1000
                };

                Stack<char> s = new Stack<char>();

                int i = 0;
                while (num > 0)
                {
                    int digit = num % 10;

                    if (digit < 4)
                    {
                        for (int j = 0; j < digit; j++) s.Push(roman[i, 0]);
                    }
                    else if (digit == 4)
                    {
                        s.Push(roman[i, 1]);
                        s.Push(roman[i, 0]);
                    }
                    else if (digit < 9)
                    {
                        for (int j = 0; j < digit - 5; j++) s.Push(roman[i, 0]);
                        s.Push(roman[i, 1]);
                    }
                    else if (digit == 9)
                    {
                        s.Push(roman[i + 1, 0]);
                        s.Push(roman[i, 0]);
                    }

                    num /= 10;
                    i++;
                }

                return string.Join(string.Empty, s);
            }
        }

        public class Solution
        {
            public string IntToRoman(int num)
            {
                string[] ones = new[] { string.Empty, "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };
                string[] tens = new[] { string.Empty, "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
                string[] hundreds = new[] { string.Empty, "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
                string[] thousands = new[] { string.Empty, "M", "MM", "MMM" };

                return thousands[num / 1000 % 10] + hundreds[num / 100 % 10] + tens[num / 10 % 10] + ones[num % 10];
            }
        }
    }
}
