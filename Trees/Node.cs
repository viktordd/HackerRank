namespace Trees
{
    public class Node<T>
    {
        public T Key { get; set; }
        public int Height { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        public Node(T key)
        {
            Key = key;
            Height = 1;
        }
    }
}