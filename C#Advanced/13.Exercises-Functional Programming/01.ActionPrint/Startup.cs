namespace _01.ActionPrint
{
    using System;
    using System.Linq;

    public class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Action<string> printName = n => Console.WriteLine(n);

            input.ForEach(printName);
        }
    }
}
