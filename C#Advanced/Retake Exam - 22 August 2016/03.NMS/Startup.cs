namespace _03.NMS
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var builder = new StringBuilder();

            while (input != "---NMS SEND---")
            {
                builder.Append(input);
                input = Console.ReadLine();
            }

            List<string> words = new List<string>();

            string currentWord = builder[0].ToString();
        
            for (int i = 1; i < builder.Length; i++)
            {
                bool greater = char.ToLower(currentWord[currentWord.Length - 1]) <= char.ToLower(builder[i]);

                if (greater)
                {
                    currentWord += builder[i];
                }
                else
                {
                    words.Add(currentWord);
                    currentWord = builder[i].ToString();
                }

            }

            words.Add(currentWord);

            var delimeter = Console.ReadLine();


            Console.WriteLine(string.Join(delimeter, words));

        }
    }
}
