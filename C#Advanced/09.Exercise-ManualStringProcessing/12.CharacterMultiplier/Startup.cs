using System;
using System.Linq;

namespace _12.CharacterMultiplier
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new[] {' '})
                .ToArray();
            
            Console.WriteLine(Getproducts(input[0], input[1]));

        }

        public static long Getproducts(string w1, string w2)
        {
            var word1 = string.Empty;
            var word2 = string.Empty;

            if (w1.Length <= w2.Length)
            {
                word1 = w1;
                word2 = w2;
            }
            else
            {
                word2 = w1;
                word1 = w2;
            }

            int result = 0;

            for (int i = 0; i < word1.Length; i++)
            {
                int l = word1[i];
                int r = word2[i];
                result += l * r;
            }
            for (int i = word1.Length; i < word2.Length; i++)
                result += word2[i];

            return result;
        }
    }
}
