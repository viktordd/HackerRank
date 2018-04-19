using HackerRank.DataStructures.LinkedLists;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRankTest.DataStructures.LinkedLists
{
    [TestClass]
    public class FindMergeNodesTest
    {
        [TestMethod]
        public void FindMergeNode_3()
        {
            var mergeAt = new FindMergeNodes.Node { Data = 3 };
            var headA = new FindMergeNodes.Node
            {
                Data = 1,
                Next = mergeAt
            };
            var headB = new FindMergeNodes.Node
            {
                Data = 2,
                Next = mergeAt
            };
            var result = FindMergeNodes.FindMergeNode(headA, headB);
            Assert.AreEqual(mergeAt.Data, result);
        }

        [TestMethod]
        public void FindMergeNode_4()
        {
            var mergeAt = new FindMergeNodes.Node { Data = 4 };
            var headA = new FindMergeNodes.Node
            {
                Data = 1,
                Next = new FindMergeNodes.Node
                {
                    Data = 3,
                    Next = mergeAt
                }
            };
            var headB = new FindMergeNodes.Node
            {
                Data = 2,
                Next = mergeAt
            };
            var result = FindMergeNodes.FindMergeNode(headA, headB);
            Assert.AreEqual(mergeAt.Data, result);
        }

        [TestMethod]
        public void FindMergeNode_5()
        {
            var mergeAt = new FindMergeNodes.Node { Data = 5 };
            var headA = new FindMergeNodes.Node
            {
                Data = 1,
                Next = mergeAt
            };
            var headB = new FindMergeNodes.Node
            {
                Data = 2,
                Next = new FindMergeNodes.Node
                {
                    Data = 3,
                    Next = mergeAt
                }
            };
            var result = FindMergeNodes.FindMergeNode(headA, headB);
            Assert.AreEqual(mergeAt.Data, result);
        }
    }
}
