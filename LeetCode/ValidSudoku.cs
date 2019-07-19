using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace LeetCode
{
    [TestClass]
    public class IsValidSudoku
    {
        #region Tests
        [DataTestMethod]
        [DataRow("[[\"5\",\"3\",\".\",\".\",\"7\",\".\",\".\",\".\",\".\"],[\"6\",\".\",\".\",\"1\",\"9\",\"5\",\".\",\".\",\".\"],[\".\",\"9\",\"8\",\".\",\".\",\".\",\".\",\"6\",\".\"],[\"8\",\".\",\".\",\".\",\"6\",\".\",\".\",\".\",\"3\"],[\"4\",\".\",\".\",\"8\",\".\",\"3\",\".\",\".\",\"1\"],[\"7\",\".\",\".\",\".\",\"2\",\".\",\".\",\".\",\"6\"],[\".\",\"6\",\".\",\".\",\".\",\".\",\"2\",\"8\",\".\"],[\".\",\".\",\".\",\"4\",\"1\",\"9\",\".\",\".\",\"5\"],[\".\",\".\",\".\",\".\",\"8\",\".\",\".\",\"7\",\"9\"]]", 
            true)]
        [DataRow("[[\"8\",\"3\",\".\",\".\",\"7\",\".\",\".\",\".\",\".\"],[\"6\",\".\",\".\",\"1\",\"9\",\"5\",\".\",\".\",\".\"],[\".\",\"9\",\"8\",\".\",\".\",\".\",\".\",\"6\",\".\"],[\"8\",\".\",\".\",\".\",\"6\",\".\",\".\",\".\",\"3\"],[\"4\",\".\",\".\",\"8\",\".\",\"3\",\".\",\".\",\"1\"],[\"7\",\".\",\".\",\".\",\"2\",\".\",\".\",\".\",\"6\"],[\".\",\"6\",\".\",\".\",\".\",\".\",\"2\",\"8\",\".\"],[\".\",\".\",\".\",\"4\",\"1\",\"9\",\".\",\".\",\"5\"],[\".\",\".\",\".\",\".\",\"8\",\".\",\".\",\"7\",\"9\"]]", 
            false)]
        public void IsValidSudoku_Solutions(string boardJson, bool expected)
        {
            char[][] board = JsonConvert.DeserializeObject<char[][]>(boardJson);

            var solution = new Solution();

            var result = solution.IsValidSudoku(board);

            Assert.AreEqual(expected, result);
        }
        #endregion

        public class Solution
        {
            public bool IsValidSudoku(char[][] board)
            {
                HashSet<string> seen = new HashSet<string>();
                var size = 9;

                for (int i = 0; i < size; i++)
                    for (int j = 0; j < size; j++)
                    {
                        char num = board[i][j];
                        if (num == '.') continue;

                        if (!seen.Add($"{num} in row {i}") ||
                            !seen.Add($"{num} in col {j}") ||
                            !seen.Add($"{num} in box {i / 3}-{j / 3}"))
                            return false;
                    }

                return true;
            }
        }
    }
}