using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace LeetCode
{
    [TestClass]
    public class Template1
    {

        [TestMethod]
        public void Template1_Solutions()
        {
            var o = RawStringToNormalizedJson("{\"company_name\":\"PayScale, Inc.\",\"offices\":[{\"office\":\"Seattle\",\"employees\":[{\"employee_name\":\"Adam Deringer\",\"company_name\":\"PayScale, Inc.\",\"started_at\":\"2010-05-21T17:00:00.000Z\"}]}]}");

            Assert.AreEqual(
                "[{\"company_name\":\"PayScale, Inc.\",\"employee_name\":\"Adam Deringer\",\"started_at\":\"2010-05-21T17:00:00.000Z\"},{\"company_name\":\"PayScale, Inc.\",\"employee_name\":\"Robert Zipkin\",\"started_at\":\"2016-06-14T17:00:00.000Z\"}]",
                o);
        }

        /*
        * Complete the RawStringToNormalizedJson function below.
        */
        static string RawStringToNormalizedJson(string rawString)
        {
            /*
             * Write your code here.
             */

            IEnumerable<Employee> employees = Enumerable.Empty<Employee>();

            var token = JToken.Parse(rawString);

            if (token is JArray)
            {
                employees = token.ToObject<List<Employee>>();
            }
            else if (token is JObject)
            {
                var obj = token as JObject;

                var company = token.ToObject<Company>();
                IEnumerable<Employee> companyEmployees = company.Employees;

                companyEmployees = FindEmployees(obj, companyEmployees);

                if (company.Offices?.Count > 0)
                {
                    companyEmployees = company.Offices.SelectMany(o => o.Employees);
                }

                employees = companyEmployees
                    .Select(e => new Employee
                    {
                        CompanyName = company.CompanyName,
                        EmployeeName = e.EmployeeName,
                        StartedAt = e.StartedAt
                    });
            }

            employees = employees
                .Select(e => {
                    if (!DateTime.TryParse(e.StartedAt, out DateTime date))
                        e.StartedAtValid = false;
                    return e;
                })
                .OrderBy(e => e.EmployeeName);

            var settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;

            return JsonConvert.SerializeObject(employees.OrderBy(e => e.EmployeeName), Formatting.None, settings);
        }

        private static IEnumerable<string> FindEmployees(JObject obj, IEnumerable<string> companyEmployees)
        {
            const string employees = "employees";

            if (obj.ContainsKey(employees))
            {
                obj[employees].ToObject<List<Employee>>();
                return new[] {employees};
            }
            else
            {
                var arr = obj.Properties().Where(p => p.Value.Type == JTokenType.Array);
            }

            return companyEmployees;
        }

        public class Company
        {
            [JsonProperty("company_name")]
            public string CompanyName { get; set; }

            [JsonProperty("offices")]
            public List<Office> Offices { get; set; }

            [JsonProperty("employees")]
            public List<Employee> Employees { get; set; }
        }

        public class Office
        {
            [JsonProperty("office")]
            public string OfficeName { get; set; }

            [JsonProperty("employees")]
            public List<Employee> Employees { get; set; }
        }

        public class Employee
        {
            [JsonProperty("company_name")]
            public string CompanyName { get; set; }

            [JsonProperty("employee_name")]
            public string EmployeeName { get; set; }

            [JsonProperty("started_at")]
            public string StartedAt { get; set; }

            [JsonProperty("started_at_valid")]
            public bool? StartedAtValid { get; set; }
        }
    }
}
