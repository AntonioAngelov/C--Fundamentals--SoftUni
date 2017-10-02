namespace _07.PredicateForNames
{
    using System;
    using System.Linq;

    public class Startup
    {
        static void Main(string[] args)
        {
            var maxLength = int.Parse(Console.ReadLine());

            var names = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            Console.WriteLine(string.Join("\n" , names.Where(n => n.Length <= maxLength)));
        }
    }
}
