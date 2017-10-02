using System;
using System.Text.RegularExpressions;

namespace _16.ExtractHyperlinks
{
    public class Startup
    {
        static void Main(string[] args)
        {
            string text = string.Empty;
            string input = Console.ReadLine();
            while (input != "END")
            {
                text += input;
                input = Console.ReadLine();
            }

            string pattern = @"<a([^>]*?)href\s*=\s*(""|')(.+?)\2";
            Regex hrefSearch = new Regex(pattern);
            MatchCollection matches = hrefSearch.Matches(text);
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups[3].Value);
            }
        }
    }
}
