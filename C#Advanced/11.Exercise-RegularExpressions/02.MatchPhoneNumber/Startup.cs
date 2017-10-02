using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02.MatchPhoneNumber
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            Regex regex = new Regex(@"^\+359( |-)2\1[0-9]{3}\1[0-9]{4}$");

            while (input != "end")
            {
                var matches = regex.Matches(input);

                foreach (Match match in matches)
                {
                    Console.WriteLine(match);
                }

                input = Console.ReadLine();
            }
        }
    }
}
