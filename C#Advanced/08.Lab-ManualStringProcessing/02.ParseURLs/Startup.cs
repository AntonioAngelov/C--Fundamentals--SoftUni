using System;

namespace _02.ParseURLs
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var url = Console.ReadLine();

            var splittedURL = url
                .Split(new[] {"://"}, StringSplitOptions.RemoveEmptyEntries);
           
            if (splittedURL.Length != 2 || splittedURL[1].IndexOf("/") == -1)
            {
                Console.WriteLine("Invalid URL");
                return;
            }
            else
            {
                var index = splittedURL[1].IndexOf("/");
                var protocol = splittedURL[0];
                var server = splittedURL[1].Substring(0, index);
                var resources = splittedURL[1].Substring(index + 1);

                Console.WriteLine($"Protocol = {protocol}");
                Console.WriteLine($"Server = {server}");
                Console.WriteLine($"Resources = {resources}");
            }
        }
    }
}
