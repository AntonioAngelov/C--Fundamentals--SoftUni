using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.LegoBlocks
{
    public class Startup
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<List<int>> firstBlock = new List<List<int>>();
            List<List<int>> secondBlock = new List<List<int>>();

            for (int row = 0; row < n; row++)
            {
                firstBlock.Add(new List<int>());
                firstBlock[row] = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

            }

            for (int row = 0; row < n; row++)
            {
                secondBlock.Add(new List<int>());
                secondBlock[row] = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .Reverse()
                    .ToList();

            }

            var elementsPerRow = firstBlock[0].Count + secondBlock[0].Count;
            var blocksFit = true;

            for (int row = 1; row < n; row++)
            {
                if (firstBlock[row].Count + secondBlock[row].Count != elementsPerRow)
                {
                    blocksFit = false;
                    break;
                }
            }

            if (blocksFit)
            {
                for (int row = 0; row < n; row++)
                {
                    var combinedRow = firstBlock[row].Concat(secondBlock[row]);

                    Console.WriteLine($"[{string.Join(", ", combinedRow)}]");
                }
            }
            else
            {
                int elementsCount = 0;

                for (int row = 0; row < n; row++)
                {
                    elementsCount += firstBlock[row].Count;
                    elementsCount += secondBlock[row].Count;
                }

                Console.WriteLine($"The total number of cells is: {elementsCount}");
            }



        }
    }
}
