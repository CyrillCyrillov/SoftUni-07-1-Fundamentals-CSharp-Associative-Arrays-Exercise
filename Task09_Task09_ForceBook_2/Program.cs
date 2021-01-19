using System;
using System.Linq;
using System.Collections.Generic;

namespace Task09_Task09_ForceBook_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> forceBook = new Dictionary<string, string>();
            string[] nextComand = new string[3];

            while (true)
            {
                string rawComand = Console.ReadLine();

                if (rawComand.ToLower() == "lumpawaroo")
                {
                    break;
                }

                if(rawComand.Contains("|"))
                {
                    nextComand = rawComand.Split(" | ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    
                    // nextComand[0] -> forceSide /Value/
                    // nextComand[1] -> forceUser /Key/

                    if(!forceBook.ContainsKey(nextComand[1]))
                    {
                        forceBook.Add(nextComand[1], nextComand[0]);
                    }
                }

                
                if(rawComand.Contains("->"))
                {
                    nextComand = rawComand.Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                  
                    // nextComand[1] -> forceSide /Value/
                    // nextComand[0] -> forceUser /Key/

                    if(forceBook.ContainsKey(nextComand[0]))
                    {
                        forceBook[nextComand[0]] = nextComand[1];
                    }
                    else
                    {
                        forceBook.Add(nextComand[0], nextComand[1]);
                    }

                    Console.WriteLine($"{nextComand[0]} joins the {nextComand[1]} side!");
                }

            }

            foreach (var item in forceBook.GroupBy(x => x.Value).OrderByDescending(x => x.Count()).ThenBy(x =>x.Key))
            {
                Console.WriteLine($"Side: {item.Key}, Members: {item.Count()}");
                foreach (var name in item.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"! {name.Key}");
                }
            }


            /*
            foreach (var item in forceBook.Where(x => x.Value.Count > 0).OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine($"Side: {item.Key}, Members: {item.Value.Count}");
                foreach (var user in item.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"! {user}");
                }
            }
            */
        }
    }
}
