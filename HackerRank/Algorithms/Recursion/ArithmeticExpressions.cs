using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRank.Algorithms.Recursion
{
    [TestClass]
    public class ArithmeticExpressions
    {
        [TestMethod]
        public void ArithmeticExpressions_Solutions()
        {
            long[] list =
            {
                59, 34, 36, 63, 79, 82, 20, 4, 81, 16, 30, 93, 50, 38, 78, 10, 22, 61, 91, 27, 18, 78, 96, 19, 38, 10,
                3, 17, 42, 90, 98, 60, 1, 63, 16, 28, 97, 45, 19, 35, 44, 56, 77, 43, 24, 42, 28, 35, 95, 44, 61, 55,
                32, 84
            };

            var result = GetExpression(list);

            Assert.AreEqual("59+34+36+63+79+82+20+4+81+16+30+93+50+38+78+10+22+61+91+27+18+78+96+19+38+10+3+17+42+90+98+60+1+63+16+28+97+45+19+35+44+56+77+43+24+42+28+35+95+44-61*55-32*84", result);
        }

        public static string GetExpression(long[] list)
        {
            return list[0] + Check(list, 1, list[0]);
        }

        static string Check(long[] list, int index, long current)
        {
            current %= 101;

            if (index == list.Length)
                return current == 0 ? "" : null;

            if (current == 0)
                return "*" + string.Join("*", list.Skip(index));

            var result = Check(list, index + 1, current + list[index]);
            if (result != null)
                return "+" + list[index] + result;

            result = Check(list, index + 1, current * list[index]);
            if (result != null)
                return "*" + list[index] + result;

            result = Check(list, index + 1, current - list[index]);
            if (result != null)
                return "-" + list[index] + result;

            return null;
        }
    }
}
