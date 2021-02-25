using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;

namespace LeetCode
{
    [TestClass]
    public class SkylineTest
    {
        [DataTestMethod]
        [DataRow("[[2,9,10],[3,7,15],[5,12,12],[15,20,10],[19,24,8]]", "[[2,10],[3,15],[7,12],[12,0],[15,10],[20,8],[24,0]]")]
        [DataRow("[[0,2,3],[2,5,3]]", "[[0,3],[5,0]]")]
        public void Test(string buildingsJson, string expectedJson)
        {
            var solution = new SkylineClass();

            var buildings = JsonConvert.DeserializeObject<int[][]>(buildingsJson);
            var result = solution.GetSkyline(buildings);
            var resultJson = JsonConvert.SerializeObject(result);

            Assert.AreEqual(expectedJson, resultJson);
        }
    }

    public class SkylineClass
    {
        public bool Skyline()
        {
            return true;
        }

        public IList<IList<int>> GetSkyline(int[][] buildings)
        {
            // return helper(buildings, 0, buildings.Length);
            return helper1(buildings, 0, buildings.Length - 1);
        }


        private List<IList<int>> helper(int[][] buildings, int start, int count)
        {
            if (count == 0) return new List<IList<int>>();
            if (count == 1)
            {
                var result = new List<IList<int>>();
                var building = buildings[start];
                result.Add(new[] { building[0], building[2] });
                result.Add(new[] { building[1], 0 });
                return result;
            }

            int m = count / 2;

            var left = helper(buildings, start, m);
            var right = helper(buildings, start + m, m + count % 2);

            return merge(left, right);
        }

        private List<IList<int>> helper1(int[][] buildings, int start, int end)
        {
            if (start > end) return new List<IList<int>>();
            if (start == end)
            {
                var result = new List<IList<int>>();
                var building = buildings[start];
                result.Add(new[] { building[0], building[2] });
                result.Add(new[] { building[1], 0 });
                return result;
            }

            int m = start + (end - start) / 2;

            var left = helper1(buildings, start, m);
            var right = helper1(buildings, m + 1, end);

            return merge(left, right);
        }

        private List<IList<int>> merge(List<IList<int>> left, List<IList<int>> right)
        {
            int pL = 0, pR = 0;
            int currY = 0, leftY = 0, rightY = 0;
            int x, maxY;
            List<IList<int>> output = new List<IList<int>>();

            // while we're in the region where both skylines are present
            while (pL < left.Count && pR < right.Count)
            {
                IList<int> pointL = left[pL];
                IList<int> pointR = right[pR];
                // pick up the smallest x
                if (pointL[0] < pointR[0])
                {
                    x = pointL[0];
                    leftY = pointL[1];
                    pL++;
                }
                else
                {
                    x = pointR[0];
                    rightY = pointR[1];
                    pR++;
                }
                // max height between both skylines
                maxY = Math.Max(leftY, rightY);

                // update output if there is a skyline change
                if (currY != maxY)
                {
                    updateOutput(output, x, maxY);
                    currY = maxY;
                }
            }

            appendSkyline(output, left, pL, currY);
            appendSkyline(output, right, pR, currY);

            return output;
        }

        private void appendSkyline(List<IList<int>> output, List<IList<int>> skyline, int p, int currY)
        {
            while (p < skyline.Count)
            {
                int x = skyline[p][0];
                int y = skyline[p][1];
                p++;

                // update output if there is a skyline change
                if (currY != y)
                {
                    updateOutput(output, x, y);
                    currY = y;
                }
            }
        }

        public void updateOutput(List<IList<int>> output, int x, int y)
        {
            // if skyline change is not vertical add the new point
            if (output.Count == 0 || output[output.Count - 1][0] != x)
                output.Add(new[] { x, y });

            else // if skyline change is vertical update the last point
                output[output.Count - 1][1] = y;
        }
    }
}