using System;
using System.Linq;
using System.Collections.Generic;

namespace Task04_Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> orders = new Dictionary<string, List<double>>();

            while (true)
            {
                string[] nextComand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                if(nextComand[0].ToUpper() == "BUY")
                {
                    break;
                }

                string nextProduct = nextComand[0];
                double nextPrice = double.Parse(nextComand[1]);
                double nextQuantyty = double.Parse(nextComand[2]);

                if(orders.ContainsKey(nextProduct))
                {
                    orders[nextProduct][1] += nextQuantyty;
                    orders[nextProduct][0] = nextPrice;

                }
                else
                {
                    orders.Add(nextProduct, new List<double> { nextPrice, nextQuantyty});

                }
            }


            foreach (var item in orders)
            {
                Console.WriteLine($"{item.Key} -> {item.Value[0] * item.Value[1]:f2}");
            }
        }
    }
}
