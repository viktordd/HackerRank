namespace Trees;

public class TreeNode<T>
{
    public T Val { get; set; }
    public TreeNode<T> Left { get; set; }
    public TreeNode<T> Right { get; set; }

    public TreeNode(T val, TreeNode<T> left = null, TreeNode<T> right = null)
    {
        Val = val;
        Left = left;
        Right = right;
    }
}