using System;
using System.Collections.Generic;

namespace _06.AMiner_sTask
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var resources = new Dictionary<string, int>();

            while (true)
            {
                var resource = Console.ReadLine();
                if (resource == "stop")
                {
                    break;
                }

                var quantity = int.Parse(Console.ReadLine());

                if (!resources.ContainsKey(resource))
                {
                    resources.Add(resource, quantity);
                }
                else
                {
                    resources[resource] += quantity;
                }
                
            }

            foreach (var r in resources.Keys)
            {
                Console.WriteLine($"{r} -> {resources[r]}");
            }
        }
    }
}
