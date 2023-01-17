using System.Text.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Trees;

[TestClass]
public class TreeNodeInOrderEnumeratorTest
{
    [DataTestMethod]
    [DataRow("[3,1,4,null,2]", "1,2,3,4")]
    [DataRow("[5,3,6,2,4,null,null,1]", "1,2,3,4,5,6")]
    public void Test(string treeJson, string expected)
    {
        int?[] tree = JsonSerializer.Deserialize<int?[]>(treeJson);
        TreeNode<int> root = tree.GetTree();
        var result = string.Join(",", new TreeNodeInOrderEnumerable<int>(root));
        Assert.AreEqual(expected, result);
    }
}