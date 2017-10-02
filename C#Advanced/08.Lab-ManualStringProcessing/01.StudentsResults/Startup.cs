using System;
using System.Linq;

namespace _01.StudentsResults
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            string[][] results = new string[n][];

            for (int i = 0; i < n; i++)
            {
                results[i] = Console.ReadLine()
                    .Split(new[] {' ', '-', ','}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
            }


            Console.WriteLine(string.Format("{0,-10}|{1,7}|{2,7}|{3,7}|{4,7}|", "Name", "CAdv", "COOP", "AdvOOP", "Average"));

            foreach (var result in results)
            {
                var name = result[0];
                var cadvr = double.Parse(result[1]);
                var coop = double.Parse(result[2]);
                var advoop = double.Parse(result[3]);
                var average = (cadvr + coop + advoop) / 3;

                Console.WriteLine(string.Format("{0,-10}|{1,7:f2}|{2,7:f2}|{3,7:f2}|{4,7:f4}|", name, cadvr, coop, advoop, average));
            }
        }
    }
}
