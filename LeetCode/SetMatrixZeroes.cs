using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;

namespace LeetCode
{
    [TestClass]
    public class SetMatrixZeroes
    {
        #region Tests
        [DataTestMethod]
        [DataRow("[[1,1,1],[1,0,1],[1,1,1]]", "[[1,0,1],[0,0,0],[1,0,1]]")]
        [DataRow("[[0,1,2,0],[3,4,5,2],[1,3,1,5]]", "[[0,0,0,0],[0,4,5,0],[0,3,1,0]]")]
        public void SetZeroes_Solutions(string matrixJson, string expectedJson)
        {
            int[][] matrix = JsonConvert.DeserializeObject<int[][]>(matrixJson);

            var solution = new Solution();

            solution.SetZeroes(matrix);

            Assert.AreEqual(expectedJson, JsonConvert.SerializeObject(matrix));
        }
        #endregion

        public class Solution
        {
            public void SetZeroes(int[][] matrix)
            {
                var R = matrix.Length;
                var C = matrix[0].Length;
                bool firstCol = false;

                for (int r = 0; r < R; r++)
                {
                    if (matrix[r][0] == 0)
                    {
                        firstCol = true;
                    }

                    for (int c = 1; c < C; c++)
                    {
                        if (matrix[r][c] == 0)
                        {
                            matrix[0][c] = 0;
                            matrix[r][0] = 0;
                        }
                    }
                }

                for (int r = 1; r < R; r++)
                    for (int c = 1; c < C; c++)
                        if (matrix[0][c] == 0 || matrix[r][0] == 0)
                            matrix[r][c] = 0;

                if (matrix[0][0] == 0)
                    for (int c = 1; c < C; c++)
                        matrix[0][c] = 0;


                if (firstCol)
                    for (int r = 0; r < R; r++)
                        matrix[r][0] = 0;
            }
        }
    }
}