using System.Collections.Generic;
using System.Linq;
using Helpers;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;

namespace LeetCode
{
    [TestClass]
    public class ThreeSum2
    {
        [DataTestMethod]
        [DataRow(20,
            "[[1, 8], [2, 7], [3, 14]]",
            "[[1, 5], [2, 10], [3, 14]]",
            "[[3, 1]]")]
        [DataRow(20,
            "[[1, 8], [2, 15], [3, 9]]",
            "[[1, 8], [2, 11], [3, 12]]",
            "[[1, 3], [3, 2]]")]
        public void ThreeSum_Solutions(int maxTravelDist,
                                    string forwardRouteListJson,
                                    string returnRouteListJson,
                                    string expectedJson)
        {

            // started with brute force solution:
            // check all posible

            // optimize by sorting

            var forwardRouteList = JsonConvert.DeserializeObject<List<List<int>>>(forwardRouteListJson);
            var returnRouteList = JsonConvert.DeserializeObject<List<List<int>>>(returnRouteListJson);
            var expected = JsonConvert.DeserializeObject<List<List<int>>>(expectedJson);

            var result = optimalUtilization(maxTravelDist, forwardRouteList, returnRouteList);

            AssertEnumerable.AreEqual2DimArrays(expected, result);
        }


        public List<List<int>> optimalUtilization(int maxTravelDist,
                                    List<List<int>> forwardRouteList,
                                    List<List<int>> returnRouteList)
        {
            // WRITE YOUR CODE HERE

            var currMax = 0;
            var result = new List<List<int>>();

            forwardRouteList = forwardRouteList
                .OrderBy(i => i[1])
                .ToList();
            returnRouteList = returnRouteList
                .OrderBy(i => i[1])
                .ToList();

            foreach (var f in forwardRouteList)
            {


                foreach (var r in returnRouteList)
                {
                    var total = f[1] + r[1];

                    if (total > maxTravelDist)
                        break;

                    if (total == currMax)
                    {
                        result.Add(new List<int>(new[] { f[0], r[0] }));
                    }
                    else if (total > currMax && total <= maxTravelDist)
                    {
                        currMax = total;
                        result = new List<List<int>>();
                        result.Add(new List<int>(new[] { f[0], r[0] }));
                    }
                }
            }

            return result;
        }



        // METHOD SIGNATURE BEGINS, THIS METHOD IS REQUIRED
        public List<List<int>> optimalUtilization1(int maxTravelDist,
                                            List<List<int>> forwardRouteList,
                                            List<List<int>> returnRouteList)
        {
            // WRITE YOUR CODE HERE
            // brute force solution try every possible combination,
            // keep track of current max distance and make sure it's less than the max travel specified.


            var currMax = 0;
            var result = new List<List<int>>();

            for (int i = 0; i < forwardRouteList.Count; i++)
            {
                for (int j = 0; j < returnRouteList.Count; j++)
                {
                    var total = forwardRouteList[i][1] + returnRouteList[j][1];

                    if (total == currMax)
                    {
                        result.Add(new List<int>(new[] { forwardRouteList[i][0], returnRouteList[j][0] }));
                    }
                    else if (total > currMax && total <= maxTravelDist)
                    {
                        currMax = total;
                        result = new List<List<int>>();
                        result.Add(new List<int>(new[] { forwardRouteList[i][0], returnRouteList[j][0] }));
                    }
                }
            }

            return result;
        }
    }
}
