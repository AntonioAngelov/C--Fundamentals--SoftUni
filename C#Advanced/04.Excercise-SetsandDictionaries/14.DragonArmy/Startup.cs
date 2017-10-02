using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dragons_army
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, SortedDictionary<string, Dragon>> data = ReadInput(n);
            PrintOutput(data);
        }

        private static void PrintOutput(Dictionary<string, SortedDictionary<string, Dragon>> data)
        {
            foreach (var item in data)
            {
                Dragon[] values = item.Value.Values.ToArray();
                double damageAvg = GetAverage(values, "damage");
                double healthAvg = GetAverage(values, "health");
                double armorAvg = GetAverage(values, "armor");
                Console.WriteLine($"{item.Key}::({damageAvg:f2}/{healthAvg:f2}/{armorAvg:f2})");
                foreach (var item2 in item.Value)
                {
                    Console.WriteLine($"-{item2.Key} -> damage: {item2.Value.Damage}, health: {item2.Value.Health}, armor: {item2.Value.Armor}");
                }
            }
        }

        private static double GetAverage(Dragon[] values, string v)
        {
            int average = 0;
            if (v == "damage")
            {
                foreach (var item in values)
                {
                    average += item.Damage;
                }
            }
            else if (v == "health")
            {
                foreach (var item in values)
                {
                    average += item.Health;
                }
            }
            else
            {
                foreach (var item in values)
                {
                    average += item.Armor;
                }
            }
            return (double)average / values.Length;
        }

        private static Dictionary<string, SortedDictionary<string, Dragon>> ReadInput(int n)
        {
            Dictionary<string, SortedDictionary<string, Dragon>> output = new Dictionary<string, SortedDictionary<string, Dragon>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string type = input[0];
                string dragonName = input[1];
                string[] stats = input.Skip(2).ToArray();
                int[] DHA = ValidateStats(stats); // damage,health,armor
                var theNewDragon = new Dragon(DHA);
                if (output.ContainsKey(type))
                {
                    if (output[type].ContainsKey(dragonName))
                    {
                        output[type][dragonName] = theNewDragon;
                    }
                    else
                    {
                        output[type].Add(dragonName, theNewDragon);
                    }
                }
                else
                {
                    output.Add(type, new SortedDictionary<string, Dragon> { { dragonName, theNewDragon } });
                }
            }
            return output;
        }

        private static int[] ValidateStats(string[] stats)
        {
            int[] statNumbers = new int[stats.Length];
            int[] defaults = new int[3] { 45, 250, 10 };
            for (int i = 0; i < stats.Length; i++)
            {
                if (stats[i] == "null")
                {
                    statNumbers[i] = defaults[i];
                }
                else
                {
                    statNumbers[i] = int.Parse(stats[i]);
                }
            }
            return statNumbers;
        }
    }

    class Dragon
    {
        public int Damage { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }

        public Dragon(int[] DHA)
        {
            Damage = DHA[0];
            Health = DHA[1];
            Armor = DHA[2];
        }
    }
}