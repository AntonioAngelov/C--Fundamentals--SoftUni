using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.CountSameValuesInArray
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            SortedDictionary<double, int> occurrences = new SortedDictionary<double, int>();

            foreach (var number in input)
            {
                if (!occurrences.ContainsKey(number))
                {
                    occurrences.Add(number, 1);
                }
                else
                {
                    occurrences[number]++;
                }
            }

            foreach (var key in occurrences.Keys)
            {
                Console.WriteLine($"{key} - {occurrences[key]} times");
            }

        }
    }
}
