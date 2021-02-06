using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms
{
    [TestClass]
    public class TemplateTest
    {
        [DataTestMethod]
        [DataRow(true)]
        public void Test(bool expected)
        {
            var solution = new TemplateClass();
            var result = solution.Template();
            Assert.AreEqual(expected, result);
        }
    }

    public class TemplateClass
    {
        public bool Template()
        {
            return true;
        }
    }
}