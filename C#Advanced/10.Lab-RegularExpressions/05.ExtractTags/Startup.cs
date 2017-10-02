using System;
using System.Text.RegularExpressions;

namespace _05.ExtractTags
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine();
            var pattern = @"<.*?>";
            Regex regex = new Regex(pattern);

            while (line != "END")
            {
                var matches = regex.Matches(line);

                foreach (var match in matches)
                {
                    Console.WriteLine(match);
                }

                line = Console.ReadLine();
            }
        }
    }
}
