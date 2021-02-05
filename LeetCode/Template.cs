using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode
{
    [TestClass]
    public class Template
    {
        #region Tests

        [DataTestMethod]
        [DataRow(true)]
        public void RegularExpressionMatching_Solutions(bool expected)
        {
            var solution = new Solution();

            var result = solution.Method();

            Assert.AreEqual(expected, result);
        }

        #endregion

        public class Solution
        {
            public bool Method()
            {
                return true;
            }
        }
    }
}
