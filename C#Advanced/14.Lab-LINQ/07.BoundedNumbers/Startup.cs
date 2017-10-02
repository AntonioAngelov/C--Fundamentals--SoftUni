namespace _07.BoundedNumbers
{
    using System;
    using System.Linq;

    public class Startup
    {
        static void Main(string[] args)
        {
            var bounds = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse);

            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .Where(n => n >= bounds.Min() && n <= bounds.Max());

            if (numbers.Count() != 0)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }

        }
    }
}
