using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;

namespace LeetCode
{
    [TestClass]
    public class Search2DMatrix
    {
        #region Tests
        [DataTestMethod]
        [DataRow("[]", 1, false)]
        [DataRow("[[]]", 1, false)]
        [DataRow("[[1]]", 2, false)]
        [DataRow("[[2]]", 1, false)]
        [DataRow("[[1]]", 1, true)]
        [DataRow("[[1,3,5,7],[10,11,16,20],[23,30,34,50]]", 1, true)]
        [DataRow("[[1,3,5,7],[10,11,16,20],[23,30,34,50]]", 3, true)]
        [DataRow("[[1,3,5,7],[10,11,16,20],[23,30,34,50]]", 50, true)]
        [DataRow("[[1,3,5,7],[10,11,16,20],[23,30,34,50]]", 51, false)]
        [DataRow("[[1,3,5,7],[10,11,16,20],[23,30,34,50]]", 13, false)]
        public void SearchMatrix_Solutions(string matrixJson, int target, bool expected)
        {
            int[][] matrix = JsonConvert.DeserializeObject<int[][]>(matrixJson);

            var solution = new Solution();

            var result = solution.SearchMatrix(matrix, target);

            Assert.AreEqual(expected, result);
        }
        #endregion

        public class Solution
        {
            public bool SearchMatrix(int[][] matrix, int target)
            {
                var R = matrix.Length;
                if (R == 0) return false;
                var C = matrix[0].Length;
                if (C == 0) return false;

                var start = 0;
                var end = R * C - 1;

                while (start <= end)
                {
                    var mid = start + (end - start) / 2;
                    var midVal = matrix[mid / C][mid % C];

                    if (target == midVal)
                        return true;

                    if (midVal < target)
                        start = mid + 1;
                    else
                        end = mid - 1;
                }

                return false;
            }
        }
    }
}