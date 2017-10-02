namespace _02.KnightGame
{
    using System;
    using System.Linq;

    public class Startup
    {
        static void Main(string[] args)
        {
            var dimention = int.Parse(Console.ReadLine());

            char[][] board = CreateBoard(dimention);
            int removedCount = 0;

            int[][] endageredCounter = new int[dimention][];

            for (int row = 0; row < dimention; row++)
            {
                endageredCounter[row] = new int[dimention];
            }
            
            do
            {
                endageredCounter = new int[dimention][];

                for (int row = 0; row < dimention; row++)
                {
                    endageredCounter[row] = new int[dimention];

                }

                for (int row = 0; row < dimention; row++)
                {
                    for (int col = 0; col < dimention; col++)
                    {
                        if (board[row][col] == 'K')
                        {
                            if (row - 1 >= 0 && col + 2 < dimention)
                            {
                                if (board[row - 1][col + 2] == 'K')
                                {
                                    endageredCounter[row][col] += 1;
                                    endageredCounter[row - 1][col + 2] += 1;
                                }
                            }

                            if (row - 1 >= 0 && col - 2 >= 0)
                            {
                                if (board[row - 1][col - 2] == 'K')
                                {
                                    endageredCounter[row][col] += 1;
                                    endageredCounter[row - 1][col - 2] += 1;
                                }
                            }

                            if (row + 1 < dimention && col - 2 >= 0)
                            {
                                if (board[row + 1][col - 2] == 'K')
                                {
                                    endageredCounter[row][col] += 1;
                                    endageredCounter[row + 1][col - 2] += 1;
                                }
                            }

                            if (row + 1 < dimention && col + 2 < dimention)
                            {
                                if (board[row + 1][col + 2] == 'K')
                                {
                                    endageredCounter[row][col] += 1;
                                    endageredCounter[row + 1][col + 2] += 1;
                                }
                            }
                            //
                            if (col - 1 >= 0 && row + 2 < dimention)
                            {
                                if (board[row + 2][col - 1] == 'K')
                                {
                                    endageredCounter[row][col] += 1;
                                    endageredCounter[row + 2][col - 1] += 1;
                                }
                            }

                            if (col - 1 >= 0 && row - 2 >= 0)
                            {
                                if (board[row - 2][col - 1] == 'K')
                                {
                                    endageredCounter[row][col] += 1;
                                    endageredCounter[row - 2][col - 1] += 1;
                                }
                            }

                            if (col + 1 < dimention && row - 2 >= 0)
                            {
                                if (board[row - 2][col + 1] == 'K')
                                {
                                    endageredCounter[row][col] += 1;
                                    endageredCounter[row - 2][col + 1] += 1;
                                }
                            }

                            if (col + 1 < dimention && row + 2 < dimention)
                            {
                                if (board[row + 2][col + 1] == 'K')
                                {
                                    endageredCounter[row][col] += 1;
                                    endageredCounter[row + 2][col + 1] += 1;
                                }
                            }
                        }
                    }
                }

                var max = 0;
                var maxRow = new int();
                var maxCol = new int();

                for (int row = 0; row < dimention; row++)
                {
                    for (int col = 0; col < dimention; col++)
                    {
                        if (max < endageredCounter[row][col])
                        {
                            max = endageredCounter[row][col];
                            maxRow = row;
                            maxCol = col;
                        }
                    }
                }

                if (max > 0)
                {
                    ++removedCount;
                    board[maxRow][maxCol] = '0';
                }

            } while (endageredCounter.Any(row => row.Any(v => v != 0)));

            Console.WriteLine(removedCount);
        }

        private static char[][] CreateBoard(int dimention)
        {
            char[][] board = new char[dimention][];

            for (int row = 0; row < dimention; row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();
                board[row] = currentRow;
            }

            return board;
        }
    }
}
