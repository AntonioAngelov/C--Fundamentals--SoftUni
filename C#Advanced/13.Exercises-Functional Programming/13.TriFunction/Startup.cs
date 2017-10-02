namespace _13.TriFunction
{
    using System;
    using System.Linq;

    public class Startup
    {
        static void Main(string[] args)
        {
            var sum = int.Parse(Console.ReadLine());

            var names = Console.ReadLine()
                .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Console.WriteLine(names.Where(n => n.Sum(b => b) >= sum).FirstOrDefault());

        }
    }
}
