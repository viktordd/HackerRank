using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;

namespace LeetCode
{
    [TestClass]
    public class MinPathSum
    {
        #region Tests
        [DataTestMethod]
        [DataRow("[[1,3,1],[1,5,1],[4,2,1]]", 7)]
        public void MinPathSum_Solutions(string gridJson, int expected)
        {
            int[][] grid = JsonConvert.DeserializeObject<int[][]>(gridJson);

            var solution = new Solution();

            var result = solution.MinPathSum(grid);

            Assert.AreEqual(expected, result);
        }
        #endregion

        public class Solution
        {
            public int MinPathSum(int[][] grid)
            {
                var R = grid.Length;
                var C = grid[0].Length;

                for (int c = 1; c < C; c++)
                    grid[0][c] += grid[0][c - 1];

                for (int r = 1; r < R; r++)
                {
                    grid[r][0] += grid[r - 1][0];
                    for (int c = 1; c < C; c++)
                        grid[r][c] += Math.Min(grid[r - 1][c], grid[r][c - 1]);
                }

                return grid[R - 1][C - 1];
            }
        }
    }
}