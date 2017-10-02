using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PeriodicTable
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var uniqueElements = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                var currenCompound = Console.ReadLine()
                    .Split(' ');

                foreach (var element in currenCompound)
                {
                    uniqueElements.Add(element);
                }
                
            }

            foreach (var element in uniqueElements)
            {
                Console.Write(element + " ");
            }
        }
    }
}
