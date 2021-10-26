using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    public class ListNode : IEnumerable<int>
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }

        public static ListNode Parse(string s)
        {
            var items = s.Split(new[] { ",", "->", " " }, StringSplitOptions.RemoveEmptyEntries);

            var head = new ListNode();
            items.Aggregate(head, (curr, item) => (curr.next = new ListNode(Convert.ToInt32(item))));

            return head.next;
        }

        public override string ToString()
        {
            return this.ToString(" -> ");
        }

        public string ToString(string separator)
        {
            return string.Join(separator, this);
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new ListNodeEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
