namespace _04.CubicAssault
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Startup
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> regions = new Dictionary<string, Dictionary<string, long>>();

            var input = Console.ReadLine();

            while (input != "Count em all")
            {
                var splitted = Regex.Split(input, @" -> ");

                var region = splitted[0];
                var color = splitted[1];
                var count = long.Parse(splitted[2]);


                if (!regions.ContainsKey(region))
                {
                    regions.Add(region, new Dictionary<string, long>());

                    regions[region]["Green"] = 0;
                    regions[region]["Red"] = 0;
                    regions[region]["Black"] = 0;
                }

                regions[region][color] += count;

                if (regions[region]["Green"] >= 1000000)
                {
                    regions[region]["Red"] += regions[region]["Green"] / 1000000;
                    regions[region]["Green"] = regions[region]["Green"] % 1000000;
                }
                if (regions[region]["Red"] >= 1000000)
                {
                    regions[region]["Black"] += regions[region]["Red"] / 1000000;
                    regions[region]["Red"] = regions[region]["Red"] % 1000000;
                }
                

                input = Console.ReadLine();
            }

            regions.OrderByDescending(reg => reg.Value["Black"]).ThenBy(reg => reg.Key.Length).ThenBy(reg => reg.Key).ToList().ForEach(reg =>
            {
                Console.WriteLine(reg.Key);
                reg.Value.OrderByDescending(s => s.Value).ThenBy(s => s.Key).ToList().ForEach(s =>
                {
                    Console.WriteLine("-> {0} : {1}", s.Key, s.Value);
                });
            });


        }
    }
}
