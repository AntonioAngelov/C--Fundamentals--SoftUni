namespace _03.FormattingNumbers
{
    using System;

    public class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new []{' ', '\t', '\n'}, StringSplitOptions.RemoveEmptyEntries);

            var a = int.Parse(input[0]);
            var b = decimal.Parse(input[1]);
            var c = decimal.Parse(input[2]);
            
            var first = string.Format("{0,-10:X}", a);
            var second = Convert.ToString(a, 2);
            if (second.Length > 10)
            {
                second = second.Substring(0, 10);
            }
            second = second.PadLeft(10, '0');

            var third = string.Format("{0,10:f2}", b);
            var fourth = string.Format("{0,-10:f3}", c);


            Console.WriteLine($"|{first}|{second}|{third}|{fourth}|");

        }
    }
}
