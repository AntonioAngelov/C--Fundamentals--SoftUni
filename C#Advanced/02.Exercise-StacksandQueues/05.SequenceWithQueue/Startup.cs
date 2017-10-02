using System;
using System.Collections.Generic;

namespace _05.SequenceWithQueue
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var queue = new Queue<int>();
            queue.Enqueue(N);

            var counter = 0;
            
            for (int i = 1; i <= 49; i++)
            {
                switch (counter)
                {
                    case 0:
                        queue.Enqueue(queue.Peek() + 1);
                        break;
                    case 1:
                        queue.Enqueue(queue.Peek() * 2 + 1);
                        break;
                    case 2:
                        queue.Enqueue(queue.Peek() + 2);
                        Console.Write(queue.Dequeue() + " ");
                        break;
                }

                counter = (counter + 1) % 3;
            }

            while (queue.Count > 0)
            {
                Console.Write(queue.Dequeue() + " ");
            }
        }
    }
}
