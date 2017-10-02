namespace _04.AshesOfRoses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Startup
    {
        static void Main(string[] args)
        {
            var pattern = new Regex("^Grow <([A-Z][a-z]+)> <([A-Za-z0-9]+)> (\\d+)$");

            var input = Console.ReadLine();

            Dictionary<string, Dictionary<string, long>> regions = new Dictionary<string, Dictionary<string, long>>();

            while (input != "Icarus, Ignite!")
            {
                var match = pattern.Match(input);

                if (match.Success)
                {
                    var region = match.Groups[1].Value;
                    var color = match.Groups[2].Value;
                    var amount = long.Parse(match.Groups[3].Value);

                    if (!regions.ContainsKey(region))
                    {
                        var bufferColor = new Dictionary<string, long>();
                        bufferColor.Add(color, amount);

                        regions.Add(region, bufferColor);
                    }
                    else
                    {
                        if (!regions[region].ContainsKey(color))
                        {
                            regions[region].Add(color, amount);
                        }
                        else
                        {
                            regions[region][color] += amount;
                        }
                    }

                }

                input = Console.ReadLine();

            }

            regions = regions.OrderByDescending(r => r.Value.Values.Sum()).ThenBy(r => r.Key).ToDictionary(r => r.Key, r => r.Value);

            foreach (var region in regions.Keys)
            {
                Console.WriteLine(region);
                foreach (var color in regions[region].OrderBy(c => c.Value).ThenBy(c => c.Key).ToDictionary(c => c.Key, c => c.Value).Keys)
                {
                    Console.WriteLine($"*--{color} | {regions[region][color]}");
                }
            }

        }
    }
}
