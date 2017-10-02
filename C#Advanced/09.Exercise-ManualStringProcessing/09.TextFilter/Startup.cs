using System;
using System.Linq;

namespace _09.TextFilter
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var bannedWords = Console.ReadLine()
                .Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            var text = Console.ReadLine();

            foreach (var banned in bannedWords)
            {
                text = text.Replace(banned, new string('*', banned.Length));
            }

            Console.WriteLine(text);
        }
    }
}
