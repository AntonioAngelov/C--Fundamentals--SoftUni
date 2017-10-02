namespace _03.CountUppercaseWords
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
           
            Console.WriteLine(
                string.Join("\n", input
                .Where(w => char.IsUpper(w[0]))));

        }
    }
}
