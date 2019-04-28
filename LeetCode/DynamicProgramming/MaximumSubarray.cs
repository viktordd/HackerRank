using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.DynamicProgramming
{
    [TestClass]
    public class MaximumSubarray
    {
        #region Tests

        [TestMethod]
        public void MaximumSubarray_Solutions()
        {
            Assert.AreEqual(6, MaxSubArray(new[] {-2, 1, -3, 4, -1, 2, 1, -5, 4}));
            Assert.AreEqual(-1, MaxSubArray(new[] {-2, -1}));
            Assert.AreEqual(3, MaxSubArray(new[] {-2, -3, 1, 2, -5}));
            Assert.AreEqual(1, MaxSubArray(new[] {1}));
            Assert.AreEqual(3, MaxSubArray(new[] {1, 2}));
            Assert.AreEqual(4, MaxSubArray(new[] {-1, 1, 2, 1}));
            Assert.AreEqual(1, MaxSubArray(new[] {1, -1, -2}));
        }

        #endregion

        public int MaxSubArray(int[] nums)
        {
            int maxSum;

            var sum = maxSum = nums[0];

            for (int i = 1; i < nums.Length; ++i)
            {
                sum = Math.Max(nums[i], nums[i] + sum);
                maxSum = Math.Max(sum, maxSum);
            }

            return maxSum;
            

            //int max = int.MinValue;
            //int sum = 0;

            //for (int i = 0; i < nums.Length; i++)
            //{
            //    sum += nums[i];
            //    if (sum > max) max = sum;
            //    if (sum < 0) sum = 0;
            //}

            //return max;

            //if (nums.Length == 0)
            //    return 0;

            //int maxNum = nums[0];

            //var sums = new int[nums.Length];
            //sums[0] = nums[0];

            //int maxSum = nums[0];
            //int minSum = nums[0] < 0 ? nums[0] : 0;

            //for (int i = 1; i < sums.Length; i++)
            //{
            //    sums[i] = nums[i] + sums[i - 1];

            //    if (nums[i] > maxNum)
            //        maxNum = nums[i];

            //    if (sums[i] < minSum)
            //        minSum = sums[i];
            //    else
            //    {
            //        var newSum = sums[i] - minSum;
            //        if (newSum > maxSum)
            //            maxSum = newSum;
            //    }
            //}

            //return Math.Max(maxSum, maxNum);
        }
    }
}
