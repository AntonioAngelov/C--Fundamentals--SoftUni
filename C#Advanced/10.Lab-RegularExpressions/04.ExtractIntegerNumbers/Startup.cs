using System;
using System.Text.RegularExpressions;

namespace _04.ExtractIntegerNumbers
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();

            Regex regex = new Regex(@"\d+");
            var matches = regex.Matches(text);

            foreach (var number  in matches)
            {
                Console.WriteLine(number);
            }
        }
    }
}
