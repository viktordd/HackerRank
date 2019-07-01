using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode
{
    [TestClass]
    public class ContainerWithMostWater
    {
        #region Tests
        [DataTestMethod]
        [DataRow(new[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }, 49)]
        public void ContainerWithMostWater_Solutions(int[] input, int expected)
        {
            var solution = new Solution();
            var result = solution.MaxArea(input);
            Assert.AreEqual(expected, result);
        }

        #endregion

        public class Solution
        {
            public int MaxArea(int[] height)
            {
                int maxArea = 0, l = 0, r = height.Length - 1;

                while (l < r)
                {
                    maxArea = Math.Max(maxArea, Area(l, r, height));

                    if (height[l] < height[r])
                        l++;
                    else
                        r--;
                }


                return maxArea;
            }

            public int Area(int l, int r, int[] height)
            {
                int h = Math.Min(height[l], height[r]);

                return (r - l) * h;
            }
        }
    }
}
