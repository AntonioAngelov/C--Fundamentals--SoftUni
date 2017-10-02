using System;
using System.Linq;

namespace _02.DiagonalDifference
{
    public 
        class Startup
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[][] matrix = new int[n][];

            for (int i = 0; i < n; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                
            }

            long difference = 0;
            
            for (int row = 0; row < n; row++)
            {
                difference += matrix[row][row];
                difference -= matrix[row][n - (row + 1)];
            }

            Console.WriteLine(Math.Abs(difference));

        }
    }
}
