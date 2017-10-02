using System;

namespace _08.RecursiveFibonacci
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            Console.WriteLine(fib(n));
        }

        public static long fib(long term, long val = 1, long prev = 0)
        {
            if (term == 0) return prev;
            if (term == 1) return val;
            return fib(term - 1, val + prev, val);
        }
    }
}
