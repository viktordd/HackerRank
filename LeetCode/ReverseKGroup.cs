using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode
{
    [TestClass]
    public class ReverseKGroupTest
    {
        [DataTestMethod]
        [DataRow("1,2,3,4,5", 2, "2,1,4,3,5")]
        [DataRow("1,2,3,4,5", 3, "3,2,1,4,5")]
        [DataRow("1,2,3,4,5", 1, "1,2,3,4,5")]
        [DataRow("1", 1, "1")]
        public void ReverseKGroup_Solutions(string listString, int k, string expected)
        {
            ListNode head = ListNode.Parse(listString);

            var solution = new ReverseKGroupClass();
            var result = solution.ReverseKGroup(head, k);

            Assert.AreEqual(expected, result.ToString(","));
        }
    }

    // https://leetcode.com/problems/reverse-nodes-in-k-group/
    public class ReverseKGroupClass
    {
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            if (k == 1)
                return head;

            ListNode newHead = null;
            ListNode prev = null;
            var curr = head;

            while (curr != null)
            {
                var (first, last) = ReverseNodes(curr, k);

                if (newHead == null)
                    newHead = first;

                if (prev != null)
                    prev.next = first;

                prev = last;
                curr = last.next;
            }

            return newHead;
        }
        public (ListNode first, ListNode last) ReverseNodes(ListNode head, int n)
        {
            int i = 0;
            ListNode prev = null;
            var curr = head;

            while (curr != null && i < n)
            {
                var next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
                i++;
            }

            if (i < n)
                return ReverseNodes(prev, i);

            head.next = curr;

            return (first: prev, last: head);
        }
    }
}