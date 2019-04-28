using System.Collections;
using System.Collections.Generic;

namespace LeetCode
{
    public class ListNodeEnumerator : IEnumerator<int>
    {
        private readonly ListNode head = new ListNode();
        private ListNode current;

        public ListNodeEnumerator(ListNode h)
        {
            head.next = h;
            current = head;
        }

        public void Dispose() { }

        public bool MoveNext()
        {
            current = current?.next;
            return current != null;
        }

        public void Reset()
        {
            current = head;
        }

        public int Current => current.val;

        object IEnumerator.Current => Current;
    }

}
