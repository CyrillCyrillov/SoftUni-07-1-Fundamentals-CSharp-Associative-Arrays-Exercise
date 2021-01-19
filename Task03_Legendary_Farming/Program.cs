using System;
using System.Linq;
using System.Collections.Generic;

namespace Task03_Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> keyMaterials = new Dictionary<string, int>();
            keyMaterials["shards"] = 0;
            keyMaterials["fragments"] = 0;
            keyMaterials["motes"] = 0;

            Dictionary<string, int> junk = new Dictionary<string, int>();

            while (keyMaterials["shards"] < 250 && keyMaterials["fragments"] < 250 && keyMaterials["motes"] < 250) ///// mayby TRUE
            {
                string[] nextMaterials = Console.ReadLine().ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                bool isNeedExit = false;
                for (int i = 0; i <= nextMaterials.Length - 1; i = i + 2)
                {
                    if(isNeedExit)
                    {
                        break;
                    }
                    
                    int quantyty = int.Parse(nextMaterials[i]);
                    string material = nextMaterials[i + 1];

                    switch (material)
                    {
                        case "shards":
                            keyMaterials["shards"] += quantyty;
                            if(keyMaterials["shards"] >= 250)
                            {
                                isNeedExit = true;
                                break;
                            }
                            break;

                        case "fragments":
                            keyMaterials["fragments"] += quantyty;
                            if (keyMaterials["fragments"] >= 250)
                            {

                                isNeedExit = true;
                                break;
                            }
                            break;

                        case "motes":
                            keyMaterials["motes"] += quantyty;
                            if (keyMaterials["motes"] >= 250)
                            {
                                isNeedExit = true;
                                break;
                            }
                            break;

                        default:

                            if(junk.ContainsKey(material))
                            {
                                junk[material] += quantyty;
                            }
                            else
                            {
                                junk.Add(material, quantyty);
                            }
                            break;
                    }
                }

                // EXIT!!!!!
            }


            string winer = keyMaterials.OrderByDescending(x => x.Value).FirstOrDefault().Key;
            keyMaterials[winer] -= 250;
            
            switch (winer)
            {
                case "shards":
                    winer = "Shadowmourne";
                    break;

                case "fragments":
                    winer = "Valanyr";
                    break;

                case "motes":
                    winer = "Dragonwrath";
                    break;
            }

            Dictionary<string, int> sortedKeyMaterials = keyMaterials.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            Dictionary<string, int> sortedJunk = junk.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);


            Console.WriteLine($"{winer} obtained!");

            foreach (var item in sortedKeyMaterials)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            foreach (var item in sortedJunk)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            // Console.WriteLine("Hello World!");
        }
    }
}
