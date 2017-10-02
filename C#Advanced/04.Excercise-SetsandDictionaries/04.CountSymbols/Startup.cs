using System;
using System.Collections.Generic;

namespace _04.CountSymbols
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var occurrences = new SortedDictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!occurrences.ContainsKey(input[i]))
                {
                    occurrences.Add(input[i], 1);
                }
                else
                {
                    occurrences[input[i]] += 1;
                }
            }

            foreach (var character in occurrences.Keys)
            {
                Console.WriteLine($"{character}: {occurrences[character]} time/s");
            }
        }
    }
}
