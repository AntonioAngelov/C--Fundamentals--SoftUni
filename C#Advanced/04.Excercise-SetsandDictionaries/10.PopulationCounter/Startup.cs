using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PopulationCounter
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var countries = new Dictionary<string, Dictionary<string, long>>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "report")
                {
                    break;
                }

                var data = input.Split(new []{'|'}, StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (!countries.ContainsKey(data[1]))
                {
                    var buffer = new Dictionary<string, long>();
                    buffer.Add(data[0], long.Parse(data[2]));

                    countries.Add(data[1], buffer);
                }
                else
                {
                    if (!countries[data[1]].ContainsKey(data[0]))
                    {
                        countries[data[1]].Add(data[0], long.Parse(data[2]));
                    }
                    else
                    {
                        countries[data[1]][data[0]] = long.Parse(data[2]);
                    }
                }

            }

            //sorting
            countries = countries.OrderByDescending(x => x.Value.Values.Sum()).ToDictionary(x => x.Key, x => x.Value);

            var keys = new List<string>(countries.Keys);

            foreach (var country in keys)
            {
                countries[country] = countries[country].OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            }

           //printing the result
            foreach (var country in countries.Keys)
            {
                Console.WriteLine($"{country} (total population: {countries[country].Values.Sum()})");
                foreach (var city in countries[country].Keys)
                {
                    Console.WriteLine($"=>{city}: {countries[country][city]}");
                }
            }

        }
    }
}
