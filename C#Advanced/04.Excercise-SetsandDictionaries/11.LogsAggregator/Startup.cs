using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.LogsAggregator
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var loggs = new SortedDictionary<string, SortedDictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                var data = Console.ReadLine().Split(' ').ToArray();

                if (!loggs.ContainsKey(data[1]))
                {
                    var buffer = new SortedDictionary<string, int>();
                    buffer.Add(data[0], int.Parse(data[2]));

                    loggs.Add(data[1], buffer);
                }
                else
                {
                    if (!loggs[data[1]].ContainsKey(data[0]))
                    {
                        loggs[data[1]].Add(data[0], int.Parse(data[2]));
                    }
                    else
                    {
                        loggs[data[1]][data[0]] += int.Parse(data[2]);
                    }
                }
            }

            foreach (var user in loggs.Keys)
            {
                Console.WriteLine($"{user}: {loggs[user].Values.Sum()} [{String.Join(", ", loggs[user].Keys)}]");


            }

        }
    }
}
