using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.TreesAndGraphs
{
    [TestClass]
    public class SymmetricTree
    {
        [TestMethod]
        public void SymmetricTree_Solutions()
        {
            Assert.IsTrue(IsSymmetric(TreeNode.GetTree(1, 2, 2, 3, 4, 4, 3)));
            Assert.IsFalse(IsSymmetric(TreeNode.GetTree(1, 2, 2, null, 3, null, 3)));
        }
        [TestMethod]
        public void SymmetricTree_Solutions2()
        {
            Assert.IsTrue(IsSymmetric2(TreeNode.GetTree(1, 2, 2, 3, 4, 4, 3)));
            Assert.IsFalse(IsSymmetric2(TreeNode.GetTree(1, 2, 2, null, 3, null, 3)));
        }

        public bool IsSymmetric(TreeNode root)
        {
            if (root == null)
                return true;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root.left);
            queue.Enqueue(root.right);

            while (queue.Count > 0)
            {
                var l1 = queue.Dequeue();
                var l2 = queue.Dequeue();

                if (l1 == null && l2 == null)
                    continue;

                if (l1?.val != l2?.val)
                    return false;

                queue.Enqueue(l1.left);
                queue.Enqueue(l2.right);
                queue.Enqueue(l1.right);
                queue.Enqueue(l2.left);
            }

            return true;
        }

        public bool IsSymmetric2(TreeNode root)
        {
            return root == null || IsSymmetricRecursive(root.left, root.right);
        }

        private bool IsSymmetricRecursive(TreeNode l1, TreeNode l2)
        {
            if (l1 == null && l2 == null)
                return true;

            if (l1?.val != l2?.val)
                return false;

            return IsSymmetricRecursive(l1.left, l2.right) &&
                   IsSymmetricRecursive(l1.right, l2.left);
        }
    }
}
