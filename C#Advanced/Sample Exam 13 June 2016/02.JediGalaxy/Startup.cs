namespace _02.JediGalaxy
{
    using System;
    using System.Linq;

    public class Startup
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = dimentions[0];
            int cols = dimentions[1];
            int[,] matrix = new int[rows, cols];
            int n = 0;
            long sum = 0;

            //fil the matrix
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = n;
                    n++;
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Let the Force be with you")
                {
                    break;
                }
                string command2 = Console.ReadLine();
                int[] ivoCommand = command.Split().Select(int.Parse).ToArray();
                int[] evilCommand = command2.Split().Select(int.Parse).ToArray();

                int ivoStartRow = ivoCommand[0];
                int ivoStartCol = ivoCommand[1];
                int evilStartRow = evilCommand[0];
                int evilStartCol = evilCommand[1];


                //delete evils Cells

                while (evilStartRow >= 0 && evilStartCol >= 0)
                {
                    if (IsInMatrix(matrix, evilStartRow, evilStartCol))
                    {
                        matrix[evilStartRow, evilStartCol] = 0;
                    }

                    evilStartRow--;
                    evilStartCol--;
                }

                //sum IvosCells

                while (ivoStartRow >= 0 && ivoStartCol < cols)
                {
                    if (IsInMatrix(matrix, ivoStartRow, ivoStartCol))
                    {
                        sum += matrix[ivoStartRow, ivoStartCol];
                    }

                    ivoStartRow--;
                    ivoStartCol++;
                }
            }

            Console.WriteLine(sum);
        }
        private static bool IsInMatrix(int[,] matrix, int givenRow, int givenCol)
        {
            bool result = givenRow >= 0 && givenRow < matrix.GetLength(0) && givenCol >= 0 && givenCol < matrix.GetLength(1);
            return result;
        }
    }
}
