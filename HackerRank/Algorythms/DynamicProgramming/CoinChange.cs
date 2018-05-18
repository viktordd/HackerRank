using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRankTest.Algorythms.DynamicProgramming
{
    [TestClass]
    public class CoinChange
    {
        [TestMethod]
        public void CoinChange_Solutions()
        {
            int change = 250;
            int[] coins =
            {
                8, 47, 13, 24, 25, 31, 32, 35, 3, 19, 40, 48, 1, 4, 17, 38, 22, 30, 33, 15, 44, 46, 36, 9, 20, 49
            };

            var result = GetSolutions(change, coins);

            Assert.AreEqual(3542323427, result);
        }
        
        private static readonly Dictionary<string, Int64> Solutions = new Dictionary<string, Int64>();
        

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
