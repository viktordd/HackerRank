using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode
{
    [TestClass]
    public class Multiply
    {
        #region Tests
        [DataTestMethod]
        [DataRow("2", "3", "6")]
        [DataRow("123", "456", "56088")]
        [DataRow("11", "12", "132")]
        [DataRow("55", "23", "1265")]
        [DataRow("0", "23", "0")]
        [DataRow("40", "20", "800")]
        public void Multiply_Solutions(string num1, string num2, string expected)
        {
            var solution = new Solution();

            var result = solution.Multiply(num1, num2);

            Assert.AreEqual(expected, result);
        }
        #endregion
        public class Solution
        {
            public string Multiply(string num1, string num2)
            {
                List<byte> r = new List<byte>();
                Add(r, 0, 0);

                for (int i = num2.Length - 1; i >= 0; i--)
                {
                    int m = num2[i] - '0';
                    if (m > 0)
                        for (int j = num1.Length - 1; j >= 0; j--)
                        {
                            int n = num1[j] - '0';
                            if (n > 0)
                                Add(r, m * n, (num2.Length - 1 - i) + (num1.Length - 1 - j));
                        }
                }

                return string.Join("", r.Reverse<byte>());
            }

            private void Add(List<byte> r, int val, int i)
            {
                while (i >= r.Count) r.Add(0);

                var res = r[i] + val;

                r[i] = (byte)(res % 10);

                if (res > 9)
                    Add(r, res / 10, i + 1);
            }
        }
    }
}