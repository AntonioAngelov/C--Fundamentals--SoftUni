using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.JediMeditation
{
    using System.Text.RegularExpressions;

    public class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            bool yoda = false;

            StringBuilder masters = new StringBuilder();
            StringBuilder knights = new StringBuilder();
            StringBuilder padawans = new StringBuilder();
            StringBuilder toshkoAndSlav = new StringBuilder();


            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(' ')
                    .ToList();

                masters.Append(" " + string.Join(" ", input.Where(j => j.StartsWith("m"))));
                knights.Append(" " + string.Join(" ", input.Where(j => j.StartsWith("k"))));
                padawans.Append(" " + string.Join(" ", input.Where(j => j.StartsWith("p"))));
                toshkoAndSlav.Append(" " + string.Join(" ", input.Where(j => j.StartsWith("t") || j.StartsWith("s"))));

                yoda = input.Count(j => j.StartsWith("y")) > 0;
            }


            if (yoda)
            {
                Console.WriteLine(Regex.Replace(masters.ToString().TrimStart() + knights.ToString() + toshkoAndSlav.ToString() + padawans.ToString(), "\\s{2,}", " "));
            }
            else
            {
                Console.WriteLine(Regex.Replace(toshkoAndSlav.ToString().TrimStart() + masters.ToString() + knights.ToString() + padawans.ToString(), "\\s{2,}", " "));
            }
          

        }
    }
}