using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.TreesAndGraphs
{
    [TestClass]
    public class LetterCombinationsPhoneNumber
    {
        [TestMethod]
        public void LetterCombinationsPhoneNumber_Solutions()
        {
            AssertEnumerable.AreEqual(new[] {"ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"}, LetterCombinations("23"));
        }

        private static string[] Letters = {
            /* 2 */ "abc",
            /* 3 */ "def",
            /* 4 */ "ghi",
            /* 5 */ "jkl",
            /* 6 */ "mno",
            /* 7 */ "pqrs",
            /* 8 */ "tuv",
            /* 9 */ "wxyz",
        };

        public IList<string> LetterCombinations(string digits)
        {
            var output = new List<string>();
            if (digits.Length == 0)
                return output;

            var digitsArray = digits.Select(c => c - '2').ToArray();
            var sb = new StringBuilder();

            LetterCombinations(digitsArray, output, sb, 0);

            return output;
        }


        public void LetterCombinations(int[] digits, List<string> output, StringBuilder sb, int curr)
        {
            var currLetters = Letters[digits[curr]];
            for (int i = 0; i < currLetters.Length; i++)
            {
                sb.Append(currLetters[i]);

                if (curr + 1 < digits.Length)
                    LetterCombinations(digits, output, sb, curr + 1);
                else
                    output.Add(sb.ToString());

                sb.Remove(sb.Length - 1, 1);
            }
        }
    }
}
