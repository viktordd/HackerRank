namespace Trees;

public class AVLNode<T>
{
    public T Val { get; set; }
    public int Height { get; set; }
    public AVLNode<T> Left { get; set; }
    public AVLNode<T> Right { get; set; }

    public AVLNode(T val, AVLNode<T> left = null, AVLNode<T> right = null)
    {
        Val = val;
        Height = 1;
        Left = left;
        Right = right;
    }
}