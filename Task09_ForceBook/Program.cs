using System;
using System.Linq;
using System.Collections.Generic;

namespace Task09_ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> forceBook = new Dictionary<string, List<string>>();

            while (true)
            {
                string[] nextComand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (nextComand[0].ToLower() == "lumpawaroo")
                {
                    break;
                }
                if(nextComand.Length > 3)
                {
                    // united element defor and after "|" or "->"
                    int breakIndex = -1;
                    for (int i = 1; i <= nextComand.Length - 1; i++)
                    {
                        if(nextComand[i] == "|" || nextComand[i] == "->")
                        {
                            nextComand[1] = nextComand[i];
                            breakIndex = i;
                            break;
                        }

                        nextComand[0] = nextComand[0] + " " + (nextComand[i]);
                    }

                    nextComand[2] = nextComand[breakIndex + 1];
                    if(nextComand.Length - breakIndex > 2)
                    {
                        for (int i = breakIndex + 2; i <= nextComand.Length - 1; i++)
                        {
                            nextComand[2] = nextComand[2] + " " + nextComand[i];
                        }
                    }
                }


                if (nextComand[1] == "|")
                {
                    //Console.WriteLine("|");
                    // nextComand[0] -> forceSide /Key/
                    // nextComand[2] -> forceUser /Value/

                    bool isUserExists = false;

                    foreach (List<string> user in forceBook.Values)
                    {
                        if (user.Contains(nextComand[2]))
                        {
                            isUserExists = true;
                        }
                    }

                    if (isUserExists == false)
                    {
                        if (forceBook.ContainsKey(nextComand[0]))
                        {
                            forceBook[nextComand[0]].Add(nextComand[2]);
                        }
                        else
                        {
                            forceBook.Add(nextComand[0], new List<string> { nextComand[2] });
                        }


                    }


                }

                else
                {
                    //Console.WriteLine("->");
                    // nextComand[2] -> forceSide /Key/
                    // nextComand[0] -> forceUser /Value/

                    bool isUserExists = false;
                    string keyOfExistsUser = string.Empty;

                    foreach (List<string> user in forceBook.Values)
                    {
                        if (user.Contains(nextComand[0]))
                        {
                            isUserExists = true;
                            keyOfExistsUser = forceBook.FirstOrDefault(x => x.Value.Contains(nextComand[0])).Key;
                        }
                    }

                    if (isUserExists)
                    {
                        forceBook[keyOfExistsUser].Remove(nextComand[0]);
                        forceBook[nextComand[2]].Add(nextComand[0]);
                        Console.WriteLine($"{nextComand[0]} joins the {nextComand[2]} side!");
                    }

                    else
                    {
                        if (forceBook.ContainsKey(nextComand[2]))
                        {
                            forceBook[nextComand[2]].Add(nextComand[0]);
                            Console.WriteLine($"{nextComand[0]} joins the {nextComand[2]} side!");
                        }
                        else
                        {
                            forceBook.Add(nextComand[2], new List<string> { nextComand[0] });
                        }
                    }
                }



            }

            foreach (var item in forceBook.Where(x => x.Value.Count > 0).OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine($"Side: {item.Key}, Members: {item.Value.Count}");
                foreach (var user in item.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }
    }
}