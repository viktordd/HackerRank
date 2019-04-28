using Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.TreesAndGraphs
{
    [TestClass]
    public class MaximumBinaryTree

    {
        [TestMethod]
        public void MaximumBinaryTree_Solutions()
        {
            AssertEnumerable.AreEqual(new int?[] { 6, 3, 5, null, 2, 0, null, null, 1 }, ConstructMaximumBinaryTree(new[] {3, 2, 1, 6, 0, 5}));
        }

        public TreeNode ConstructMaximumBinaryTree(int[] nums)
        {
            return ConstructMaximumBinaryTree(nums, 0, nums.Length);
        }

        public TreeNode ConstructMaximumBinaryTree(int[] nums, int start, int end)
        {
            if (start == end)
                return null;

            var max = start;
            for (int i = start + 1; i < end; i++)
            {
                if (nums[i] > nums[max])
                    max = i;
            }

            return new TreeNode(nums[max])
            {
                left = ConstructMaximumBinaryTree(nums, start, max),
                right = ConstructMaximumBinaryTree(nums, max + 1, end)
            };
        }
    }
}
