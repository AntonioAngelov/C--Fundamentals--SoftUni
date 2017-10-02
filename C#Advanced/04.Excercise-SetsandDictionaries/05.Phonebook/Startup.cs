using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Phonebook
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var phonebook = new Dictionary<string, string>();

            while (input != "search")
            {
                var contact = input
                    .Split('-')
                    .ToArray();

                if (!phonebook.ContainsKey(contact[0]))
                {
                    phonebook.Add(contact[0], contact[1]);
                }
                else
                {
                    phonebook[contact[0]] = contact[1];
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "stop")
            {
                if (phonebook.ContainsKey(input))
                {
                    Console.WriteLine($"{input} -> {phonebook[input]}");
                }
                else
                {
                    Console.WriteLine($"Contact {input} does not exist.");
                }

                input = Console.ReadLine();
            }
        }
    }
}
