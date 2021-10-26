using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace TemplateNamespace
{
    [TestClass]
    public class TemplateTest
    {
        [DataTestMethod]
        [DataRow("", true)]
        public void Template_Solutions(string arg1Json, bool expected)
        {
            var arg1 = JsonConvert.DeserializeObject<int[][]>(arg1Json);
            var solution = new TemplateClass();
            var result = solution.Method(arg1);
            Assert.AreEqual(expected, result);
        }
    }

    // url
    public class TemplateClass
    {
        public bool Method(int[][] arg1)
        {
            return true;
        }
    }
}