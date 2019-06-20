using System.Collections;
using System.Collections.Generic;

namespace LeetCode
{
    public static class TreeNodeAsArrayExtension
    {
        public static TreeNodeAsArray AsArray(this TreeNode root)
        {
            return new TreeNodeAsArray(root);
        }
    }

    public class TreeNodeAsArray : IEnumerable<int?>
    {
        public TreeNode Root { get; }

        public TreeNodeAsArray(TreeNode root)
        {
            Root = root;
        }

        public IEnumerator<int?> GetEnumerator()
        {
            return new TreeNodeAsArrayEnumerator(Root);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class TreeNodeAsArrayEnumerator : IEnumerator<int?>
    {
        private readonly TreeNode root;
        private Queue<TreeNode> queue;

        public TreeNodeAsArrayEnumerator(TreeNode r)
        {
            root = r;
        }

        public void Dispose() { }

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
                if (curr != null && (curr.left != null || curr.right != null))
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

        public int? Current => queue?.Count > 0 ? queue.Peek()?.val : null;

        object IEnumerator.Current => Current;
    }

}
