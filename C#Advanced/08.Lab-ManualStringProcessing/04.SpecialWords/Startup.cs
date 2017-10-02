using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.SpecialWords
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var specialWords = Console.ReadLine()
                .Split(new[] { "(", ")", "[", "]", "<", ">", ",", "-", "!", "?", " " },
                    StringSplitOptions.RemoveEmptyEntries);

            var text = Console.ReadLine()
                .Split(new[] { "(", ")", "[", "]", "<", ">", ",", "-", "!", "?", " " },
                    StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> specialWordsCount = new Dictionary<string, int>();

            foreach (var word in specialWords)
            {
                specialWordsCount.Add(word, 0);
            }

            foreach (var word in text)
            {
                if (specialWordsCount.ContainsKey(word))
                {
                    specialWordsCount[word] += 1;
                }
            }

            foreach (var word in specialWordsCount.Keys)
            {
                Console.WriteLine($"{word} - {specialWordsCount[word]}");
            }


        }
    }
}
