using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.LinkedLists
{
    [TestClass]
    public class IntersectionOfTwoLinkedLists
    {
        #region Tests
        [TestMethod]
        public void GetIntersectionNode_Solution_3()
        {
            var mergeAt = new ListNode(3);
            var headA = new ListNode(1)
            {
                next = mergeAt
            };
            var headB = new ListNode(2)
            {
                next = mergeAt
            };
            var result = GetIntersectionNode(headA, headB);
            Assert.AreEqual(mergeAt, result);
        }

        [TestMethod]
        public void GetIntersectionNode_Solution_4()
        {
            var mergeAt = new ListNode(4);
            var headA = new ListNode(1)
            {
                next = new ListNode(3)
                {
                    next = mergeAt
                }
            };
            var headB = new ListNode(2)
            {
                next = mergeAt
            };
            var result = GetIntersectionNode(headA, headB);
            Assert.AreEqual(mergeAt, result);
        }

        [TestMethod]
        public void GetIntersectionNode_Solution_5()
        {
            var mergeAt = new ListNode(5);
            var headA = new ListNode(1)
            {
                next = mergeAt
            };
            var headB = new ListNode(2)
            {
                next = new ListNode(3)
                {
                    next = mergeAt
                }
            };
            var result = GetIntersectionNode(headA, headB);
            Assert.AreEqual(mergeAt, result);
        }
        #endregion

        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            if (headA == null || headB == null)
                return null;

            ListNode last = null;
            
            var a = headA;
            var b = headB;

            while (true)
            {
                if (a == b)
                    return a;

                if (a.next != null)
                    a = a.next;
                else
                {
                    if (last == null)
                        last = a;
                    else if (last != a)
                        return null;

                    a = headB;
                }

                if (b.next != null)
                    b = b.next;
                else
                {
                    if (last == null)
                        last = b;
                    else if (last != b)
                        return null;

                    b = headA;
                }
            }
        }

        public ListNode GetIntersectionNode1(ListNode headA, ListNode headB)
        {
            if (headA == null || headB == null)
                return null;

            var lA = GetLength(headA);
            var lB = GetLength(headB);

            var longer = lA > lB ? headA : headB;
            var shorter = longer == headA ? headB : headA;

            var diff = Math.Abs(lA - lB);
            for (int i = 0; i < diff; i++)
            {
                longer = longer.next;
            }

            while (longer != null && shorter != null)
            {
                if (longer == shorter)
                    return longer;

                longer = longer.next;
                shorter = shorter.next;
            }

            return null;
        }

        public int GetLength(ListNode node)
        {
            var count = 0;
            while (node != null)
            {
                node = node.next;
                count++;
            }
            return count;
        }
    }
}
