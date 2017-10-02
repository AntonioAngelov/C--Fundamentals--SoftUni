using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _07.ValidTime
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            Regex regex = new Regex(@"^(0[0-9]|1[012]):([012345][0-9]):([012345][0-9]) [AP]M$");

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
