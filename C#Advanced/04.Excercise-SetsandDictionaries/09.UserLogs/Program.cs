using System;
using System.Collections.Generic;

namespace _09.UserLogs
{
    public class Program
    {
        static void Main(string[] args)
        {
            var usersIps = new SortedDictionary<string, Dictionary<string, int>>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }

                var data = input.Split(new[] {' ', '='}, StringSplitOptions.RemoveEmptyEntries);
                
                if (!usersIps.ContainsKey(data[5]))
                {
                    var buffer = new Dictionary<string, int>();
                    buffer.Add(data[1], 1);
                    usersIps.Add(data[5], buffer);
                }
                else
                {
                    if (!usersIps[data[5]].ContainsKey(data[1]))
                    {
                        usersIps[data[5]].Add(data[1], 1);
                    }
                    else
                    {
                        usersIps[data[5]][data[1]] += 1;
                    }
                }

            }

            foreach (var user in usersIps.Keys)
            {
                Console.WriteLine(user + ": ");
                var count = 1;
                var containerCount = usersIps[user].Keys.Count;
                foreach (var ip in usersIps[user].Keys)
                {
                    Console.Write($"{ip} => {usersIps[user][ip]}");
                    if (containerCount == count)
                    {
                        Console.WriteLine(".");
                    }
                    else
                    {
                        Console.Write(", ");
                    }
                    ++count;
                }
            }

        }
    }
}
