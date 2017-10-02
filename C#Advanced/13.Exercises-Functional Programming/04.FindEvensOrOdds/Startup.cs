namespace _04.FindEvensOrOdds
{
    using System;
    using System.Linq;

    public class Startup
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var criteria = Console.ReadLine();
            for (int i = numbers[0]; i <= numbers[1]; i++)
            {
                if (criteria == "even" && i % 2 == 0)
                {
                    Console.Write($"{i} ");
                }
                else if(criteria == "odd" && i % 2 != 0)
                {
                    Console.Write($"{i} ");
                }
            }
            
        }
    }
}
