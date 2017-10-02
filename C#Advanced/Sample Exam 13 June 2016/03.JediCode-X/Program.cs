using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.JediCode_X
{
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var encodedMessage = string.Empty;

            for (int i = 0; i < n; i++)
            {
                encodedMessage += Console.ReadLine();
            }

            var namePrefix = Console.ReadLine();
            var messagePrefix = Console.ReadLine();

            string namePattern = string.Format("(?<={0})([a-zA-Z]{1})", namePrefix, namePrefix.Length);
         //   Regex nameRegex = new Regex();

            Console.WriteLine(namePattern);
        }
    }
}
