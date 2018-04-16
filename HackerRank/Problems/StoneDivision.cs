using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank
{
    public class StoneDivision
    {
        public static void Solve(String[] args)
        {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
            int count = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] split2 = Console.ReadLine()?.Split(' ');

                long pileSize = Convert.ToInt64(split2?[0]);
                //long setCount = Convert.ToInt64(split2[1]);
                long[] set = Console.ReadLine()?.Split(' ').Select(m => Convert.ToInt64(m)).OrderByDescending(m => m).ToArray();

                var moves = GetMoves(pileSize, set);

                Console.WriteLine(moves);
            }
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
