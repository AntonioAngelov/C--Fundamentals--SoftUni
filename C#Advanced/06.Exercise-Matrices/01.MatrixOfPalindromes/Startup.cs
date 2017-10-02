using System;
using System.Linq;

namespace _01.MatrixOfPalindromes
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var dimentions = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();


            for (int row = 0; row < dimentions[0]; row++)
            {
                char first = (char)(97 + row);

                for (int col = 0; col < dimentions[1]; col++)
                {
                    char middle = (char)((int)first + col);
                    Console.Write($"{first}{middle}{first} ");
                }

                Console.WriteLine();
            }




        }
    }
}
