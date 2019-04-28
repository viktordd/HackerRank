using System.Collections.Generic;
using Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode
{
    [TestClass]
    public class SlidingWindowMaximum
    {
        #region Tests

        [TestMethod]
        public void SlidingWindowMaximum_Solutions()
        {
            //Input: nums = [1, 3, -1, -3, 5, 3, 6, 7], and k = 3
            //Output: [3, 3, 5, 5, 6, 7]

            AssertEnumerable.AreEqual(new[] {3, 3, 5, 5, 6, 7}, MaxSlidingWindow(new[] {1, 3, -1, -3, 5, 3, 6, 7}, 3));
        }

        #endregion

        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            var result = new List<int>();
            var max = new LinkedList<int>();

            for (int i = 0; i < k; i++)
            {
                while(max.Count > 0 && nums[max.First.Value] < nums[i]) max.RemoveFirst();

                max.AddFirst(new LinkedListNode<int>(i));
            }

            result.Add(nums[max.Last.Value]);

            for (int i = k; i < nums.Length; i++)
            {
                while (max.Count > 0 && nums[max.First.Value] < nums[i]) max.RemoveFirst();

                while (max.Count > 0 && max.Last.Value < i - k + 1) max.RemoveLast();

                max.AddFirst(new LinkedListNode<int>(i));

                result.Add(nums[max.Last.Value]);
            }

            return result.ToArray();
        }
    }
}
