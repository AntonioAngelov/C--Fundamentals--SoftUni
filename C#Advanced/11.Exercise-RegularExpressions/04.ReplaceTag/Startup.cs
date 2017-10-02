using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.ReplaceTag
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            Regex regex = new Regex("<a\\s+href=('|\")(.*?)\\1?>(.*)</a>");

            while (input != "end")
            {
                Console.WriteLine(regex.Replace(input, "[URL href=\"$2\"]$3[/URL]"));

                input = Console.ReadLine();
            }
            
        }
    }
}
