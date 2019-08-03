using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;

namespace LeetCode
{
    [TestClass]
    public class MergeIntervals
    {
        #region Tests
        [DataTestMethod]
        [DataRow("[[1,3],[2,6],[8,10],[15,18]]", "[[1,6],[8,10],[15,18]]")]
        [DataRow("[[1,4],[4,5]]", "[[1,5]]")]
        [DataRow("[[2,3],[1,4]]", "[[1,4]]")]
        public void MergeIntervals_Solutions(string intervalsJson, string expectedJson)
        {
            int[][] intervals = JsonConvert.DeserializeObject<int[][]>(intervalsJson);

            var solution = new Solution();

            var result = solution.Merge(intervals);

            Assert.AreEqual(expectedJson, JsonConvert.SerializeObject(result));
        }
        #endregion

        public class Solution
        {
            public int[][] Merge(int[][] intervals)
            {
                List<int[]> result = new List<int[]>();

                Array.Sort(intervals, Comparer<int[]>.Create((a, b) => a[0].CompareTo(b[0])));

                if (intervals.Length > 0)
                    result.Add(intervals[0]);

                foreach (var interval in intervals.Skip(1))
                {
                    var last = result[result.Count - 1];
                    if (last[1] >= interval[0])
                        last[1] = Math.Max(last[1], interval[1]);
                    else
                        result.Add(interval);
                }

                return result.ToArray();
            }
        }
    }
}