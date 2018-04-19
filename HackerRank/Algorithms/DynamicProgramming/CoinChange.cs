using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank.Algorithms.DynamicProgramming
{
    public class CoinChange
    {
        private static readonly Dictionary<string, Int64> Solutions = new Dictionary<string, Int64>();

        public static void Solve(String[] args)
        {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */

            var split1 = Console.ReadLine()?.Split(' ');

            int change = Convert.ToInt32(split1?[0]);
            int count = Convert.ToInt32(split1?[1]);
            var coins = Console.ReadLine()?.Split(' ').Select(i => Convert.ToInt32(i)).OrderByDescending(i => i).ToArray();

            var solutions = GetSolutions(change, coins);

            Console.WriteLine(solutions);
        }

        public static long GetSolutions(int change, int[] coins)
        {
            Int64 solutions = 0;

            if (change == 0 || coins.Length == 0)
                return solutions;

            for (int i = 0; i < coins.Length; i++)
            {
                solutions += GetChange(change, coins, i);
            }

            return solutions;
        }

        private static Int64 GetChange(int change, int[] coins, int coin)
        {
            string key = change + ": " + string.Join(" ", coins.Skip(coin));
            if (Solutions.ContainsKey(key))
                return Solutions[key];

            change -= coins[coin];

            if (change < 0)
                return 0;

            else if (change == 0)
                return 1;

            Int64 solutions = 0;
            for (int i = coin; i < coins.Length; i++)
            {
                solutions += GetChange(change, coins, i);
            }
            Solutions.Add(key, solutions);

            return solutions;
        }
    }
}
