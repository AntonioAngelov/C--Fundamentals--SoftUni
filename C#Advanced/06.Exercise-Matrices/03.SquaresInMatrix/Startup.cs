using System;
using System.Linq;

namespace _03.SquaresInMatrix
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var dimentions = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[][] matrix = new char[dimentions[0]][];

            for (int row = 0; row < dimentions[0]; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
            }

            int count = 0;

            for (int row = 0; row < dimentions[0] - 1; row++)
            {
                for (int col = 0; col < dimentions[1] - 1; col++)
                {
                    if (matrix[row][col] == matrix[row][col + 1]
                        && matrix[row + 1][col] == matrix[row + 1][col + 1]
                        && matrix[row][col] == matrix[row + 1][col])
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
            
        }
    }
}
