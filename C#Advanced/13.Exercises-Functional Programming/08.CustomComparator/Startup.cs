namespace _08.CustomComparator
{
    using System;
    using System.Linq;

    public class Startup
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Console.WriteLine(string.Join(" ", numbers.Where(n => n % 2 == 0).OrderBy(n => n)) 
                + " " 
                + string.Join(" ", numbers.Where(n => n % 2 != 0).OrderBy(n => n)));
        }
    }
}
