using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _05.ExtractEmail
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            Regex regex = new Regex("(?<=\\s)[A-Za-z0-9]+[A-Za-z0-9-_\\.]*[A-Za-z0-9]@([a-z-]+\\.)+[a-z]+");

            var matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
