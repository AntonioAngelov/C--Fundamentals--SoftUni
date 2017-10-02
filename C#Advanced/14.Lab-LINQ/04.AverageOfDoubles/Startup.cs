namespace _04.AverageOfDoubles
{
    using System;
    using System.Linq;

    public class Startup
    {
        static void Main(string[] args)
        {
            var average = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .Average();

            Console.WriteLine($"{average:f2}");
        }
    }
}
