using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;

namespace LeetCode
{
    [TestClass]
    public class CombinationSum2
    {
        #region Tests
        [DataTestMethod]
        [DataRow(new[] { 10, 1, 2, 7, 6, 1, 5 }, 8, "[ [1, 7], [1, 2, 5], [2, 6], [1, 1, 6] ]")]
        [DataRow(new[] { 2, 5, 2, 1, 2 }, 5, "[ [1, 2, 2], [5] ]")]
        public void CombinationSum2_Solutions(int[] candidates, int target, string expectedJson)
        {
            List<IList<int>> expected = JsonConvert.DeserializeObject<List<IList<int>>>(expectedJson);

            var solution = new Solution();

            var result = solution.CombinationSum2(candidates, target);

            Assert.AreEqual(JsonConvert.SerializeObject(expected.OrderBy(l => string.Join(',', l))),
                            JsonConvert.SerializeObject(result.OrderBy(l => string.Join(',', l))));
        }
        #endregion

        public class Solution
        {
            public IList<IList<int>> CombinationSum2(int[] candidates, int target)
            {
                Array.Sort(candidates);

                var result = new List<IList<int>>();

                Dfs(candidates, 0, target, new List<int>(), result);

                return result;
            }


            public void Dfs(int[] cand, int curr, int target, List<int> path, List<IList<int>> result)
            {
                if (target == 0)
                {
                    result.Add(new List<int>(path));
                    return;
                }

                for (int i = curr; i < cand.Length; i++)
                {
                    if (cand[i] > target) return;
                    if (i > curr && cand[i] == cand[i - 1]) continue;
                    path.Add(cand[i]);
                    Dfs(cand, i + 1, target - cand[i], path, result);
                    path.RemoveAt(path.Count - 1);
                }
            }
        }

        public class Solution2
        {
            public List<IList<int>> CombinationSum2(int[] cand, int target)
            {
                Array.Sort(cand);
                List<IList<int>> res = new List<IList<int>>();
                List<int> path = new List<int>();
                dfs_com(cand, 0, target, path, res);
                return res;
            }
            void dfs_com(int[] cand, int cur, int target, List<int> path, List<IList<int>> res)
            {
                if (target < 0)
                    return;
                if (target == 0)
                {
                    res.Add(new List<int>(path));
                    return;
                }
                for (int i = cur; i < cand.Length; i++)
                {
                    if (i > cur && cand[i] == cand[i - 1]) continue;
                    path.Add(cand[i]);
                    dfs_com(cand, i + 1, target - cand[i], path, res);
                    path.RemoveAt(path.Count - 1);
                }
            }
        }
    }
}