using System.Collections.Generic;

namespace HackerRank.DataStructures.LinkedLists
{
    public class CycleDetection
    {
        /*
          Detect a cycle in a linked list. Note that the head pointer may be 'NULL' if the list is empty.
        */

        public class Node
        {
            public int Data { get; set; }
            public Node Next { get; set; }
        }

        public static bool HasCycle(Node head)
        {
            // Complete this function
            // Do not write the main method

            HashSet<Node> nodes = new HashSet<Node>();

            var curr = head;
            while (curr != null)
            {
                if (!nodes.Add(curr))
                    return true;
                curr = curr.Next;
            }

            return false;
        }
    }
}
