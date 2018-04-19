using HackerRank.DataStructures.Arrays;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRankTest.DataStructures.Arrays
{
    [TestClass]
    public class ArrayManipulationTest
    {
        [TestMethod]
        public void ArrayManipulation_test()
        {
            int n = 5;

            int m = 3;

            long[][] queries = {
                new long[] {1, 2, 100},
                new long[] {2, 5, 100},
                new long[] {3, 4, 100}
            };

            var result = ArrayManipulationClass.ArrayManipulation(n, queries);

            Assert.AreEqual(200, result);
        }
    }
}
