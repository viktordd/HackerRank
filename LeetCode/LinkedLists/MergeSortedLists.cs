using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.LinkedLists
{
    [TestClass]
    public class MergeSortedLists
    {
        #region Tests
        [TestMethod]
        public void MergeKLists_Solution()
        {
            Assert.IsNull(MergeKLists(new[]
            {
                (ListNode)null,
                null,
            }));

            Assert.AreEqual("1 -> 1 -> 2 -> 3 -> 4 -> 4 -> 5 -> 6", MergeKLists(new[]
            {
                null,
                ListNode.Parse("1 -> 4 -> 5"),
                ListNode.Parse("1 -> 3 -> 4"),
                ListNode.Parse("2 -> 6")
            })?.ToString());
        }
        #endregion

        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0)
                return null;

            var interval = 1;
            while (interval < lists.Length)
            {
                for (int i = 0; i < lists.Length - interval; i += interval * 2)
                    lists[i] = Merge2Lists(lists[i], lists[i + interval]);
                interval *= 2;
            }
            return lists[0];
        }
        public ListNode Merge2Lists(ListNode list1, ListNode list2)
        {
            var merged = new ListNode(0);
            var curr = merged;
            
            while (list1 != null && list2 != null)
            {
                if (list1.val <= list2.val)
                {
                    curr.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    curr.next = list2;
                    list2 = list2.next;
                }

                curr = curr.next;
            }

            curr.next = list1 ?? list2;

            return merged.next;
        }

        public ListNode MergeKLists1(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0)
                return null;
            if (lists.Length == 1)
                return lists[0];

            var merged = new ListNode(0);
            var curr = merged;

            lists = lists.OrderBy(itm => itm?.val).ToArray();

            var currI = 0;
            while (true)
            {
                if (lists[currI] != null)
                {
                    curr = curr.next = lists[currI];
                    lists[currI] = curr.next;
                }

                var temp = lists[currI];
                if (temp == null)
                {
                    if (++currI < lists.Length)
                        continue;
                    break;
                }

                int i;
                for (i = currI + 1; i < lists.Length && lists[i] != null && temp.val > lists[i].val; i++)
                    lists[i - 1] = lists[i];

                lists[i - 1] = temp;
            }
            return merged.next;
        }
    }
}
