using System;
using System.Text;

namespace _01.ReverseString
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            StringBuilder builder = new StringBuilder();
            for (int i = input.Length - 1; i >= 0; i--)
            {
                builder.Append(input[i]);
            }


            Console.WriteLine(builder);
        }
    }
}
