using System;
using System.Linq;

namespace _14.LettersChangeNumbers
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var sum = 0d;

            foreach (var word in input)
            {
                var firstLetter = word[0];
                var lastLetter = word[word.Length - 1];
                var number = double.Parse(word.Substring(1, word.Length - 2));

                int firstLetterCode = firstLetter;
                int lastLetterCode = lastLetter;

                if (char.IsUpper(firstLetter))
                {
                    number /= firstLetterCode - 64;
                }
                else 
                {
                    number *= firstLetterCode - 96;
                }

                if (char.IsUpper(lastLetter))
                {
                    number -= lastLetterCode - 64;
                }
                else
                {
                    number += lastLetterCode - 96;
                }

                sum += number;
            }

            Console.WriteLine(string.Format($"{sum:f2}"));
        }
    }
}
