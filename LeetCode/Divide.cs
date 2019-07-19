using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode
{
    [TestClass]
    public class Divide
    {
        #region Tests
        [DataTestMethod]
        [DataRow(10, 3, 10 / 3)]
        [DataRow(7, -3, 7 / -3)]
        [DataRow(int.MinValue, -1, int.MaxValue)]
        [DataRow(int.MinValue, -2, int.MinValue / -2)]
        [DataRow(int.MinValue, -3, int.MinValue / -3)]
        [DataRow(int.MinValue, 1, int.MinValue)]
        public void Divide_Solutions(int dividend, int divisor, int expected)
        {
            var solution = new Solution();

            var result = solution.Divide(dividend, divisor);

            Assert.AreEqual(expected, result);
        }
        #endregion

        public class Solution
        {
            public int Divide(int dividend, int divisor)
            {
                if (divisor == 1) return dividend;
                if (divisor == -1)
                {
                    if (dividend == int.MinValue)
                        return int.MaxValue;
                    return -dividend;
                }

                uint a = ToUint(dividend);
                uint b = ToUint(divisor);
                int res = 0;

                while (a >= b)
                {
                    int x = 0;

                    while (a > (b << x + 1)) x++;
                    if (a == (b << x + 1)) x++;

                    res += 1 << x;
                    a -= b << x;
                }

                return (dividend > 0) == (divisor > 0) ? res : -res;
            }

            public uint ToUint(int val) =>
                val < 0
                ? (val == int.MinValue
                    ? (uint)int.MaxValue + 1
                    : (uint)-val)
                : (uint)val;
        }
    }
}