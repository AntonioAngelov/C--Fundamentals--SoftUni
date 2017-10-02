using System;
using System.Collections.Generic;

namespace _01.UniqueUsernames
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var usernames = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                var currentUsername = Console.ReadLine();
                usernames.Add(currentUsername);
            }

            foreach (var un in usernames)
            {
                Console.WriteLine(un);
            }
        }
    }
}
