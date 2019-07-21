using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;

namespace LeetCode
{
    [TestClass]
    public class RotateMatrix
    {
        #region Tests
        [DataTestMethod]
        [DataRow("[[1,2,3],[4,5,6],[7,8,9]]",
                 "[[7,4,1],[8,5,2],[9,6,3]]")]
        [DataRow("[[5,1,9,11],[2,4,8,10],[13,3,6,7],[15,14,12,16]]",
                 "[[15,13,2,5],[14,3,4,1],[12,6,8,9],[16,7,10,11]]")]
        [DataRow("[[1,2,3,4,5],[6,7,8,9,10],[11,12,13,14,15],[16,17,18,19,20],[21,22,23,24,25]]",
                 "[[21,16,11,6,1],[22,17,12,7,2],[23,18,13,8,3],[24,19,14,9,4],[25,20,15,10,5]]")]
        public void Rotate_Solutions(string matrixJson, string expectedJson)
        {
            var matrix = JsonConvert.DeserializeObject<int[][]>(matrixJson);

            var solution = new Solution2();

            solution.Rotate(matrix);

            Assert.AreEqual(expectedJson, JsonConvert.SerializeObject(matrix));
        }
        #endregion

        public class Solution
        {
            public void Rotate(int[][] matrix)
            {
                var n = matrix.Length - 1;
                for (int i = 0; i < n; i++)
                {
                    for (int j = i; j < n - i; j++)
                    {
                        Rotate(matrix, i, j);
                    }
                }
            }

            private void Rotate(int[][] matrix, int i, int j)
            {
                var n = matrix.Length - 1;

                var t = matrix[i][j];

                matrix[i][j] = matrix[n - j][i];
                matrix[n - j][i] = matrix[n - i][n - j];
                matrix[n - i][n - j] = matrix[j][n - i];
                matrix[j][n - i] = t;
            }
        }

        public class Solution2
        {
            /*
             * clockwise rotate
             * first reverse up to down, then swap the symmetry 
             * 1 2 3     7 8 9     7 4 1
             * 4 5 6  => 4 5 6  => 8 5 2
             * 7 8 9     1 2 3     9 6 3
            */
            public void Rotate(int[][] matrix)
            {
                Array.Reverse(matrix);
                for (int i = 0; i < matrix.Length; ++i)
                    for (int j = i + 1; j < matrix[i].Length; ++j)
                        Swap(ref matrix[i][j], ref matrix[j][i]);
            }

            /*
             * anticlockwise rotate
             * first reverse left to right, then swap the symmetry
             * 1 2 3     3 2 1     3 6 9
             * 4 5 6  => 6 5 4  => 2 5 8
             * 7 8 9     9 8 7     1 4 7
            */
            public void AntiRotate(int[][] matrix)
            {
                foreach (var line in matrix)
                    Array.Reverse(line);

                for (int i = 0; i < matrix.Length; ++i)
                    for (int j = i + 1; j < i; ++j)
                        Swap(ref matrix[i][j], ref matrix[j][i]);
            }

            private void Swap(ref int i, ref int j)
            {
                var t = i;
                i = j;
                j = t;
            }
        }
    }
}