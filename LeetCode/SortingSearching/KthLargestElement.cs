using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.SortingSearching
{
    [TestClass]
    public class KthLargestElement
    {
        [TestMethod]
        public void KthLargestElement_Solutions()
        {
        }


        public int FindKthLargest(int[] nums, int k)
        {
            shuffle(nums);
            k = nums.Length - k;
            int lo = 0;
            int hi = nums.Length - 1;
            while (lo < hi)
            {
                int j = partition(nums, lo, hi);
                if (j < k)
                    lo = j + 1;
                else if (j > k)
                    hi = j - 1;
                else
                    break;
            }
            return nums[k];
        }
        private void shuffle(int[] nums)
        {

            Random random = new Random();
            for (int ind = 1; ind < nums.Length; ind++)
            {
                int r = random.Next(ind + 1);
                exch(nums, ind, r);
            }
        }

        private int partition(int[] nums, int lo, int hi)
        {

            int i = lo;
            int j = hi + 1;
            while (true)
            {
                while (i < hi && nums[++i] < nums[lo]) { }
                while (j > lo && nums[--j] > nums[lo]) { }

                if (i >= j)
                    break;
                exch(nums, i, j);
            }
            exch(nums, lo, j);
            return j;
        }

        private void exch(int[] nums, int i, int j)
        {
            int tmp = nums[i];
            nums[i] = nums[j];
            nums[j] = tmp;
        }

        //     public int FindKthLargest(int[] nums, int k) {
        //         // Array.Sort(nums);
        //         // return nums[nums.Length - k];
        //         int n = nums.Length;
        //         return quickSelect(nums, 0, n - 1, n - k + 1);
        //     }

        //     public int quickSelect(int[] nums, int lo, int hi, int k){
        //         int i = lo, j = hi, pivot = nums[hi];
        //         while(i < j){
        //             if (nums[i++] > pivot) swap(nums, --i, --j);
        //         }
        //         swap(nums, i, hi);

        //         int l = i - lo + 1;

        //         if (l == k)
        //             return nums[i];
        //         else if (l > k)
        //             return quickSelect(nums, lo, i - 1, k);
        //         else
        //             return quickSelect(nums, i + 1, hi, k - l);
        //     }

        //     void swap(int[] nums, int i, int j)
        //     {
        //         int tmp = nums[i];
        //         nums[i] = nums[j];
        //         nums[j] = tmp;
        //     }
    }
}
