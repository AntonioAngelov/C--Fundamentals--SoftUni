using System;

namespace _02.StringLength
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            if (input.Length > 20)
            {
                input = input.Substring(0, 20);
            }

            Console.WriteLine(input.PadRight(20, '*'));
        }
    }
}
