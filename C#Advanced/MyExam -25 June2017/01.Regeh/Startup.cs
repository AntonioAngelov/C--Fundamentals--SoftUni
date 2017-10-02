namespace _01.Regeh
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            Regex regex = new Regex("\\[[^\\s\\]<\\[]+?<([0-9]+)REGEH([0-9]+)>[^\\s\\]\\[]+?\\]");

            StringBuilder result = new StringBuilder();

            var matches = regex.Matches(input);

            long index = 0;

            foreach (Match match in matches)
            {
                var firstNum = int.Parse(match.Groups[1].Value);
                var secondNum = int.Parse(match.Groups[2].Value);


                index += firstNum;
                if (index >= input.Length)
                {
                    result.Append(input[(int)(index % input.Length) + 1]);
                    index += 1;
                }
                else
                {
                    result.Append(input[(int)index]);
                }


                index += secondNum;
                if (index >= input.Length)
                {
                    result.Append(input[(int)(index % input.Length) + 1]);
                    index += 1;
                }
                else
                {
                    result.Append(input[(int)index]);
                }

            }

            Console.WriteLine(result.ToString());


        }
    }
}