using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _04.ConvertFromBase10tobaseN
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ')
                .Select(BigInteger.Parse)
                .ToArray();

            string result = String.Empty;

            if (input[0] >= 2 && input[0] <= 10)
            {
                while (input[1] > 0)
                {
                    var remainder = input[1] % input[0];
                    input[1] /= input[0];

                    result = remainder.ToString() + result;
                }

                Console.WriteLine(result);

            }
            else
            {
                Console.WriteLine(0);
            }


            
        }
    }
}
