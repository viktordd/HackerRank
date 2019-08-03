using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace LeetCode
{
    [TestClass]
    public class RotateRight
    {
        #region Tests
        [DataTestMethod]
        [DataRow("[1,2,3,4,5]", 0, "[1,2,3,4,5]")]
        [DataRow("[1,2,3,4,5]", 1, "[5,1,2,3,4]")]
        [DataRow("[1,2,3,4,5]", 2, "[4,5,1,2,3]")]
        [DataRow("[1,2,3,4,5]", 4, "[2,3,4,5,1]")]
        [DataRow("[1,2,3,4,5]", 5, "[1,2,3,4,5]")]
        [DataRow("[1,2,3,4,5]", 6, "[5,1,2,3,4]")]
        [DataRow("[1,2,3,4,5]", 9, "[2,3,4,5,1]")]
        [DataRow("[1,2,3,4,5]", 10, "[1,2,3,4,5]")]
        [DataRow("[1,2,3,4,5]", 11, "[5,1,2,3,4]")]
        public void RotateRight_Solutions(string input, int k, string expected)
        {
            var list = JsonConvert.DeserializeObject<int[]>(input);

            ListNode t = new ListNode(0);
            ListNode curr = t;

            foreach (var item in list)
                curr = curr.next = new ListNode(item);

            var solution = new Solution();

            var result = solution.RotateRight(t.next, k);

            List<int> r = new List<int>();
            while (result != null)
            {
                r.Add(result.val);
                result = result.next;
            }

            Assert.AreEqual(expected, JsonConvert.SerializeObject(r));
        }
        #endregion

        /**
         * Definition for singly-linked list.
         * public class ListNode {
         *     public int val;
         *     public ListNode next;
         *     public ListNode(int x) { val = x; }
         * }
         */
        public class Solution
        {
            public ListNode RotateRight(ListNode head, int k)
            {

                if (k == 0 || head == null || head.next == null)
                    return head;

                int count = 1;
                ListNode curr = head;
                while (curr.next != null)
                {
                    curr = curr.next;
                    count++;
                }

                k %= count;
                if (k == 0)
                    return head;

                k = count - k;

                ListNode last = curr;
                ListNode prev = null;
                curr = head;

                while (k > 0)
                {
                    prev = curr;
                    curr = curr.next;
                    k--;
                }

                prev.next = null;
                last.next = head;

                return curr;
            }
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }
}