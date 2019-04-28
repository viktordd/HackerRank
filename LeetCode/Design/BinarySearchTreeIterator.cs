using System.Collections.Generic;
using Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode
{
    [TestClass]
    public class BinarySearchTreeIterator
    {
        #region Tests

        [TestMethod]
        public void BinarySearchTreeIterator_Solutions()
        {
            var root = TreeNode.GetTree(8, 3, 10, 1, 6, null, 14, null, null, 4, 7, null, null, 13, null);

            var i = new BSTIterator(root);

            var list = new List<int>();

            while (i.HasNext())
                list.Add(i.Next());

            AssertEnumerable.AreEqual(new[] {1, 3, 4, 6, 7, 8, 10, 13, 14}, list.ToArray());
        }

        #endregion

        public class BSTIterator
        {
            private readonly Stack<TreeNode> stack;

            public BSTIterator(TreeNode root)
            {
                stack = new Stack<TreeNode>();
                PushNext(root);
            }

            /** @return whether we have a next smallest number */
            public bool HasNext()
            {
                return stack.Count > 0;
            }

            /** @return the next smallest number */
            public int Next()
            {
                if (!HasNext())
                    return 0;

                var curr = stack.Pop();
                PushNext(curr.right);

                return curr.val;
            }

            private void PushNext(TreeNode curr)
            {
                while (curr != null)
                {
                    stack.Push(curr);
                    curr = curr.left;
                }
            }
        }
    }
}
