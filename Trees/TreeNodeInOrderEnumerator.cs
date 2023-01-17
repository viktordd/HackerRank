using System;
using System.Collections;
using System.Collections.Generic;

namespace Trees;

public class TreeNodeInOrderEnumerator<T> : IEnumerator<T>
{
    private readonly TreeNode<T> root;
    private Stack<TreeNode<T>> stack;

    public TreeNodeInOrderEnumerator(TreeNode<T> root)
    {
        this.root = root;
    }

    public T Current => stack.Count > 0 ? stack.Peek().Val : default;

    object IEnumerator.Current => this.Current;

    public void Dispose() { GC.SuppressFinalize(this); }

    public bool MoveNext()
    {
        if (stack == null)
        {
            stack = new();
            PushLeft(root);
        }
        else if (stack.Count > 0)
        {
            var curr = stack.Pop();
            PushLeft(curr.Right);
        }

        return stack.Count > 0;
    }

    public void Reset()
    {
        stack = null;
    }

    private void PushLeft(TreeNode<T> node)
    {
        var curr = node;
        while (curr != null)
        {
            stack.Push(curr);
            curr = curr.Left;
        }
    }
}