using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.TreesAndGraphs
{
    [TestClass]
    public class SumRootToLeafNumbers

    {
        [TestMethod]
        public void ClosestValue_Solutions()
        {
            Assert.AreEqual(25, SumNumbers(TreeNode.GetTree(1, 2, 3)));
            Assert.AreEqual(12, SumNumbers(TreeNode.GetTree(1, 2)));
            Assert.AreEqual(1026, SumNumbers(TreeNode.GetTree(4, 9, 0, 5, 1)));
        }

        public int SumNumbers(TreeNode root)
        {
            var sum = 0;

            var stack = new Stack<(TreeNode node, int currSum)>();
            stack.Push((root, 0));

            while (stack.Count > 0)
            {
                var (node, currSum) = stack.Pop();
                currSum = currSum * 10 + node.val;

                if (node.left == null && node.right == null)
                    sum += currSum;
                else
                {
                    if (node.left != null)
                        stack.Push((node.left, currSum));
                    if (node.right != null)
                        stack.Push((node.right, currSum));
                }
            }

            return sum;
            //return SumNumbers(root, 0);
        }

        public int SumNumbers(TreeNode root, int sum)
        {
            if (root == null)
                return 0;

            sum = sum * 10 + root.val;

            if (root.left == null && root.right == null)
                return sum;

            return SumNumbers(root.left, sum) +
                   SumNumbers(root.right, sum);
        }
    }
}
