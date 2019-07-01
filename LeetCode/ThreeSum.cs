using System;
using System.Collections.Generic;
using System.Linq;
using Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;

namespace LeetCode
{
    [TestClass]
    public class ThreeSumSolution
    {
        #region Tests
        [DataTestMethod]
        [DataRow(new[] { -1, 0, 1, 2, -1, -4 }, "[ [-1, -1, 2], [-1, 0, 1] ]")]
        public void ThreeSum_Solutions(int[] input, string expecedJson)
        {
            var expected = JsonConvert.DeserializeObject<int[][]>(expecedJson);
            var solution = new Solution();

            var result = solution.ThreeSum(input);

            AssertEnumerable.AreEqual2DimArrays(expected, result);
        }
        #endregion

        public class Solution
        {
            public IList<IList<int>> ThreeSum(int[] nums)
            {
                Array.Sort(nums);
                var result = new List<IList<int>>();

                for (int i = 0; i < nums.Length - 2; i++)
                {
                    if (i > 0 && nums[i] == nums[i - 1])
                        continue;
                    int left = i + 1;
                    int right = nums.Length - 1;

                    while (left < right)
                    {
                        int sum = nums[i] + nums[left] + nums[right];
                        if (sum == 0)
                        {
                            result.Add(new[] { nums[i], nums[left], nums[right] });
                            while (left < right && nums[left] == nums[++left]) ;
                            while (left < right && nums[right] == nums[--right]) ;
                        }
                        else if (sum < 0)
                        {
                            while (left < right && nums[left] == nums[++left]) ;
                        }
                        else
                        {
                            while (left < right && nums[right] == nums[--right]) ;
                        }
                    }
                }

                return result;
            }
        }
    }
}
