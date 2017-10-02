using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace _12.LegendaryFarming
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var legendaryMaterials = new Dictionary<string, int>();
            legendaryMaterials.Add("fragments", 0);
            legendaryMaterials.Add("motes", 0);
            legendaryMaterials.Add("shards", 0);

            var junkMaterials = new SortedDictionary<string, int>();

            while (true)
            {
                var data = Console.ReadLine().Split(' ').ToArray();
                var legendaryItemDone = false;
                
                for (int i = 0; i < data.Length; i+=2)
                {
                    data[i + 1] = data[i + 1].ToLower();

                    if (legendaryMaterials.ContainsKey(data[i + 1]))
                    {
                        legendaryMaterials[data[i + 1]] += int.Parse(data[i]);
                        if (legendaryMaterials[data[i + 1]] >= 250)
                        {
                            if (data[i + 1] == "shards")
                            {
                                Console.WriteLine($"Shadowmourne obtained!");
                            }
                            else if (data[i + 1] == "fragments")
                            {
                                Console.WriteLine($"Valanyr obtained!");
                            }
                            else
                            {
                                Console.WriteLine($"Dragonwrath obtained!");
                            }

                            legendaryMaterials[data[i + 1]] -= 250;
                            PrintRemainingMaterials(SortMaterials(legendaryMaterials), junkMaterials);
                            legendaryItemDone = true;
                            break;
                        }
                    }
                        else
                        {
                            if (!junkMaterials.ContainsKey(data[i + 1]))
                            {
                                junkMaterials.Add(data[i + 1], int.Parse(data[i]));
                            }
                            else
                            {
                                junkMaterials[data[i + 1]] += int.Parse(data[i]);
                            }
                        }
                        
                }

                if (legendaryItemDone)
                {
                    break;
                }

            }
        }

        private static void PrintRemainingMaterials(Dictionary<string, int> legendaryMaterials, SortedDictionary<string, int> junkMaterials)
        {
            foreach (var material in legendaryMaterials.Keys)
            {
               Console.WriteLine($"{material}: {legendaryMaterials[material]}"); 
            }

            foreach (var material in junkMaterials.Keys)
            {
                Console.WriteLine($"{material}: {junkMaterials[material]}");
            }
        }

        private static Dictionary<string, int> SortMaterials(Dictionary<string, int> legendaryMaterials)
        {
           return legendaryMaterials.OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);
            
        }
    }
}
