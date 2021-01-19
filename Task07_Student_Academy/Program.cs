using System;
using System.Linq;
using System.Collections.Generic;

namespace Task07_Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> studentsGradeData = new Dictionary<string, List<double>>();

            for (int i = 1; i <= number; i++)
            {
                string nextName = Console.ReadLine();
                double nextGrade = double.Parse(Console.ReadLine());

                if(studentsGradeData.ContainsKey(nextName))
                {
                    studentsGradeData[nextName].Add(nextGrade);
                }
                else
                {
                    studentsGradeData.Add(nextName, new List<double> { nextGrade });
                }
            }

            foreach (var item in studentsGradeData.Where(x => x.Value.Average() >= 4.50).OrderByDescending(x => x.Value.Average()))
            {
                Console.WriteLine($"{item.Key} -> {item.Value.Average():f2}");
            }

            /*
            foreach (var item in studentsGradeData.OrderByDescending(x => x.Value.Average()))
            {
                if(item.Value.Average() >= 4.50)
                {
                    Console.WriteLine($"{item.Key} -> {item.Value.Average():f2}");
                }
            }
            */
        }
    }
}