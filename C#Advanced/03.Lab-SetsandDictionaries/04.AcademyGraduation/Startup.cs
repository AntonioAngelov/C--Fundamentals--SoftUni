using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.AcademyGraduation
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var avgScores = new SortedDictionary<string, double[]>();

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double[] scores = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                if (!avgScores.ContainsKey(name))
                {
                    avgScores.Add(name, scores);
                }
                else
                {
                    avgScores[name].Concat(scores);
                }
            }

            foreach (var student in avgScores.Keys)
            {
                var avgScore = avgScores[student].Sum() / avgScores[student].Count();
                Console.WriteLine($"{student} is graduated with {avgScore}");
            }
        }
    }
}
