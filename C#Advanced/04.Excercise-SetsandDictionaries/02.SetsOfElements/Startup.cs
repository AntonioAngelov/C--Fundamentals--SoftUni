using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            var set1 = new SortedSet<double>();
            var set2 = new SortedSet<double>();

            if (input[0] == 0 || input[1] == 0)
            {
                return;
            }

            for (int i = 0; i < input[0]; i++)
            {
                set1.Add(double.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < input[1]; i++)
            {
                set2.Add(double.Parse(Console.ReadLine()));
            }


            if (set1.First() > set2.Last() || set1.Last() < set2.First())
            {
                    return;
            }
            if (set1.Count <= set2.Count)
            {
                GetCommonElements(set1, set2);
            }
            else
            {
                GetCommonElements(set2, set1);
            }



        }

        public static void GetCommonElements(SortedSet<double> set1, SortedSet<double> set2)
        {
            
            foreach (var el1 in set1)
            {
                foreach (var el2 in set2)
                {
                    if (el1 == el2)
                    {
                        Console.Write(el1.ToString() + " ");
                    }
                }
            }
            Console.WriteLine();


        }
    }
}
