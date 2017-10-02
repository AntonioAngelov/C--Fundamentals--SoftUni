using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.RadioactiveMutantVampireBunnies
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var dimentions = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[][] lair = new char[dimentions[0]][];

            //will hold the coordinates of the player at each point of the game
            int[] playerCoordinates = new int[2];

            //holds the coordinates of the bunnies
            List<int[]> bunniesCoordinates = new List<int[]>();


            for (int row = 0; row < dimentions[0]; row++)
            {
                lair[row] = Console.ReadLine().ToCharArray();

                for (int col = 0; col < dimentions[1]; col++)
                {
                    if (lair[row][col] == 'P')
                    {
                        playerCoordinates[0] = row;
                        playerCoordinates[1] = col;
                    }

                    if (lair[row][col] == 'B')
                    {
                        bunniesCoordinates.Add(new int[] {row, col});
                    }
                }
            }

            var navigation = Console.ReadLine();
            
            for (int i = 0; i < navigation.Length; i++)
            {
                // returns 0 if the player survives but doesnt escape the lair
                // return 1 if he escapes the lair
                // return 2 if he dies

                int survivesMove = MoveChampion(navigation[i], playerCoordinates, lair, dimentions);

                

                // return true if the player survives and false otherwise
                bool survivesMultyplication = MultipyBunnies(playerCoordinates, lair, dimentions, bunniesCoordinates);

                if (!survivesMultyplication || survivesMove == 2)
                {
                    PrintLair(lair);
                    Console.WriteLine($"dead: {playerCoordinates[0]} {playerCoordinates[1]}");
                    break;
                }
                else if(survivesMove == 1)
                {
                    PrintLair(lair);
                    Console.WriteLine($"won: {playerCoordinates[0]} {playerCoordinates[1]}");
                    break;
                }

            }


        }

        private static void PrintLair(char[][] lair)
        {
            foreach (var row in lair)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        
        private static bool MultipyBunnies(int[] playerCoordinates, char[][] lair, int[] dimentions, List<int[]> bunniesCoordinates)
        {
            var bunniesCount = bunniesCoordinates.Count;
            var playerSurvives = true;


            for (int i = 0; i < bunniesCount; i++)
            {
                var currentBunnyRow = bunniesCoordinates[i][0];
                var currentBunnyCol = bunniesCoordinates[i][1];
                
                if (currentBunnyRow + 1 < dimentions[0])
                {
                    if (lair[currentBunnyRow + 1][currentBunnyCol] == 'P')
                    {
                        playerSurvives = false;
                    }

                    lair[currentBunnyRow + 1][currentBunnyCol] = 'B';
                    bunniesCoordinates.Add(new int[] {currentBunnyRow + 1, currentBunnyCol});

                }

                if (currentBunnyRow - 1 >= 0)
                {
                    if (lair[currentBunnyRow - 1][currentBunnyCol] == 'P')
                    {
                        playerSurvives = false;
                    }

                    lair[currentBunnyRow - 1][currentBunnyCol] = 'B';
                    bunniesCoordinates.Add(new int[] { currentBunnyRow - 1, currentBunnyCol });
                }

                if (currentBunnyCol - 1 >= 0)
                {
                    if (lair[currentBunnyRow][currentBunnyCol - 1] == 'P')
                    {
                        playerSurvives = false;
                    }

                    lair[currentBunnyRow][currentBunnyCol - 1] = 'B';
                    bunniesCoordinates.Add(new int[] { currentBunnyRow, currentBunnyCol - 1});

                }

                if (currentBunnyCol + 1 < dimentions[1])
                {
                    if (lair[currentBunnyRow][currentBunnyCol + 1] == 'P')
                    {
                        playerSurvives = false;
                    }

                    lair[currentBunnyRow][currentBunnyCol + 1] = 'B';
                    bunniesCoordinates.Add(new int[] { currentBunnyRow, currentBunnyCol + 1 });
                }
            }

            return playerSurvives;

        }

        private static int MoveChampion(char nav, int[] playerCoordinates, char[][] lair, int[] lairDimentions)
        {
            var newRow = playerCoordinates[0];
            var newCol = playerCoordinates[1];

            lair[playerCoordinates[0]][playerCoordinates[1]] = '.';

            switch (nav)
            {
                case 'U':
                    newRow -= 1;
                    if (newRow < 0)
                    {
                        return 1;
                    }
                    break;
                case 'D':
                    newRow += 1;
                    if (newRow == lairDimentions[0])
                    {
                        return 1;
                    }
                    break;
                 case 'L':
                    newCol -= 1;
                    if (newCol < 0)
                    {
                        return 1;
                    }
                    break;
                case 'R':
                    newCol += 1;
                    if (newCol == lairDimentions[1])
                    {
                        return 1;
                    }
                    break;

            }

            playerCoordinates[0] = newRow;
            playerCoordinates[1] = newCol;

            if (lair[newRow][newCol] == '.')
            {
                lair[newRow][newCol] = 'P';
                return 0;
            }
            else
            {
                return 2;
            }
        }
    }
}
