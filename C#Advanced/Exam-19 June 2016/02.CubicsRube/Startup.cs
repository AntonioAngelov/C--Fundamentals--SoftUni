namespace _02.CubicsRube
{
    using System;
    using System.Linq;

    public class Startup
    {
        static void Main(string[] args)
        {
            var dimentions = int.Parse(Console.ReadLine());

            long[][][] rube = CreateRube(dimentions);

            var input = Console.ReadLine();

            long sum = 0;
            var count = 0;

            while (input != "Analyze")
            {
                var splitted = input.Split(' ').ToArray();
                var row = long.Parse(splitted[0]);
                var col = long.Parse(splitted[1]);
                var depth = long.Parse(splitted[2]);
                var particleVal = long.Parse(splitted[3]);

                if (row >= 0 && row < dimentions 
                    && col >= 0 && col < dimentions
                    && depth >= 0 && depth < dimentions
                    && particleVal != 0)
                {
                    rube[row][col][depth] = particleVal;
                    sum += particleVal;
                    ++count;
                }
                
                input = Console.ReadLine();
            }

            Console.WriteLine(sum);
            Console.WriteLine(dimentions * dimentions * dimentions - count);
        }

        private static long[][][] CreateRube(int dimentions)
        {
            long[][][] rube = new long[dimentions][][];

            for (int row = 0; row < dimentions; row++)
            {
                rube[row] = new long[dimentions][];
                for (int col = 0; col < dimentions; col++)
                {
                    rube[row][col] = new long[dimentions];
                    
                }
            }

            return rube;


        }
    }
}
