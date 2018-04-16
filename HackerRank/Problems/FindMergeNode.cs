using System.Collections.Generic;

namespace HackerRank
{
    public class FindMergeNodes
    {
        /*
         Find merge point of two linked lists head pointer input could be NULL as well for empty list
        */

        public class Node
        {
            public int Data { get; set; }
            public Node Next { get; set; }
        }

        public static int FindMergeNode(Node headA, Node headB)
        {
            // Complete this function
            // Do not write the main method

            HashSet<Node> nodes = new HashSet<Node>();

            var currA = headA;
            var currB = headB;

            while (currA != null && currB != null)
            {
                if (!nodes.Add(currA))
                    return currA.Data;
                currA = currA.Next;

                if (!nodes.Add(currB))
                    return currB.Data;
                currB = currB.Next;
            }

            while (currA != null)
            {
                if (!nodes.Add(currA))
                    return currA.Data;
                currA = currA.Next;
            }

            while (currB != null)
            {
                if (!nodes.Add(currB))
                    return currB.Data;
                currB = currB.Next;
            }

            return -1;
        }
    }
}
