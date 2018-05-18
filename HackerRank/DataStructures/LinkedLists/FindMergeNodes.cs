using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRankTest.DataStructures.LinkedLists
{
    [TestClass]
    public class FindMergeNodes
    {
        #region Tests
        [TestMethod]
        public void FindMergeNode_Solution_3()
        {
            var mergeAt = new Node { Data = 3 };
            var headA = new Node
            {
                Data = 1,
                Next = mergeAt
            };
            var headB = new Node
            {
                Data = 2,
                Next = mergeAt
            };
            var result = FindMergeNode(headA, headB);
            Assert.AreEqual(mergeAt.Data, result);
        }

        [TestMethod]
        public void FindMergeNode_Solution_4()
        {
            var mergeAt = new Node { Data = 4 };
            var headA = new Node
            {
                Data = 1,
                Next = new Node
                {
                    Data = 3,
                    Next = mergeAt
                }
            };
            var headB = new Node
            {
                Data = 2,
                Next = mergeAt
            };
            var result = FindMergeNode(headA, headB);
            Assert.AreEqual(mergeAt.Data, result);
        }

        [TestMethod]
        public void FindMergeNode_Solution_5()
        {
            var mergeAt = new Node { Data = 5 };
            var headA = new Node
            {
                Data = 1,
                Next = mergeAt
            };
            var headB = new Node
            {
                Data = 2,
                Next = new Node
                {
                    Data = 3,
                    Next = mergeAt
                }
            };
            var result = FindMergeNode(headA, headB);
            Assert.AreEqual(mergeAt.Data, result);
        }
        #endregion

        /*
         Find merge point of two linked lists head pointer input could be NULL as well for empty list
        */
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

        public class Node
        {
            public int Data { get; set; }
            public Node Next { get; set; }
        }
    }
}
