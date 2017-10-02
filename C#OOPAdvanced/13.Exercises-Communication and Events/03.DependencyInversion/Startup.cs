using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.DependencyInversion
{
    class Startup
    {
        static void Main(string[] args)
        {
            PrimitiveCalculator calculator = new PrimitiveCalculator();
            
            var input = Console.ReadLine();

            while (input != "End")
            {
                if (input.Contains("mode"))
                {
                    calculator.changeStrategy(input[input.Length - 1]);
                }
                else
                {
                    int[] operands = input
                        .Split(' ')
                        .Select(int.Parse)
                        .ToArray();

                    Console.WriteLine(calculator.performCalculation(operands[0], operands[1]));
                }


                input = Console.ReadLine();
            }

        }
    }
}
