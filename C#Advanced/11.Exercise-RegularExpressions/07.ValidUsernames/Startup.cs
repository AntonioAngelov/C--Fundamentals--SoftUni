using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _07.ValidUsernames
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var usernames = Console.ReadLine()
                .Split(new[] { ' ', '/', '\\', '(', ')' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Regex regex = new Regex(@"^[A-Za-z][A-Za-z\d_]{2,24}$");
                        
            var matches = new List<string>();

            foreach (string username in usernames)
            {
                var match = regex.Match(username);

                if (match.Success)
                {
                    matches.Add(match.Value);
                }

            }

            var firstUsername = matches[0];
            var secondUsername = matches[1];
            var maxSumLength = firstUsername.Length + secondUsername.Length;

            for (int i = 1; i < matches.Count - 1; i++)
            {
                var CurrentLength = matches[i].Length + matches[i + 1].Length;

                if (CurrentLength > maxSumLength)
                {
                    maxSumLength = CurrentLength;
                    firstUsername = matches[i];
                    secondUsername = matches[i + 1];
                }
            }
            
            Console.WriteLine(firstUsername);
            Console.WriteLine(secondUsername);

        }
    }
}
