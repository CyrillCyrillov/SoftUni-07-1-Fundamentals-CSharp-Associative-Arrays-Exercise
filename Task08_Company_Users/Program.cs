using System;
using System.Linq;
using System.Collections.Generic;

namespace Task08_Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companysEmployees = new Dictionary<string, List<string>>();

            while (true)
            {
                string[] nextData = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (nextData[0].ToLower() == "end")
                {
                    break;
                }

                // nextData[0] -> Company /Key/
                // nextData[1] -> ID /Value/

                if (!(companysEmployees.ContainsKey(nextData[0])))
                {
                    companysEmployees.Add(nextData[0], new List<string> { nextData[1] });
                }

                if (!(companysEmployees[nextData[0]].Contains(nextData[1])))
                {
                    companysEmployees[nextData[0]].Add(nextData[1]);
                }

            }

            foreach (var company in companysEmployees.OrderBy(x => x.Key))
            {
                Console.WriteLine(company.Key);
                foreach (var id in company.Value) //.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {id}");
                }
            }
        }
    }
}
