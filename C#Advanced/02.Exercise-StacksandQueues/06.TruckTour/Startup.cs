using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.TruckTour
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var circle = new Queue<int[]>();
            circle.TrimExcess();

            for (int i = 0; i < N; i++)
            {
                var curentPump = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                circle.Enqueue(curentPump);
            }

            circle.TrimExcess();
            
            int startIndex = 0;
            while (startIndex < circle.Count)
            {
                if (IsPossibleStart(circle))
                {
                    Console.WriteLine(startIndex);
                    break;
                }
                else
                {
                    ++startIndex;
                    circle.Enqueue(circle.Dequeue());
                }
            }


        }

        private static bool IsPossibleStart(Queue<int[]> circle)
        {
            var bufferCircle = new Queue<int[]>(circle);
            var availablePetrol = 0;
            bufferCircle.TrimExcess();
            
            while (bufferCircle.Count > 0)
            {
                var currentInfo = bufferCircle.Dequeue();
                availablePetrol += currentInfo[0] - currentInfo[1];
          
                if (availablePetrol < 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
