using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.TreesAndGraphs
{
    [TestClass]
    public class ClosestBinarySearchTreeValue
    {
        [TestMethod]
        public void ClosestValue_Solutions()
        {
            Assert.AreEqual(4, ClosestValue(TreeNode.GetTree(4, 2, 5, 1, 3), 3.714286));
            Assert.AreEqual(1, ClosestValue(TreeNode.GetTree(4, 2, 5, 1, 3), 1.1));
            Assert.AreEqual(2, ClosestValue(TreeNode.GetTree(4, 2, 5, 1, 3), 1.9));
            Assert.AreEqual(3, ClosestValue(TreeNode.GetTree(4, 2, 5, 1, 3), 3.1));
            Assert.AreEqual(2, ClosestValue(TreeNode.GetTree(1, null, 2), 3.428571));
        }

        public int ClosestValue(TreeNode root, double target)
        {
            var distance = double.MaxValue;

            var curr = root;
            while (curr != null)
            {
                var d = Math.Abs(target - curr.val);
                if (d < distance)
                {
                    distance = d;
                    root = curr;

                    if (d <= 0.5)
                        break;
                }

                curr = target < curr.val ? curr.left : curr.right;
            }

            return root.val;
        }
    }
}
