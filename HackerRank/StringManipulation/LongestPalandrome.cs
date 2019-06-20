using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRank.StringManipulation
{
    [TestClass]
    public class LongestPalandromeTests
    {
        [DataTestMethod]
        [DataRow("ABCDCBA", "ABCDCBA")]
        [DataRow("QQQABCDCBAWW", "ABCDCBA")]
        [DataRow("ABCDDCBA", "ABCDDCBA")]
        [DataRow("QQQABCDDCBAWW", "ABCDDCBA")]
        public void LongestPalandromeTest(string input, string expected)
        {
            var s = new LongestPalandrome();
            var result = s.FindLongestPalindrome(input);

            Assert.AreEqual(expected, result);
        }
    }

    public class LongestPalandrome
    {
        public string FindLongestPalindrome(string input)
        {
            var longest = (start: 0, end: 0);

            for (int i = 0; i < input.Length; i++)
            {
                longest = Max(longest, GetPalindromeAt(i, input));
            }

            return input.Substring(longest.start, longest.end - longest.start + 1);
        }

        public (int start, int end) GetPalindromeAt(int position, string input)
        {
            var longest = (start: position, end: position);

            foreach (var lowerStart in new[] { position - 1, position })
            {
                var lower = lowerStart;
                var upper = position + 1;
                while (lower >= 0 &&
                          upper < input.Length &&
                          input[lower] == input[upper])
                {
                    upper++;
                    lower--;
                }
                longest = Max(longest, (lower + 1, upper - 1));
            }
            return longest;
        }

        public (int, int) Max((int start, int end) a, (int start, int end) b)
        {
            return a.end - a.start > b.end - b.start ? a : b;
        }

        //        def findLongestPalindrome(string):
        //    return max([getPalindromeAt(i, string) for i in xrange(len(string))],
        //               key = lambda a: len(a)) if len(string) > 0 else ''

        //def getPalindromeAt(position, string):
        //    longest = (position, position)
        //    for lower, upper in [(position - 1, position + 1),
        //                         (position, position + 1)]:
        //        while lower >= 0 and
        //              upper<len(string) and
        //              string[lower] == string[upper]:
        //            upper += 1
        //            lower -= 1
        //        longest = max(longest, (lower + 1, upper - 1),
        //                      key = lambda a: a[1] - a[0])
        //    return string[longest[0] : longest[1] + 1]
    }
}
