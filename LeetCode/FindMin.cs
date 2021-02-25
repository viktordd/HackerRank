using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode
{
    [TestClass]
    public class FindMinTest
    {
        [DataTestMethod]
        [DataRow(new[] { 3, 4, 5, 1, 2 }, 1)]
        [DataRow(new[] { 4, 5, 1, 2, 3 }, 1)]
        [DataRow(new[] { 5, 1, 2, 3, 4 }, 1)]
        [DataRow(new[] { 4, 5, 6, 7, 0, 1, 2 }, 0)]
        [DataRow(new[] { 11, 13, 15, 17 }, 11)]
        public void Test(int[] nums, int expected)
        {
            var solution = new FindMinClass();
            var result = solution.FindMin(nums);
            Assert.AreEqual(expected, result);
        }
    }

    public class FindMinClass
    {
        public int FindMin(int[] nums)
        {
            int start = 0;
            int end = nums.Length - 1;

            while (start <= end)
            {
                int m = start + (end - start) / 2;

                if (nums[m] < nums[end])
                {
                    end = m;
                }
                else
                {
                    start = m + 1;
                }
            }

            return nums[end];
        }
    }
}