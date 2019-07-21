using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace LeetCode
{
    [TestClass]
    public class PermuteUnique
    {
        #region Tests
        [DataTestMethod]
        [DataRow(new int[0], "[]")]
        [DataRow(new[] { 1, 1, 2 }, "[[1,1,2],[1,2,1],[2,1,1]]")]
        [DataRow(new[] { 2, 2, 1, 1 }, "[[1,1,2,2],[1,2,1,2],[1,2,2,1],[2,1,1,2],[2,1,2,1],[2,2,1,1]]")]
        public void PermuteUnique_Solutions(int[] nums, string expectedJson)
        {
            var solution = new Solution2();

            var result = solution.PermuteUnique(nums);

            Assert.AreEqual(expectedJson, JsonConvert.SerializeObject(result));
        }
        #endregion

        public class Solution
        {
            public IList<IList<int>> PermuteUnique(int[] nums)
            {
                Array.Sort(nums);
                var result = new Dictionary<string, IList<int>>();

                Permute(nums, 0, result);

                return result.Select(p => p.Value).ToList();
            }

            private void Permute(int[] nums, int c, Dictionary<string, IList<int>> result)
            {
                if (c == nums.Length - 1)
                {
                    var key = string.Join("", nums);
                    if (!result.ContainsKey(key))
                        result.Add(key, new List<int>(nums));
                    return;
                }

                Permute(nums, c + 1, result);

                for (int i = c + 1; i < nums.Length; i++)
                {
                    if (nums[i] == nums[c]) continue;

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
            public List<IList<int>> PermuteUnique(int[] nums)
            {
                var result = new List<IList<int>>();
                if (nums == null || nums.Length == 0) return result;

                bool[] used = new bool[nums.Length];
                var list = new List<int>();

                Array.Sort(nums);

                Dfs(nums, used, list, result);

                return result;
            }

            public void Dfs(int[] nums, bool[] used, List<int> list, List<IList<int>> result)
            {
                if (list.Count == nums.Length)
                {
                    result.Add(new List<int>(list));
                    return;
                }

                for (int i = 0; i < nums.Length; i++)
                {
                    if (used[i] || i > 0 && nums[i - 1] == nums[i] && !used[i - 1]) continue;

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