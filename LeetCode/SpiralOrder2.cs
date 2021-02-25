using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace LeetCode
{
    [TestClass]
    public class SpiralOrder2Test
    {
        [DataTestMethod]
        [DataRow("[]", "[]")]
        [DataRow("[[1,2,3],[4,5,6],[7,8,9]]", "[1,2,3,6,9,8,7,4,5]")]
        [DataRow("[[1],[2],[3],[4],[5],[6],[7],[8],[9],[10]]", "[1,2,3,4,5,6,7,8,9,10]")]
        [DataRow("[[1,2,3,4],[5,6,7,8],[9,10,11,12]]", "[1,2,3,4,8,12,11,10,9,5,6,7]")]
        public void Test(string matrixJson, string expectedJson)
        {
            int[][] matrix = JsonConvert.DeserializeObject<int[][]>(matrixJson);

            var solution = new SpiralOrder2Class();
            var result = solution.SpiralOrder(matrix);

            Assert.AreEqual(expectedJson, JsonConvert.SerializeObject(result));
        }
    }

    public class SpiralOrder2Class
    {
        public IList<int> SpiralOrder(int[][] matrix)
        {
            List<int> result = new List<int>();

            if (matrix.Length == 0)
            {
                return result;
            }

            int top = 0;
            int bottom = matrix.Length - 1;
            int left = 0;
            int right = matrix[0].Length - 1;

            (int row, int col)[] directions = {
                (0, 1), // right
                (1, 0), // down
                (0, -1), // left
                (-1, 0) // up
            };
            int r = 0;
            int c = -1;

            int dir = 0;
            while (top <= bottom && left <= right)
            {
                var direction = directions[dir];

                while (r + direction.row >= top && r + direction.row <= bottom &&
                        c + direction.col >= left && c + direction.col <= right)
                {
                    r += direction.row;
                    c += direction.col;
                    result.Add(matrix[r][c]);
                }

                switch (dir)
                {
                    case 0: // right
                        top++;
                        break;
                    case 1: // down
                        right--;
                        break;
                    case 2: // left
                        bottom--;
                        break;
                    case 3: // up
                        left++;
                        break;
                }
                dir = (dir + 1) % 4;
            }

            return result;
        }
    }
}