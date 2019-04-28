using System.Collections;
using System.Collections.Generic;

namespace LeetCode
{
    public class TreeNodeBSTEnumerator : IEnumerator<int?>
    {
        private readonly TreeNode root;
        private Stack<TreeNode> stack;

        public TreeNodeBSTEnumerator(TreeNode r)
        {
            root = r;
        }

        public void Dispose() { }

        public bool MoveNext()
        {
            if (stack == null)
            {
                stack = new Stack<TreeNode>();
                PushNext(root);
            }
            else if (stack.Count > 0)
                PushNext(stack.Pop().right);

            return stack.Count > 0;
        }

        public void Reset()
        {
            stack = null;
        }

        public int? Current => stack.Count > 0 ? stack.Peek().val : (int?) null;

        object IEnumerator.Current => Current;

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
