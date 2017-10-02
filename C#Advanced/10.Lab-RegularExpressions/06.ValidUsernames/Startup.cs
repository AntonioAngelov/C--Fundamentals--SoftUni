using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _06.ValidUsernames
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            Regex regex = new Regex(@"^[\w\d-]{3,16}$");

            while (input != "END")
            {
                var matches = regex.Matches(input);
                if (matches.Count > 0)
                {
                    Console.WriteLine("valid");
                }
                else
                {
                    Console.WriteLine("invalid");
                }

                input = Console.ReadLine();

            }
        }
    }
}
