using System;

namespace Trees
{
    public class AVLTree<T> where T : IComparable<T>
    {
        public Node<T> Root { get; private set; }

        public void Insert(T key)
        {
            Root = InsertNode(Root, key);
        }

        public void Delete(T key)
        {
            Root = DeleteNode(Root, key);
        }

        private int Height(Node<T> N)
        {
            if (N == null)
                return 0;

            return N.Height;
        }

        private int Max(int a, int b)
        {
            return (a > b) ? a : b;
        }

        private Node<T> RightRotate(Node<T> y)
        {
            Node<T> x = y.Left;
            Node<T> T2 = x.Right;

            // Perform rotation
            x.Right = y;
            y.Left = T2;

            // Update heights
            y.Height = Max(Height(y.Left), Height(y.Right)) + 1;
            x.Height = Max(Height(x.Left), Height(x.Right)) + 1;

            // Return new root
            return x;
        }

        private Node<T> LeftRotate(Node<T> x)
        {
            Node<T> y = x.Right;
            Node<T> T2 = y.Left;

            // Perform rotation
            y.Left = x;
            x.Right = T2;

            // Update heights
            x.Height = Max(Height(x.Left), Height(x.Right)) + 1;
            y.Height = Max(Height(y.Left), Height(y.Right)) + 1;

            // Return new root
            return y;
        }

        private int GetBalance(Node<T> N)
        {
            if (N == null)
                return 0;

            return Height(N.Left) - Height(N.Right);
        }

        private Node<T> InsertNode(Node<T> node, T key)
        {
            /* 1. Perform the normal BST insertion */
            if (node == null)
                return new Node<T>(key);

            if (key.CompareTo(node.Key) <= 0)
                node.Left = InsertNode(node.Left, key);
            else if (key.CompareTo(node.Key) > 0)
                node.Right = InsertNode(node.Right, key);
            //else // Duplicate keys not allowed
            //    return node;
            /* 2. Update height of this ancestor node */
            node.Height = 1 + Max(Height(node.Left),
                                Height(node.Right));

            /* 3. Get the balance factor of this ancestor node to check whether this node became unbalanced */
            int balance = GetBalance(node);

            // If this node becomes unbalanced, then there are 4 cases Left Left Case
            if (balance > 1 && key.CompareTo(node.Left.Key) < 0)
                return RightRotate(node);

            // Right Right Case
            if (balance < -1 && key.CompareTo(node.Right.Key) > 0)
                return LeftRotate(node);

            // Left Right Case
            if (balance > 1 && key.CompareTo(node.Left.Key) > 0)
            {
                node.Left = LeftRotate(node.Left);
                return RightRotate(node);
            }

            // Right Left Case
            if (balance < -1 && key.CompareTo(node.Right.Key) < 0)
            {
                node.Right = RightRotate(node.Right);
                return LeftRotate(node);
            }

            /* return the (unchanged) node pointer */
            return node;
        }
        Node<T> MinValueNode(Node<T> node)
        {
            Node<T> current = node;

            /* loop down to find the leftmost leaf */
            while (current.Left != null)
                current = current.Left;

            return current;
        }

        Node<T> DeleteNode(Node<T> root, T key)
        {
            // STEP 1: PERFORM STANDARD BST DELETE
            if (root == null)
                return root;

            // If the key to be deleted is smaller than the root's key, then it lies in left subtree
            if (key.CompareTo(root.Key) < 0)
                root.Left = DeleteNode(root.Left, key);

            // If the key to be deleted is greater than the root's key, then it lies in right subtree
            else if (key.CompareTo(root.Key) > 0)
                root.Right = DeleteNode(root.Right, key);

            // if key is same as root's key, then this is the node to be deleted
            else
            {

                // node with only one child or no child
                if ((root.Left == null) || (root.Right == null))
                {
                    Node<T> temp = null;
                    if (temp == root.Left)
                        temp = root.Right;
                    else
                        temp = root.Left;

                    // No child case
                    if (temp == null)
                    {
                        temp = root;
                        root = null;
                    }
                    else // One child case
                        root = temp; // Copy the contents of the non-empty child
                }
                else
                {
                    // node with two children: Get the inorder successor (smallest in the right subtree)
                    Node<T> temp = MinValueNode(root.Right);

                    // Copy the inorder successor's data to this node
                    root.Key = temp.Key;

                    // Delete the inorder successor
                    root.Right = DeleteNode(root.Right, temp.Key);
                }
            }

            // If the tree had only one node then return
            if (root == null)
                return root;

            // STEP 2: UPDATE HEIGHT OF THE CURRENT NODE
            root.Height = Max(Height(root.Left), Height(root.Right)) + 1;

            // STEP 3: GET THE BALANCE FACTOR OF THIS NODE (to check whether this node became unbalanced)
            int balance = GetBalance(root);

            // If this node becomes unbalanced, then there are 4 cases Left Left Case
            if (balance > 1 && GetBalance(root.Left) >= 0)
                return RightRotate(root);

            // Left Right Case
            if (balance > 1 && GetBalance(root.Left) < 0)
            {
                root.Left = LeftRotate(root.Left);
                return RightRotate(root);
            }

            // Right Right Case
            if (balance < -1 && GetBalance(root.Right) <= 0)
                return LeftRotate(root);

            // Right Left Case
            if (balance < -1 && GetBalance(root.Right) > 0)
            {
                root.Right = RightRotate(root.Right);
                return LeftRotate(root);
            }

            return root;
        }
    }
}
