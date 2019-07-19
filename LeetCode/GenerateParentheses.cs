using System.Collections.Generic;
using System.Linq;

using Helpers;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;

namespace LeetCode
{
    [TestClass]
    public class GenerateParentheses
    {
        #region Tests
        [DataTestMethod]
        [DataRow(3, "[ \"((()))\",\"(()())\",\"(())()\",\"()(())\",\"()()()\" ]")]
        public void GenerateParentheses_Solutions(int input, string expectedStr)
        {
            var expected = JsonConvert.DeserializeObject<List<string>>(expectedStr);
            var solution = new Solution();

            var result = solution.GenerateParenthesis(input);

            AssertEnumerable.AreEqual(expected, result);
        }
        #endregion


        public class Solution
        {
            public IList<string> GenerateParenthesis(int n)
            {
                return GenerateParenthesisR("(", n - 1, n)
                    .ToList();

            }

            public IEnumerable<string> GenerateParenthesisR(string curr, int l, int r)
            {
                if (l == 0 && r == 0)
                    yield return curr;

                if (l > 0)
                {
                    foreach (var parens in GenerateParenthesisR(curr + '(', l - 1, r)) yield return parens;
                }
                if (r > l)
                {
                    foreach (var parens in GenerateParenthesisR(curr + ')', l, r - 1)) yield return parens;
                }
            }
        }
    }
}