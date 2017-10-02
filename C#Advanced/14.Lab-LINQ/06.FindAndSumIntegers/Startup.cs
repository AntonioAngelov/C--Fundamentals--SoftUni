namespace _06.FindAndSumIntegers
{
    using System;
    using System.Linq;

    public class Startup
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Where(w => w.All(char.IsDigit) || (w.Skip(1).All(char.IsDigit) && w[0] == '-'))
                .Select(long.Parse);

            if (numbers.Count() != 0)
            {
                Console.WriteLine(numbers.Sum());
            }
            else
            {
                Console.WriteLine("No match");
            }
            
        }
    }
}
