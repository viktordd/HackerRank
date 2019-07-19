using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode
{
    [TestClass]
    public class StrStr
    {
        #region Tests
        [DataTestMethod]
        [DataRow("hell", "llo", -1)]
        public void StrStr_Solutions(string haystack, string needle, int expected)
        {
            var solution = new Solution();

            var result = solution.StrStr(haystack, needle);

            Assert.AreEqual(expected, result);
        }
        #endregion

        public class Solution
        {
            public int StrStr(string haystack, string needle)
            {
                if (needle.Length == 0)
                    return 0;

                int checkLenght = haystack.Length - needle.Length + 1;
                for (int i = 0; i < checkLenght; i++)
                {
                    int t = i;
                    for (int j = 0; j < needle.Length; j++, t++)
                    {
                        if (haystack[t] != needle[j])
                            break;
                    }

                    if (t == i + needle.Length)
                        return i;
                }

                return -1;
            }
        }
    }
}