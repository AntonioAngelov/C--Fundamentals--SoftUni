namespace _01.SecondNature
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        static void Main(string[] args)
        {
            var flowers = new Stack<int>(Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .Reverse()
                .ToArray());

            
            var buckets = new Stack<int>(Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray());

            List<int> secondNatureFlowers = new List<int>();

            
            while (flowers.Count > 0 && buckets.Count > 0)
            {

                var currentFlower = flowers.Pop();
                var currentBucket = buckets.Pop();

                if (currentBucket == currentFlower)
                {
                    secondNatureFlowers.Add(currentFlower);

                }
                else
                {
                    currentFlower -= currentBucket;

                    if (currentFlower < 0)
                    {
                        if (buckets.Any())
                        {
                            buckets.Push(buckets.Pop() + Math.Abs(currentFlower));
                        }
                        else
                        {
                            buckets.Push(Math.Abs(currentFlower));
                        }
                    }
                    else
                    {
                        flowers.Push(currentFlower);
                    }

                }
            }

            if (flowers.Any())
            {
                Console.WriteLine(string.Join(" ", flowers));
            }
            else
            {
                Console.WriteLine(string.Join(" ", buckets));
            }

            if (secondNatureFlowers.Any())
            {
                Console.WriteLine(string.Join(" ", secondNatureFlowers));
            }
            else
            {
                Console.WriteLine("None");
            }

         

        }
    }
}
