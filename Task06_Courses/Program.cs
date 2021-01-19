using System;
using System.Linq;
using System.Collections.Generic;

namespace Task06_Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> corsesInfo = new Dictionary<string, List<string>>();

            while (true)
            {
                string[] nextData = Console.ReadLine().Split(" : ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if(nextData[0].ToLower() == "end")
                {
                    break;
                }

                // nextData[0] -> course name /Key/
                // nextData[1] -> student name /next value in List/

                if(corsesInfo.ContainsKey(nextData[0]))
                {
                    corsesInfo[nextData[0]].Add(nextData[1]);
                }
                else
                {
                    corsesInfo.Add(nextData[0], new List<string> { nextData[1] });
                }
            }

            foreach (var item in corsesInfo.OrderByDescending(x => x.Value.Count()))
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");
                foreach (var listInItem in item.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {listInItem}");
                }
            }
        }
    }
}
