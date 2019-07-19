using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode
{
    [TestClass]
    public class CountAndSay
    {
        #region Tests
        [DataTestMethod]
        [DataRow(1, "1")]
        [DataRow(2, "11")]
        [DataRow(3, "21")]
        [DataRow(4, "1211")]
        [DataRow(5, "111221")]
        public void CountAndSay_Solutions(int n, string expected)
        {
            var solution = new Solution();

            var result = solution.CountAndSay(n);

            Assert.AreEqual(expected, result);
        }
        #endregion
        public class Solution
        {
            public string CountAndSay(int n)
            {
                n--;
                string result = "1";
                for (int i = 0; i < n; i++)
                {
                    StringBuilder sb = new StringBuilder();
                    char prev = '.';
                    int count = 0;

                    for (int j = 0; j < result.Length; j++)
                    {
                        char c = result[j];
                        if (c == prev)
                            count++;
                        else
                        {
                            if (count > 0)
                                sb.Append(count)
                                    .Append(prev);
                            prev = c;
                            count = 1;
                        }
                    }

                    if (count > 0)
                        sb.Append(count)
                            .Append(prev);

                    result = sb.ToString();
                }

                return result;
            }
        }
    }
}