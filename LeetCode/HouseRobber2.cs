using System;
using System.Text.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode;

[TestClass]
public class HouseRobber2_Test
{
    [DataTestMethod]
    [DataRow("[2,3,2]", 3)]
    [DataRow("[1,2,3,1]", 4)]
    [DataRow("[1,2,3]", 3)]
    public void HouseRobber2_Solutions(string numsJson, int expected)
    {
        var nums = JsonSerializer.Deserialize<int[]>(numsJson);
        var solution = new HouseRobber2();
        var result = solution.Rob(nums);
        Assert.AreEqual(expected, result);
    }
}

// https://leetcode.com/problems/house-robber-ii/
public class HouseRobber2
{
    public int Rob(int[] nums)
    {
        if (nums.Length == 1)
            return nums[0];
        else if (nums.Length == 2)
            return Math.Max(nums[0], nums[1]);

        var numsSpan = nums.AsSpan();
        return Math.Max(rob(numsSpan[..^1]), rob(numsSpan[1..]));
    }


    private int rob(Span<int> nums)
    {
        var prev1 = 0;
        var prev2 = 0;

        // rob = max(nums[n] + rob[0:n-2], rob[0:n-1])

        // [prev2, prev1, num[i]]
        for (int i = 0; i < nums.Length; i++)
        {
            var temp = Math.Max(prev2 + nums[i], prev1);
            prev2 = prev1;
            prev1 = temp;
        }

        return prev1;
    }
}