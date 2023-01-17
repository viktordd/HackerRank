using System;
using System.Collections;
using System.Collections.Generic;

namespace LeetCode
{
    public class TreeNodeEnumerator : IEnumerator<int?>
    {
        private readonly TreeNode root;
        private Queue<TreeNode> queue;

        public TreeNodeEnumerator(TreeNode r)
        {
            root = r;
        }

        public void Dispose() { GC.SuppressFinalize(this); }

        public bool MoveNext()
        {
            if (queue == null)
            {
                queue = new Queue<TreeNode>();
                queue.Enqueue(root);
            }
            else if (queue.Count > 0)
            {
                var curr = queue.Dequeue();

                if (curr.left != null || curr.right != null)
                {
                    queue.Enqueue(curr.left);
                    queue.Enqueue(curr.right);
                }

            }

            return queue.Count > 0;
        }

        public void Reset()
        {
            queue = null;
        }

        public int? Current => queue.Count > 0 ? queue.Peek().val : (int?) null;

        object IEnumerator.Current => Current;
    }

}
