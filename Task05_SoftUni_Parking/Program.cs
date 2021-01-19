using System;
using System.Linq;
using System.Collections.Generic;

namespace Task05_SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersOfComands = int.Parse(Console.ReadLine());

            Dictionary<string, string> parkingValidation = new Dictionary<string, string>();

            for (int i = 1; i <= numbersOfComands; i++)
            {
                string[] nextData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                // nextData[o] -> Type Comand
                // nextData[1] -> User /Key/
                // nextData[2] -> License Number /Value/

                switch (nextData[0].ToLower())
                {
                    case "register":
                        if(parkingValidation.ContainsKey(nextData[1]))
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {parkingValidation[nextData[1]]}");
                        }
                        else
                        {
                            parkingValidation.Add(nextData[1], nextData[2]);
                            Console.WriteLine($"{nextData[1]} registered {parkingValidation[nextData[1]]} successfully");
                        }
                        break;

                    case "unregister":
                        if (parkingValidation.ContainsKey(nextData[1]))
                        {
                            parkingValidation.Remove(nextData[1]);
                            Console.WriteLine($"{nextData[1]} unregistered successfully");
                        }
                        else
                        {
                            Console.WriteLine($"ERROR: user {nextData[1]} not found ");
                        }
                        break;
                }

            }

            foreach (var item in parkingValidation)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
