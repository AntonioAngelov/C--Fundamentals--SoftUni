using System;
using System.Text.RegularExpressions;

namespace _06.SentenceExtractor
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var keyword = Console.ReadLine();
            var text = Console.ReadLine();

            Regex regex = new Regex($@"(\w[^.!?]*)?\b{keyword}\b[^.!?]*[.!?]");

            var matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }
            
        }
    }
}
