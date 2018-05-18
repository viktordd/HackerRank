using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRankTest.DataStructures.LinkedLists
{
    [TestClass]
    public class CycleDetection
    {
        [TestMethod]
        public void CycleDetection_Solutions()
        {
            Assert.IsFalse(HasCycle(null));
            

            var head = new Node
            {
                Data = 1,
                Next = new Node {Data = 2}
            };
            Assert.IsFalse(HasCycle(head));
            

            head = new Node {Data = 1};
            head.Next = new Node {Data = 1, Next = head};
            Assert.IsTrue(HasCycle(head));
        }
        /*
          Detect a cycle in a linked list. Note that the head pointer may be 'NULL' if the list is empty.
        */

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

        public class Node
        {
            public int Data { get; set; }
            public Node Next { get; set; }
        }
    }
}
