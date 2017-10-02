namespace _03.CustomMinFunction
{
    using System;
    using System.Linq;

    public class Startup
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray()
                .Min());
        }
    }
}
