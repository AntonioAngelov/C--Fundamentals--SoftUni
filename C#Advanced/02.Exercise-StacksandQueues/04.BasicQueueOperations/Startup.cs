using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.BasicQueueOperations
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var elements = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var queue = new Queue<int>();

            for (int i = 0; i < input[0]; i++)
            {
                queue.Enqueue(elements[i]);
            }

            while (input[1] != 0)
            {
                queue.Dequeue();
                input[1] -= 1;
            }

            if (queue.Contains(input[2]))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(GetSmallestNum(queue));
            }
        }

        public static int GetSmallestNum(Queue<int> queue)
        {
            if (queue.Count == 0)
            {
                return 0;
            }

            var min = int.MaxValue;
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (current < min)
                {
                    min = current;
                }
            }

            return min;
        }
    }
}
