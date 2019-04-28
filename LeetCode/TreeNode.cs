using System.Collections;
using System.Collections.Generic;

namespace LeetCode {
    public class TreeNode : IEnumerable<int?>
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int x = 0)
        {
            val = x;
        }

        public static TreeNode GetTree(params int?[] list)
        {
            return GetTreeNode(list, 0);
        }

        private static TreeNode GetTreeNode(int?[] list, int i)
        {
            return i < list.Length && list[i].HasValue
                ? new TreeNode(list[i].Value)
                {
                    left = GetTreeNode(list, i * 2 + 1),
                    right = GetTreeNode(list, i * 2 + 2)
                }
                : null;
        }

        public override string ToString()
        {
            return val.ToString();
        }

        public IEnumerator<int?> GetEnumerator()
        {
            return new TreeNodeBSTEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}