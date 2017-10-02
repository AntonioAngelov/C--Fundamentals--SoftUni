using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _10.UseYourChainsBuddy
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var paragraphsRegex = new Regex("<p>(.+?)</p>");

            string resultManual = string.Empty;
            var paragraphs = paragraphsRegex.Matches(input);

            foreach (Match paragraph in paragraphs)
            {
                var currentContent = Regex.Replace(paragraph.Groups[1].Value, @"[^a-z0-9]+", word => " ");

                for (int i = 0; i < currentContent.Length; i++)
                {
                    var currentLetter = currentContent[i];

                    if (currentLetter >= 'a' && currentLetter <= 'z')
                    {
                        if (currentLetter >= 'a' && currentLetter <= 'm')
                        {
                            currentLetter = (Char)(Convert.ToUInt16(currentLetter) + 13);
                        }
                        else
                        {
                            currentLetter = (Char)(Convert.ToUInt16(currentLetter) - 13);
                        }
                    }

                    resultManual += currentLetter;
                }

            }

            Console.WriteLine(resultManual);

        }
    }
}
