using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace LeetCode
{
    [TestClass]
    public class FourSumTest
    {
        [DataTestMethod]
        [DataRow(new[] { 1, 0, -1, 0, -2, 2 }, 0, "[[-2,-1,1,2],[-2,0,0,2],[-1,0,0,1]]")]
        [DataRow(new[] { 2, 2, 2, 2, 2 }, 8, "[[2,2,2,2]]")]
        public void FourSum_Solutions(int[] nums, int target, string expectedJson)
        {
            var solution = new FourSumClass();
            var result = solution.FourSum(nums, target);
            Assert.AreEqual(expectedJson, JsonConvert.SerializeObject(result));
        }
    }

    // https://leetcode.com/problems/4sum/
    public class FourSumClass
    {
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            Array.Sort(nums);
            return KSum(nums, target, 0, 4);
        }

        private IList<IList<int>> KSum(int[] nums, int target, int start, int k)
        {
            var res = new List<IList<int>>();
            if (start == nums.Length || nums[start] * k > target || target > nums[^1] * k)
                return res;
            if (k == 2)
                return TwoSum(nums, target, start);

            for (int i = start; i < nums.Length; ++i)
                if (i == start || nums[i - 1] != nums[i])
                    foreach (List<int> subset in KSum(nums, target - nums[i], i + 1, k - 1))
                    {
                        subset.Insert(0, nums[i]);
                        res.Add(subset);
                    }

            return res;
        }

        public List<IList<int>> TwoSum(int[] nums, int target, int start)
        {
            var res = new List<IList<int>>();
            var set = new HashSet<int>();

            for (int i = start; i < nums.Length; i++)
            {
                if (res.Count == 0 || res[^1][1] != nums[i])
                    if (set.Contains(target - nums[i]))
                        res.Add(new List<int>() { target - nums[i], nums[i] });
                set.Add(nums[i]);
            }

            return res;
        }
    }
}