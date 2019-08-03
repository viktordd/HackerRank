using System;
using System.Collections.Generic;
using System.Linq;
using Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;

namespace LeetCode
{
    [TestClass]
    public class SpiralOrder
    {
        #region Tests
        [DataTestMethod]
        [DataRow("[]", new int[0])]
        [DataRow("[[1, 2, 3],[4, 5, 6],[7, 8, 9]]", new[] { 1, 2, 3, 6, 9, 8, 7, 4, 5 })]
        [DataRow("[[1],[2],[3],[4],[5],[6],[7],[8],[9],[10]]", new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        public void SpiralOrder_Solutions(string matrixJson, int[] expected)
        {
            int[][] matrix = JsonConvert.DeserializeObject<int[][]>(matrixJson);

            var solution = new Solution();

            var result = solution.SpiralOrder(matrix);

            Assert.AreEqual(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(result));
        }
        #endregion

        public class Solution
        {
            public IList<int> SpiralOrder(int[][] matrix)
            {
                var result = new List<int>();
                if (matrix == null || matrix.Length == 0)
                    return result;

                int t = 0, b = matrix.Length - 1;
                int l = 0, r = matrix[0].Length - 1;

                while (t <= b && l <= r)
                {
                    for (int i = l; i <= r; i++) result.Add(matrix[t][i]);
                    for (int i = t + 1; i <= b; i++) result.Add(matrix[i][r]);

                    if (t == b || l == r) break;

                    for (int i = r - 1; i > l; i--) result.Add(matrix[b][i]);
                    for (int i = b; i > t; i--) result.Add(matrix[i][l]);

                    t++;
                    b--;
                    l++;
                    r--;
                }

                return result;
            }
        }
    }
}