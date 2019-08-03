using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode
{
    [TestClass]
    public class AddBinary
    {
        #region Tests
        [DataTestMethod]
        [DataRow("11", "1", "100")]
        [DataRow("11", "11", "110")]
        [DataRow("11", "111", "1010")]
        [DataRow("1010", "1011", "10101")]
        public void AddBinary_Solutions(string a, string b, string expected)
        {
            var solution = new Solution();

            var result = solution.AddBinary(a, b);

            Assert.AreEqual(expected, result);
        }
        #endregion

        public class Solution
        {
            public string AddBinary(string a, string b)
            {
                List<int> res = new List<int>();

                int reminder = 0;
                int i = a.Length - 1;
                int j = b.Length - 1;

                for (; i >= 0 && j >= 0; i--, j--)
                {
                    var ca = a[i] - '0';
                    var cb = b[j] - '0';

                    var r = ca + cb + reminder;

                    res.Add(r % 2);
                    reminder = r / 2;
                }

                if (j >= 0)
                {
                    i = j;
                    a = b;
                }

                for (; i >= 0; i--)
                {
                    var ca = a[i] - '0';

                    var r = ca + reminder;

                    res.Add(r % 2);
                    reminder = r / 2;
                }

                if (reminder > 0)
                    res.Add(reminder);

                res.Reverse();
                return string.Join("", res);
            }
        }
    }
}