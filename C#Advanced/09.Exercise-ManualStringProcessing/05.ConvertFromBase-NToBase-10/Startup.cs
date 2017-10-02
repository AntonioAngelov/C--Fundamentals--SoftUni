using System;
using System.Linq;
using System.Numerics;

namespace _05.ConvertFromBase_NToBase_10
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ')
                .ToArray();

            var baseN = BigInteger.Parse(input[0]);

            BigInteger result = 0;
            BigInteger power = 1;

            if (baseN >= 2 && baseN <=10)
            {
                for (int i = input[1].Length - 1; i >= 0; i--)
                {
                    result += BigInteger.Parse(input[1][i].ToString()) * power;

                    power *= baseN;
                }

                Console.WriteLine(result);
            }
        }
    }
}
