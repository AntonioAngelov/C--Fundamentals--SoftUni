using System;
using System.Linq;

namespace _04.MaximalSum
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var dimentions = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[][] matrix = new int[dimentions[0]][];

            for (int row = 0; row < dimentions[0]; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            long maxSum = long.MinValue;
            int[,] maxMatrix = new int[3,3];


            for (int row = 0; row < dimentions[0] - 2; row++)
            {
                for (int col = 0; col < dimentions[1] - 2; col++)
                {
                    int[,] currentMatrix = new int[3, 3];



                    long currentSum = 0;

                    for (int r = 0; r < 3; r++)
                    {
                        for (int c = 0; c < 3; c++)
                        {
                            currentMatrix[r, c] = matrix[row + r][col + c];
                            currentSum += matrix[row + r][col + c];
                        }
                    }

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxMatrix = currentMatrix;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.Write($"{maxMatrix[row, col]} ");
                }

                Console.WriteLine();
            }

        }
    }
}
