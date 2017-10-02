using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _08.ExtractHyperlinks
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            Regex regex = new Regex("<\\s*a\\s*[^>]*?href\\s*=\\s*(('|\\\")(?<result>.*?)\\2|(?<result>[^\\s>]+)).*?>");

            var combinedHTM = string.Empty;

            while (input != "END")
            {
                combinedHTM = combinedHTM + " " +  input;

                input = Console.ReadLine();
            }

            var matches = regex.Matches(combinedHTM);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups["result"].Value);
            }


        }
    }
}
