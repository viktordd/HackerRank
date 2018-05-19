using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRankTest.DataStructures.Stacks
{
    [TestClass]
    public class LargestRectangle
    {
        [TestMethod]
        public void LargestRectangle_Solutions()
        {
            Assert.AreEqual(18, largestRectangle(new[] {1, 3, 6, 8, 7, 2, 4, 1}));
        }

        // Complete the largestRectangle function below.
        static long largestRectangle(int[] h)
        {
            long max = 0;
            var stack = new Stack<Tuple<int, int>>();
            stack.Push(Tuple.Create(h[0], 0));

            for (int i = 1; i < h.Length; i++)
            {
                if (h[i] > h[i-1])
                    stack.Push(Tuple.Create(h[i], i)); //add as left edge
                else
                {
                    // prevoius value is a right edge, calucate rectangle areas for all left edges in stack bigger then current.
                    int leftMost = i;
                    while (stack.Count > 0 && stack.Peek().Item1 > h[i]) //find left edge of the curr rectangle
                    {
                        var curr = stack.Pop();
                        leftMost = curr.Item2;
                        max = Math.Max(max, curr.Item1 * (i - leftMost));
                    }

                    stack.Push(Tuple.Create(h[i], leftMost)); //store incomplete rectangle with left most edge.
                }
            }

            //remaining rectanges end at the end of the array
            max = Math.Max(max, stack.Max(curr => curr.Item1 * (h.Length - curr.Item2)));
            return max;
        }
    }
}
