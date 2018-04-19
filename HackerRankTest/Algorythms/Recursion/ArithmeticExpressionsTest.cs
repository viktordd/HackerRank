﻿using HackerRank.Algorithms.Recursion;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRankTest.Algorythms.Recursion
{
    [TestClass]
    public class ArithmeticExpressionsTest
    {
        [TestMethod]
        public void ArithmeticExpressions_test()
        {
            long[] list =
            {
                59, 34, 36, 63, 79, 82, 20, 4, 81, 16, 30, 93, 50, 38, 78, 10, 22, 61, 91, 27, 18, 78, 96, 19, 38, 10,
                3, 17, 42, 90, 98, 60, 1, 63, 16, 28, 97, 45, 19, 35, 44, 56, 77, 43, 24, 42, 28, 35, 95, 44, 61, 55,
                32, 84
            };

            var result = ArithmeticExpressions.GetExpression(list);

            Assert.AreEqual("59+34+36+63+79+82+20+4+81+16+30+93+50+38+78+10+22+61+91+27+18+78+96+19+38+10+3+17+42+90+98+60+1+63+16+28+97+45+19+35+44+56+77+43+24+42+28+35+95+44-61*55-32*84", result);
        }
    }
}
