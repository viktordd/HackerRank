using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.TreesAndGraphs
{
    [TestClass]
    public class ValidateBinarySearchTree
    {
        [TestMethod]
        public void ValidateBinarySearchTree_Solutions()
        {
            Assert.IsTrue(IsValidBST(TreeNode.GetTree(2, 1, 3)));
            Assert.IsFalse(IsValidBST(TreeNode.GetTree(5, 1, 4, null, null, 3, 6)));
            Assert.IsFalse(IsValidBST(TreeNode.GetTree(10, 5, 15, null, null, 6, 20)));
        }

        public bool IsValidBST(TreeNode root)
        {
            return IsValidBst(root, long.MinValue, long.MaxValue);
        }

        private bool IsValidBst(TreeNode root, long min, long max)
        {
            return root == null ||
                   min < root.val && root.val < max &&
                   IsValidBst(root.left, min, root.val) &&
                   IsValidBst(root.right, root.val, max);
        }
    }
}
