namespace _06.Reverse_And_Exclude
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
                .ToArray();

            var n = int.Parse(Console.ReadLine());

            Array.Reverse(numbers);

            Console.WriteLine(string.Join(" ", numbers.Where(num => num % n != 0)));
        }
    }
}
