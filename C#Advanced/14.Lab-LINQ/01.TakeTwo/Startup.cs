namespace _01.TakeTwo
{
    using System;
    using System.Linq;

    public class Startup
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            Console.WriteLine(string.Join(" ", numbers.Distinct().Where(n => n >=10 && n<=20).Take(2)));


        }
    }
}
