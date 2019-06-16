using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRank.Algorithms.Recursion
{
    [TestClass]
    public class StoneDivision
    {
        [TestMethod]
        public void StoneDivision_Solutions()
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

            var result = GetMoves(pileSize, set);

            Assert.AreEqual(282812460621, result);
        }
        
        public static long GetMoves(long pileSize, long[] set)
        {
            Dictionary<string, long> cache = new Dictionary<string, long>();
            long moves = Moves(pileSize, set, cache);
            return moves;
        }

        static long Moves(long pileSize, long[] set, Dictionary<string, long> cache)
        {
            List<long> results = new List<long>();
            foreach (long m in set)
            {
                if (m >= pileSize || pileSize % m != 0)
                    continue;

                string key = $"{pileSize},{m}";
                long moves;
                if (!cache.TryGetValue(key, out moves))
                {
                    long numPiles = pileSize / m;
                    long newPileSize = m;

                    moves = 1 + numPiles * Moves(newPileSize, set, cache);
                    cache.Add(key, moves);
                }

                results.Add(moves);
            }
            return results.Count == 0 ? 0 : results.Max();
        }
    }
}
