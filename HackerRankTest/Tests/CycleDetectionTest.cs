using HackerRank;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRankTest
{
    [TestClass]
    public class CycleDetectionTest
    {
        [TestMethod]
        public void CycleDetection_HasCycle_null()
        {
            var head = (CycleDetection.Node) null;
            var result = CycleDetection.HasCycle(head);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CycleDetection_HasCycle_noCycle()
        {
            var head = new CycleDetection.Node
            {
                Data = 1,
                Next = new CycleDetection.Node {Data = 2}
            };
            var result = CycleDetection.HasCycle(head);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CycleDetection_HasCycle_hasCycle()
        {
            var head = new CycleDetection.Node {Data = 1};
            head.Next = new CycleDetection.Node {Data = 1, Next = head};
            var result = CycleDetection.HasCycle(head);
            Assert.IsTrue(result);
        }
    }
}
