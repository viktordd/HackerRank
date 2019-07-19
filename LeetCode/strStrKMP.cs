using Helpers;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode
{
    [TestClass]
    public class StrStrKMP
    {
        #region Tests
        [DataTestMethod]
        [DataRow("hello", "", 0)]
        [DataRow("hello", "ll", 2)]
        [DataRow("hello", "llo", 2)]
        [DataRow("hell", "llo", -1)]
        [DataRow("AAAAABABABABABABABABABABAC", "ABABAC", 20)]
        public void StrStrKMP_Solutions(string text, string pattern, int expected)
        {
            var solution = new Solution();

            var result = solution.StrStrKMP(text, pattern);

            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow("ABABAC", new[] { 0, 0, 0, 1, 2, 3, 0 })]
        public void StrStrKMP_FailureFunction(string pattern, int[] expected)
        {
            var solution = new Solution();

            var result = solution.buildFailureFunction(pattern);

            AssertEnumerable.AreEqual(expected, result);
        }
        #endregion

        public class Solution
        {
            public int StrStrKMP(string text, string pattern)
            {
                var n = text.Length;
                var m = pattern.Length;

                if (m == 0)
                    return 0;

                var F = buildFailureFunction(pattern);

                int a = 0; // the initial state of the automaton is the empty string

                for (int i = 0; i < n;)
                {
                    if (text[i] == pattern[a])
                    {
                        a++; // change the state of the automaton
                        i++; // get the next character from the text
                        if (a == m) return i - m; // match found
                    }

                    // if the current state is not zero (we have not
                    // reached the empty string yet) we try to
                    // "expand" the next best (largest) match
                    else if (a > 0) a = F[a];

                    // if we reached the empty string and failed to
                    // "expand" even it; we go to the next
                    // character from the text, the state of the
                    // automaton remains zero
                    else i++;
                }

                return -1;
            }

            // Pay attention!
            // the prefix under index i in the table above is
            // is the string from pattern[0] to pattern[i - 1]
            // inclusive, so the last character of the string under
            // index i is pattern[i - 1]
            public int[] buildFailureFunction(string pattern)
            {
                int m = pattern.Length;
                int[] F = new int[m + 1];

                //F[0] = F[1] = 0; // always true
                for (int i = 2; i <= m; i++)
                {
                    // j is the index of the largest next partial match
                    // (the largest suffix/prefix) of the string under
                    // index i - 1
                    int j = F[i - 1];
                    while (true)
                    {
                        // check to see if the last character of string i -
                        // - pattern[i - 1] "expands" the current "candidate"
                        // best partial match - the prefix under index j
                        if (pattern[j] == pattern[i - 1])
                        {
                            F[i] = j + 1;
                            break;
                        }
                        // if we cannot "expand" even the empty string
                        if (j == 0)
                        {
                            F[i] = 0;
                            break;
                        }
                        // else go to the next best "candidate" partial match
                        j = F[j];
                    }
                }
                return F;
            }
        }
    }
}