using System;
using System.Linq;

namespace _10.UnicodeCharacters
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var chars = input
                .Select(c => (int)c)
                .Select(c => $@"\u{c:x4}");

            var result = string.Concat(chars);

            Console.WriteLine(result);
        }
    }
}
