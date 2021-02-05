using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Algorithms.BinarySearchTree
{
    public class RedBlackBST<TKey, TValue> : IEnumerable<TKey>
        where TKey : IComparable<TKey>
    {
        private const bool RED = true;
        private const bool BLACK = false;

        private Node root;

        private class Node
        {
            public TKey key;
            public TValue val;
            public Node left, right;
            public bool color;
            //public int count;

            public Node(TKey key, TValue val, bool color)
            {
                this.key = key;
                this.val = val;
                this.color = color;
            }
        }

        public void Put(TKey key, TValue val) => root = Put(root, key, val);

        private Node Put(Node x, TKey key, TValue val)
        {
            if (x == null) return new Node(key, val, RED);
            int cmp = key.CompareTo(x.key);
            if (cmp < 0)
                x.left = Put(x.left, key, val);
            else if (cmp > 0)
                x.right = Put(x.right, key, val);
            else if (cmp == 0)
                x.val = val;
            //x.count = 1 + size(x.left) + size(x.right);

            return FixNode(x);
        }

        private Node FixNode(Node x)
        {
            //lean left
            if (IsRed(x.right) && !IsRed(x.left)) x = RotateLeft(x);
            //balance 4-node
            if (IsRed(x.left) && IsRed(x.left.left)) x = RotateRight(x);
            //split 4-node
            if (IsRed(x.left) && IsRed(x.right)) FlipColors(x);

            return x;
        }

        public bool TryGet(TKey key, out TValue val)
        {
            Node x = root;
            while (x != null)
            {
                int cmp = key.CompareTo(x.key);
                if (cmp < 0) x = x.left;
                else if (cmp > 0) x = x.right;
                else if (cmp == 0)
                {
                    val = x.val;
                    return true;
                }
            }
            val = default;
            return false;
        }

        private Node Min(Node x)
        {
            while (x.left != null)
                x = x.left;
            return x;
        }

        private Node Max(Node x)
        {
            while (x.right != null)
                x = x.right;
            return x;
        }

        private bool IsRed(Node x) => x?.color == RED;

        public void Delete(TKey key) => root = Delete(root, key);

        private Node Delete(Node x, TKey key)
        {
            //TODO: implement red-black delete
            if (x == null) return null;
            int cmp = key.CompareTo(x.key);
            // search for key
            if (cmp < 0) x.left = Delete(x.left, key);
            else if (cmp > 0) x.right = Delete(x.right, key);
            else
            {
                // no right child
                if (x.right == null) return FixNode(x.left);
                // no left child
                if (x.left == null) return FixNode(x.right);

                // replace with successor
                Node t = x;
                x = Min(t.right);
                x.right = DeleteMin(t.right);
                x.left = t.left;
                x.color = t.color;
            }
            //x.count = size(x.left) + size(x.right) + 1;
            return FixNode(x);
        }

        public void DeleteMin() => root = DeleteMin(root);

        private Node DeleteMin(Node x)
        {
            if (x.left == null) return FixNode(x.right);
            x.left = DeleteMin(x.left);
            //x.count = 1 + size(x.left) + size(x.right);
            return FixNode(x);
        }

        private Node RotateLeft(Node p)
        {
            Debug.Assert(IsRed(p.right));
            Node x = p.right;
            p.right = x.left;
            x.left = p;
            x.color = p.color;
            p.color = RED;
            return x;
        }

        private Node RotateRight(Node p)
        {
            Debug.Assert(IsRed(p.left));
            Node x = p.left;
            p.left = x.right;
            x.right = p;
            x.color = p.color;
            p.color = RED;
            return x;
        }

        private void FlipColors(Node p)
        {
            Debug.Assert(!IsRed(p));
            Debug.Assert(IsRed(p.left));
            Debug.Assert(IsRed(p.right));
            p.color = RED;
            p.left.color = BLACK;
            p.right.color = BLACK;
        }

        //public int size()
        //{
        //    return size(root);
        //}
        //private int size(Node x)
        //{
        //    if (x == null) return 0;
        //    return x.count;
        //}

        public bool TryFloor(TKey key, out TKey outKey)
        {
            Node x = Floor(root, key);
            if (x == null)
            {
                outKey = default;
                return false;
            }
            outKey = x.key;
            return true;
        }

        private Node Floor(Node x, TKey key)
        {
            if (x == null) return null;
            int cmp = key.CompareTo(x.key);

            if (cmp == 0) return x;

            if (cmp < 0) return Floor(x.left, key);

            Node t = Floor(x.right, key);
            if (t != null) return t;
            else return x;
        }

        public IEnumerator<TKey> GetEnumerator()
        {
            return new InorderKeyEnumerator(root);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new InorderKeyEnumerator(root);
        }

        private struct InorderKeyEnumerator : IEnumerator<TKey>
        {
            Node root;
            Stack<Node> stack;

            public InorderKeyEnumerator(Node root)
            {
                this.root = root;
                stack = null;
            }

            public TKey Current => stack == null ? throw new Exception() : stack.Peek().key;

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                if (stack == null)
                {
                    stack = new Stack<Node>();
                    Inorder(root);
                }
                else
                {
                    var x = stack.Pop();
                    Inorder(x.right);
                }

                return stack.Count > 0;
            }

            private void Inorder(Node x)
            {
                while (x == null)
                {
                    stack.Push(x);
                    x = x.left;
                }
            }

            public void Reset()
            {
                stack = null;
            }

            public void Dispose()
            {
                root = null;
                stack = null;
            }
        }
    }
}
