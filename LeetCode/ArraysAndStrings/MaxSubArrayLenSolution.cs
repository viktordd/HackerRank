using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.ArraysAndStrings
{
    [TestClass]
    public class MaxSubArrayLenSolution
    {
        [TestMethod]
        public void MaxSubArrayLen_Solutions()
        {
            Assert.AreEqual(4, MaxSubArrayLen(new[] { 1, -1, 5, -2, 3 }, 3));
            Assert.AreEqual(2, MaxSubArrayLen(new[] { -2, -1, 2, 1 }, 1));
            Assert.AreEqual(1, MaxSubArrayLen(new[] { -1, 1 }, 1));
        }

        public int MaxSubArrayLen(int[] nums, int k)
        {
            var sums = new Dictionary<int, int>();
            int sum = 0;
            int max = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                sum += nums[i];

                if (sum == k)
                    max = i + 1;

                else if (sums.ContainsKey(sum - k))
                    max = Math.Max(max, i - sums[sum - k]);

                if (!sums.ContainsKey(sum))
                    sums.Add(sum, i);
            }
            return max;
        }

        public int MaxSubArrayLen1(int[] nums, int k)
        {
            int sum = nums.Sum();

            if (sum == k)
                return nums.Length;

            int start = 0;
            int end = nums.Length - 1;
            int direction = -1;

            while (start <= end)
            {
                if (direction == 1)
                {
                    while (end < nums.Length - 1)
                    {
                        sum -= nums[start++];
                        sum += nums[++end];

                        if (sum == k)
                            return end - start + 1;
                    }
                    sum -= nums[start++];
                    if (sum == k)
                        return end - start + 1;
                }
                else
                {
                    while (start > 0)
                    {
                        sum += nums[--start];
                        sum -= nums[end--];

                        if (sum == k)
                            return end - start + 1;
                    }
                    sum -= nums[end--];
                    if (sum == k)
                        return end - start + 1;
                }

                direction *= -1;
            }
            return 0;
        }
    }
}
