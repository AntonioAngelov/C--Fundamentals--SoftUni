using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _13.SrabskoUnleashed
{
    public class Startup
    {
        static void Main(string[] args)
        {
            string pattern = @"(.*?) @(.*?) (\d+) (\d+)";

            var venues = new Dictionary<string, Dictionary<string, long>>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                if (!Regex.IsMatch(input, pattern))
                {
                    continue;
                }

                var data = input
                    .Split(new[] {'@'}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var singer = data[0].Trim();
                var venueInfo = data[1].Split(' ').ToArray();
                var ticketsCount = long.Parse(venueInfo[venueInfo.Length - 1]);
                var ticketPrice = long.Parse(venueInfo[venueInfo.Length - 2]);

                var venueName = String.Empty;
                for (int i = 0; i < venueInfo.Length - 2; i++)
                {
                    venueName += venueInfo[i];
                    if (i < venueInfo.Length - 3)
                    {
                        venueName += " ";
                    }
                }

                if (!venues.ContainsKey(venueName))
                {
                    var buffer = new Dictionary<string, long>();
                    buffer.Add(singer, ticketPrice * ticketsCount);
                    venues.Add(venueName, buffer);
                }
                else
                {
                    if (!venues[venueName].ContainsKey(singer))
                    {
                        venues[venueName].Add(singer, ticketPrice * ticketsCount);
                    }
                    else
                    {
                        venues[venueName][singer] += ticketPrice * ticketsCount;
                    }
                }

            }

            foreach (var venue in venues)
            {
                Console.WriteLine($"{venue.Key}");
                Console.Write($"#  {string.Join("#  ", venue.Value.OrderByDescending(x => x.Value).Select(x => $"{x.Key} -> {x.Value}\n"))}");
            }

        }
    }
}
