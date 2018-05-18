using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRankTest.DataStructures.Stacks
{
    [TestClass]
    public class GameofTwoStacks
    {
        [TestMethod]
        public void GameofTwoStacks_Solutions()
        {
            Assert.AreEqual(4, twoStacks(10, new[] {4, 2, 4, 6, 1}, new[] {2, 1, 8, 5}));
        }


        static int twoStacks(int max, int[] a, int[] b)
        {
            int maxCount = 0, sum = 0, iA, iB;

            // take as many integers from the first stack as possible
            for (iA = 0; iA < a.Length && sum + a[iA] <= max; iA++)
                sum += a[iA];

            maxCount = iA;

            for (iB = 0; iB < b.Length && iA >= 0; )
            {
                // take the next integer from the second stack
                sum += b[iB];
                iB++;

                // while the max is exceeded remove integers from the first stack
                while (sum > max && iA > 0)
                {
                    iA--;
                    sum -= a[iA];
                }
                // set the maxCount if the current sum is less than or equal to the max and the curr count is greater than the previous max count.
                if (sum <= max && iA + iB > maxCount)
                    maxCount = iA + iB;
            }

            return maxCount;
        }
    }
}
