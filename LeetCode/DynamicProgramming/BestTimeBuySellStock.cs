using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.DynamicProgramming
{
    [TestClass]
    public class BestTimeBuySellStock
    {
        #region Tests

        [TestMethod]
        public void BestTimeBuySellStock_Solutions()
        {
            Assert.AreEqual(5, MaxProfit(new[] {7, 1, 5, 3, 6, 4}));
            Assert.AreEqual(0, MaxProfit(new[] {7, 6, 4, 3, 1}));
            Assert.AreEqual(2, MaxProfit(new[] {7, 2, 4, 1}));
            Assert.AreEqual(4, MaxProfit(new[] {3, 3, 5, 0, 0, 3, 1, 4}));
        }

        #endregion

        public int MaxProfit(int[] prices)
        {
            int minPrice = int.MinValue;
            int maxProfit = 0;

            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < minPrice)
                    minPrice = prices[i];
                else
                {
                    var profit = prices[i] - minPrice;
                    if (profit > maxProfit)
                        maxProfit = profit;
                }
            }

            return maxProfit;
        }

        public int MaxProfit2(int[] prices)
        {
            int start = 0, end = prices.Length - 1;
            while (start + 1 <= end && prices[start] > prices[start + 1]) start++;
            while (start <= end - 1 && prices[end - 1] > prices[end]) end--;

            if (start >= end)
                return 0;

            int min = start, max = start;

            for (int i = start + 1; i <= end; i++)
            {
                if (prices[i] < prices[min])
                    min = i;
                else if (prices[i] >= prices[max])
                {
                    max = i;
                }
            }
            if (min <= max)
                return prices[max] - prices[min];

            var localMax = min;
            for (int i = min + 1; i <= end; i++)
            {
                if (prices[i] > prices[localMax])
                    localMax = i;
            }

            var localMin = max;
            for (int i = start; i < max; i++)
            {
                if (prices[i] < prices[localMin])
                    localMin = i;
            }

            return Math.Max(prices[localMax] - prices[min], prices[max] - prices[localMin]);
        }
    }
}
