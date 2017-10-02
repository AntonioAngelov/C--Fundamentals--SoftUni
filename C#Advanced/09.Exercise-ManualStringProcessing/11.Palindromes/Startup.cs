using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.Palindromes
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new[] {' ', '\t', '\n', ',', '.', '?', '!'})
                .ToArray();

            List<string> palindromes = new List<string>();

            foreach (var word in input)
            {
                var reversed = word.ToCharArray();
                Array.Reverse(reversed);

                if (word == new string(reversed))
                {
                    if (!palindromes.Contains(word))
                    {
                        palindromes.Add(word);
                    }
                }
            }

            Console.WriteLine($"[{string.Join(", ", palindromes.OrderBy(a => a))}]");
        }
    }
}
