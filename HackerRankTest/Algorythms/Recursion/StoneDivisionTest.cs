using HackerRank.Algorithms.Recursion;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRankTest.Algorythms.Recursion
{
    [TestClass]
    public class StoneDivisionTest
    {
        [TestMethod]
        public void StoneDivision_Moves_test()
        {
            long pileSize = 377083280820;
            long[] set =
            {
                1, 377083280820,
                2, 188541640410,
                3, 125694426940,
                4, 94270820205,
                5, 75416656164
            };

            var result = StoneDivision.GetMoves(pileSize, set);

            Assert.AreEqual(282812460621, result);
        }
    }
}
