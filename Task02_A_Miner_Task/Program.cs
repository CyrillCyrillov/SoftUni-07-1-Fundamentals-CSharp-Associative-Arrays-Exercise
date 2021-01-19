using System;
using System.Linq;
using System.Collections.Generic;

namespace Task02_A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> resoursColect = new Dictionary<string, double>();

            while (true)
            {
                string nextResourse = Console.ReadLine();
                
                if(nextResourse.ToUpper() == "STOP")
                {
                    break;
                }

                double quantyty = double.Parse(Console.ReadLine());

                if(resoursColect.ContainsKey(nextResourse))
                {
                    resoursColect[nextResourse] += quantyty;
                }
                else
                {
                    resoursColect.Add(nextResourse, quantyty);
                }
            }
            
            
            foreach (var element in resoursColect)
            {
                Console.WriteLine($"{element.Key} -> {element.Value}");
            }
        }
    }
}
