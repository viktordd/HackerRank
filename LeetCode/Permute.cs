using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace LeetCode
{
    [TestClass]
    public class Permute
    {
        #region Tests
        [DataTestMethod]
        [DataRow(new int[0], "[]")]
        [DataRow(new[] { 1, 2, 3 }, "[[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]")]
        public void Permute_Solutions(int[] nums, string expectedJson)
        {
            var solution = new Solution2();

            var result = solution.Permute(nums);

            Assert.AreEqual(expectedJson, JsonConvert.SerializeObject(result));
        }
        #endregion

        public class Solution
        {
            public IList<IList<int>> Permute(int[] nums)
            {
                var result = new List<IList<int>>();

                Permute(nums, 0, result);

                return result;
            }

            private void Permute(int[] nums, int c, List<IList<int>> result)
            {
                if (c == nums.Length - 1)
                {
                    result.Add(new List<int>(nums));
                    return;
                }

                for (int i = c; i < nums.Length; i++)
                {
                    Swap(nums, c, i);
                    Permute(nums, c + 1, result);
                    Swap(nums, c, i);
                }
            }

            private void Swap(int[] nums, int c, int i)
            {
                var t = nums[c];
                nums[c] = nums[i];
                nums[i] = t;
            }
        }

        public class Solution2
        {
            public IList<IList<int>> Permute(int[] nums)
            {
                var result = new List<IList<int>>();
                if (nums == null || nums.Length == 0) return result;

                bool[] used = new bool[nums.Length];
                var list = new List<int>();

                Dfs(nums, used, list, result);

                return result;
            }

            private void Dfs(int[] nums, bool[] used, List<int> list, List<IList<int>> result)
            {
                if (list.Count == nums.Length)
                {
                    result.Add(new List<int>(list));
                    return;
                }

                for (int i = 0; i < nums.Length; i++)
                {
                    if (used[i]) continue;

                    used[i] = true;
                    list.Add(nums[i]);

                    Dfs(nums, used, list, result);

                    used[i] = false;
                    list.RemoveAt(list.Count - 1);
                }
            }
        }
    }
}