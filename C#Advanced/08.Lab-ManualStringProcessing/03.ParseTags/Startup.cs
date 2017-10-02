using System;

namespace _03.ParseTags
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();

            var startPattern = "<upcase>";
            var endPattern = "</upcase>";

            var starIndex = text.IndexOf(startPattern);

            while (starIndex > -1)
            {
                var endIndex = text.IndexOf(endPattern);
                if (endIndex == -1)
                {
                    break;
                }

                var toBeReplaced = text.Substring(starIndex, endIndex + endPattern.Length - starIndex);
                var replaced = toBeReplaced
                    .Replace(startPattern, "")
                    .Replace(endPattern, "")
                    .ToUpper();

                text = text.Replace(toBeReplaced, replaced);

                starIndex = text.IndexOf(startPattern);

            }

            Console.WriteLine(text);

        }
    }
}
