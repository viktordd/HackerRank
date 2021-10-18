using System;
using System.Collections.Generic;
using Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace LeetCode
{
    [TestClass]
    public class InsertIntervalTest
    {
        [DataTestMethod]
        [DataRow("[[1, 3], [6, 9]]", new[] { 2, 5 }, "[[1, 5], [6, 9]]")]
        [DataRow("[[1, 2], [3, 5], [6, 7], [8, 10], [12, 16]]", new[] { 4, 8 }, "[[1, 2], [3, 10], [12, 16]]")]
        [DataRow("[[3, 5], [6, 7], [8, 10], [12, 16]]", new[] { 1, 2 }, "[[1, 2], [3, 5], [6, 7], [8, 10], [12, 16]]")]
        [DataRow("[[1, 2], [3, 5], [6, 7], [8, 10], [12, 16]]", new[] { 17, 18 }, "[[1, 2], [3, 5], [6, 7], [8, 10], [12, 16], [17, 18]]")]
        [DataRow("[]", new[] { 5, 7 }, "[[5, 7]]")]
        [DataRow("[[1, 5]]", new[] { 2, 3 }, "[[1, 5]]")]
        [DataRow("[[1, 5]]", new[] { 2, 7 }, "[[1, 7]]")]
        public void InsertInterval_Solutions(string intervalsStr, int[] newInterval, string expectedStr)
        {
            int[][] intervals = JsonConvert.DeserializeObject<int[][]>(intervalsStr);
            int[][] expected = JsonConvert.DeserializeObject<int[][]>(expectedStr);

            var solution = new InsertIntervalClass();
            var result = solution.Insert(intervals, newInterval);
            AssertEnumerable.AreEqual2DimArrays(expected, result);
        }
    }

    public class InsertIntervalClass
    {
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            if (intervals.Length == 0)
            {
                return new[] { newInterval };
            }

            List<int[]> result = new();

            for (int i = 0; i < intervals.Length; i++)
            {
                if (intervals[i][1] < newInterval[0])
                    result.Add(intervals[i]);
                else
                    break;
            }

            int curr = result.Count;
            if (curr < intervals.Length && intervals[curr][0] <= newInterval[1])
            {
                newInterval[0] = Math.Min(intervals[curr][0], newInterval[0]);

                while (curr < intervals.Length && intervals[curr][0] <= newInterval[1]) curr++;

                newInterval[1] = Math.Max(intervals[curr - 1][1], newInterval[1]);

            }

            result.Add(newInterval);

            for (int i = curr; i < intervals.Length; i++)
            {
                result.Add(intervals[i]);
            }

            return result.ToArray();
        }
    }
}