namespace _05.MinEvenNumber
{
    using System;
    using System.Linq;

    public class Startup
    {
        static void Main(string[] args)
        {
            var evenNums = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .Where(n => n % 2 == 0)
                .OrderBy(n => n);

            if (evenNums.Count() == 0)
            {
                Console.WriteLine("No match");
            }
            else
            {
                Console.WriteLine($"{evenNums.FirstOrDefault():f2}");
            }


        }
    }
}
