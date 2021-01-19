using System;
using System.Collections.Generic;

namespace Task01_Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string stringToCount = Console.ReadLine();

            Dictionary<char, int> charCount = new Dictionary<char, int>();

            for (int i = 0; i <= stringToCount.Length - 1; i++)
            {
                char nextChar = stringToCount[i];
                if(nextChar == ' ')
                {
                    continue;
                }

                if(charCount.ContainsKey(nextChar))
                {
                    charCount[nextChar]++;
                }
                else
                {
                    charCount.Add(nextChar, 1);
                }
            }

            foreach (var item in charCount)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
