using System;
using System.Text;

namespace _05.ConcatenateStrings
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                builder.Append(Console.ReadLine()).Append(" ");
            }

            Console.WriteLine(builder);
        }
    }
}
