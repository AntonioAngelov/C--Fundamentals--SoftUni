using System;

namespace _06.CountSubstringOccurrences
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            var substring = Console.ReadLine();

            var counter = 0;
            var index = text.IndexOf(substring, StringComparison.OrdinalIgnoreCase);

            while (index > -1)
            {
                counter++;
                index = text.IndexOf(substring, index + 1, StringComparison.OrdinalIgnoreCase);
            }

            Console.WriteLine(counter);

        }
    }
}
