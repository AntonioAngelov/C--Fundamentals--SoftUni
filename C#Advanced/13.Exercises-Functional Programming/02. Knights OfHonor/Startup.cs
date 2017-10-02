namespace _02.Knights_OfHonor
{
    using System;
    using System.Linq;

    public class Startup
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(n => "Sir " + n)
                .ToList()
                .ForEach(n => Console.WriteLine(n));

        }
    }
}
