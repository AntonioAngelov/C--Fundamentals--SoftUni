namespace _09.ListOfPredicates
{
    using System;
    using System.Linq;

    public class Startup
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());
            int[] toDivide = Console.ReadLine().Split(' ').Select(int.Parse).Distinct().ToArray();

            Func<int, bool>[] predicates = toDivide.Select(div => (Func<int, bool>)(n => n % div == 0)).ToArray();

            for (int j = 1; j <= range; j++)
            {
                bool isDivisable = true;

                foreach (var predicate in predicates)
                {
                    if (!predicate(j))
                    {
                        isDivisable = false;
                        break;
                    }
                }

                if (isDivisable)
                {
                    Console.Write("{0} ", j);
                }
            }

        }
    }
}
