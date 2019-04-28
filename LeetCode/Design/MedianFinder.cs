using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.Design
{
    [TestClass]
    public class MedianFinderTests
    {
        #region Tests

        [TestMethod]
        public void MedianFinder_Solutions()
        {
            var obj = new MedianFinder();

            obj.AddNum(1);
            obj.AddNum(2);
            Assert.AreEqual(1.5, obj.FindMedian());

            obj.AddNum(3);
            Assert.AreEqual(2, obj.FindMedian());
        }

        [TestMethod]
        public void MedianFinder_Solutions_2()
        {
            var obj = new MedianFinder();

            obj.AddNum(6);
            Assert.AreEqual(6.0, obj.FindMedian());

            obj.AddNum(10);
            Assert.AreEqual(8.0, obj.FindMedian());

            obj.AddNum(2);
            Assert.AreEqual(6.0, obj.FindMedian());

            obj.AddNum(6);
            Assert.AreEqual(6.0, obj.FindMedian());

            obj.AddNum(5);
            Assert.AreEqual(6.0, obj.FindMedian());

            obj.AddNum(0);
            Assert.AreEqual(5.5, obj.FindMedian());

            obj.AddNum(6);
            Assert.AreEqual(6.0, obj.FindMedian());

            obj.AddNum(3);
            Assert.AreEqual(5.5, obj.FindMedian());

            obj.AddNum(1);
            Assert.AreEqual(5.0, obj.FindMedian());

            obj.AddNum(0);
            Assert.AreEqual(4.0, obj.FindMedian());

            obj.AddNum(0);
            Assert.AreEqual(3.0, obj.FindMedian());
        }

        #endregion
    }

    public class MedianFinder
    {
        private readonly MaxHeap<int> lo;
        private readonly MinHeap<int> hi;

        public MedianFinder()
        {
            lo = new MaxHeap<int>();
            hi = new MinHeap<int>();
        }

        public void AddNum(int num)
        {
            if (lo.Count == hi.Count)
            {
                if (num < hi.Peek())
                    lo.Push(num);
                else
                    hi.Push(num);
            }

            else if (lo.Count < hi.Count)
            {
                lo.Push(num <= hi.Peek() ? num : hi.PopPush(num));
            }

            else if (lo.Count > hi.Count)
            {
                hi.Push(num >= lo.Peek() ? num : lo.PopPush(num));
            }
        }

        public double FindMedian()
        {
            return lo.Count > hi.Count
                ? lo.Peek()
                : (lo.Count < hi.Count
                    ? hi.Peek()
                    : ((long) lo.Peek() + hi.Peek()) / 2.0);
        }
    }
}

