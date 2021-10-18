using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode
{
    [TestClass]
    public class TemplateTest
    {
        [DataTestMethod]
        [DataRow(true)]
        public void Template_Solutions(bool expected)
        {
            var solution = new TemplateClass();
            var result = solution.Method();
            Assert.AreEqual(expected, result);
        }
    }

    public class TemplateClass
    {
        public bool Method()
        {
            return true;
        }
    }
}