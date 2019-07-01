using System;
using System.Collections.Generic;
using System.Linq;
using Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;

namespace LeetCode
{
    [TestClass]
    public class ThreeSumClosestSolution
    {
        #region Tests
        [DataTestMethod]
        [DataRow(new[] { -1, 2, 1, -4 }, 1, 2)]
        public void ThreeSumClosest_Solutions(int[] input, int target, int expected)
        {
            var solution = new Solution();

            var result = solution.ThreeSumClosest(input, target);

            Assert.AreEqual(expected, result);
        }
        #endregion 

        public class Solution
        {
            public int ThreeSumClosest(int[] nums, int target)
            {
                if (nums.Length < 3)
                    return 0;

                Array.Sort(nums);
                int closest = nums[0] + nums[1] + nums[2];

                for (int i = 0; i < nums.Length - 2; i++)
                {
                    if (i > 0 && nums[i] == nums[i - 1])
                        continue;
                    int left = i + 1;
                    int right = nums.Length - 1;

                    while (left < right)
                    {
                        int sum = nums[i] + nums[left] + nums[right];
                        int dist = Math.Abs(sum - target);

                        if (dist < Math.Abs(closest - target))
                        {
                            closest = sum;
                        }

                        if (sum == target)
                        {
                            return sum;
                        }
                        if (sum < target)
                        {
                            while (left < right && nums[left] == nums[++left]) ;
                        }
                        else
                        {
                            while (left < right && nums[right] == nums[--right]) ;
                        }
                    }
                }

                return closest;
            }
        }
    }
}
