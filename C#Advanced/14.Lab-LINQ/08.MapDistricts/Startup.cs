namespace _08.MapDistricts
{
    using System;
    using System.Linq;

    public class Startup
    {
        static void Main(string[] args)
        {
            var cities = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .GroupBy(d => d.Split(':').ToList()[0])
                .ToDictionary(c => c.Key, c => c.Select(d => d.Split(':').ToArray()[1])
                    .Select(long.Parse)
                    .OrderByDescending(n => n)
                    .ToArray());
                

            var minPopulation = long.Parse(Console.ReadLine());

            var filteredCities = cities
                .Where(c => c.Value.Sum() > minPopulation)
                .OrderByDescending(c => c.Value.Sum())
                .ToDictionary(c => c.Key, c => c.Value);

            if (filteredCities.Count() != 0)
            {
                foreach (var city in filteredCities.Keys)
                {
                    Console.WriteLine($"{city}: {string.Join(" ", filteredCities[city].Take(5))}");
                }
            }




        }
    }
}
