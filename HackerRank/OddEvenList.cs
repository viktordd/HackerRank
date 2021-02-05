using System;

namespace HackerRank
{
    class HackerRank_Program
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
        public static ListNode OddEvenList(ListNode head)
        {
            ListNode oddDummy = new ListNode(0);
            ListNode currOdd = oddDummy;
            ListNode evenDummy = new ListNode(0);
            ListNode currEven = evenDummy;

            bool IsOdd = true;

            while (head != null)
            {
                if (IsOdd)
                {
                    currOdd.next = head;
                    currOdd = head;
                }
                else
                {
                    currEven.next = head;
                    currEven = head;
                }

                head = head.next;
                IsOdd = !IsOdd;
            }

            // connect even to end of odd
            currOdd.next = evenDummy.next;

            return oddDummy.next;
        }

        static void HackerRank_Main(string[] args)
        {
            ListNode node1 = new ListNode(1);
            node1.next = new ListNode(2);
            node1.next.next = new ListNode(3);
            node1.next.next.next = new ListNode(4);
            node1.next.next.next.next = new ListNode(5);

            OddEvenList(node1);
        }
    }
}
