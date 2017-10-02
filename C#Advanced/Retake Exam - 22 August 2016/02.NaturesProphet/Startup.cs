namespace _02.NaturesProphet
{
    using System;
    using System.Linq;

    public class Startup
    {
        static void Main(string[] args)
        {
            var dimentions = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int[][] garden = CreateGarden(dimentions[0], dimentions[1]);

            var input = Console.ReadLine();

            while (input != "Bloom Bloom Plow")
            {
                var splitted = input.Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                var row = splitted[0];
                var col = splitted[1];

                BloomRow(garden, row, dimentions[1]);
                BloomCol(garden, col, dimentions[0], row);

                input = Console.ReadLine();
            }

            for (int row = 0; row < dimentions[0]; row++)
            {
                Console.WriteLine(string.Join(" ", garden[row]));
            }

        }

        private static void BloomCol(int[][] garden, int col, int rows, int rowToBeSkipped)
        {
            for (int i = 0; i < rows; i++)
            {
                if (i != rowToBeSkipped)
                {
                    garden[i][col] += 1;
                }
            }
        }

        private static void BloomRow(int[][] garden, int row, int cols)
        {
            for (int i = 0; i < cols; i++)
            {
                garden[row][i] += 1;
            }
        }

        private static int[][] CreateGarden(int rows, int cols)
        {
            var garden = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                garden[i] = new int[cols];
            }

            return garden;
        }
    }
}
