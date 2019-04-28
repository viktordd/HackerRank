using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode
{
    [TestClass]
    public class MovingAverageFromDataStream
    {
        #region Tests

        [TestMethod]
        public void MovingAverageFromDataStream_Solutions()
        {
            MovingAverage m = new MovingAverage(3);
            Assert.AreEqual(1, m.Next(1));
            Assert.AreEqual((1 + 10) / 2.0, m.Next(10));
            Assert.AreEqual((1 + 10 + 3) / 3.0, m.Next(3));
            Assert.AreEqual((10 + 3 + 5) / 3.0, m.Next(5));
        }

        #endregion

        public class MovingAverage
        {
            private readonly int[] vals;
            private int count;
            private int last;
            private double sum;

            /** Initialize your data structure here. */
            public MovingAverage(int size)
            {
                vals = new int[size];
                count = 0;
                last = 0;
                sum = 0;
            }

            public double Next(int val)
            {
                sum = sum - vals[last] + val;
                vals[last] = val;
                last = (last + 1) % vals.Length;
                if (count < vals.Length)
                    count++;
                return sum / count;
            }
        }
    }
}
