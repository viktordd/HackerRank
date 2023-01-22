using System.Text.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TemplateNamespace;

[TestClass]
public class Template_Test
{
    [DataTestMethod]
    [DataRow("[]", true)]
    public void Template_Solutions(string arg1Json, bool expected)
    {
        var arg1 = JsonSerializer.Deserialize<int[][]>(arg1Json);
        var solution = new Template();
        var result = solution.Method(arg1);
        Assert.AreEqual(expected, result);
    }
}

// url
public class Template
{
    public bool Method(int[][] arg1)
    {
        return true;
    }
}