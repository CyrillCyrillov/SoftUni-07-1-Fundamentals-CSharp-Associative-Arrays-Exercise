using System;
using System.Linq;
using System.Collections.Generic;

namespace Task10_SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> studentsResults = new Dictionary<string, List<int>>();

            Dictionary<string, int> languageStat = new Dictionary<string, int>();

            while (true)
            {
                string[] nextData = Console.ReadLine().Split('-', StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (nextData[0].ToLower() == "exam finished")
                {
                    break;
                }

                if (nextData[1].ToLower() == "banned")
                {
                    if(studentsResults.ContainsKey(nextData[0]))
                    {
                        studentsResults.Remove(nextData[0]);
                    }

                }
                else
                {
                    string nextStudent = nextData[0];
                    string nextLanguage = nextData[1];
                    int nextPoitns = int.Parse(nextData[2]);

                    if (studentsResults.ContainsKey(nextStudent))
                    {
                        studentsResults[nextStudent].Add(nextPoitns);
                    }
                    else
                    {
                        studentsResults.Add(nextStudent, new List<int> { nextPoitns });
                    }

                    if (languageStat.ContainsKey(nextLanguage))
                    {
                        languageStat[nextLanguage]++;
                    }
                    else
                    {
                        languageStat.Add(nextLanguage, 1);
                    }
                }
            }

            Console.WriteLine("Results:");
            foreach (var student in studentsResults.OrderByDescending(x => x.Value.Max()).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{student.Key} | {student.Value.Max()}");
            }

            Console.WriteLine("Submissions:");
            foreach (var item in languageStat.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
}
