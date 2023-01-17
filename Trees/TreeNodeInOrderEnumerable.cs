using System;
using System.Collections;
using System.Collections.Generic;

namespace Trees;

public class TreeNodeInOrderEnumerable<T> : IEnumerable<T>
{
    private TreeNode<T> root;

    public TreeNodeInOrderEnumerable(TreeNode<T> root)
    {
        this.root = root;
    }

    public IEnumerator<T> GetEnumerator() => new TreeNodeInOrderEnumerator<T>(root);

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}