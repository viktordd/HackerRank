using HackerRank;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRankTest
{
    [TestClass]
    public class CoinChangeTest
    {
        [TestMethod]
        public void CoinChange_Solutions()
        {
            int change = 250;
            int[] coins =
            {
                8, 47, 13, 24, 25, 31, 32, 35, 3, 19, 40, 48, 1, 4, 17, 38, 22, 30, 33, 15, 44, 46, 36, 9, 20, 49
            };

            var result = CoinChange.GetSolutions(change, coins);

            Assert.AreEqual(3542323427, result);
        }
    }
}
