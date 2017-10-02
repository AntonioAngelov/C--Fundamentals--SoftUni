using System;
using System.Collections.Generic;

namespace _07.FixEmails
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var emails = new Dictionary<string, string>();

            while (true)
            {
                var name = Console.ReadLine();
                if (name == "stop")
                {
                    break;
                }

                var email = Console.ReadLine();

                if (!emails.ContainsKey(name))
                {
                    if (!email.EndsWith(".us") || !email.EndsWith(".uk"))
                    {
                        emails.Add(name, email);
                    } 
                }
                else
                {
                    if (!email.EndsWith(".us") && !email.EndsWith(".uk"))
                    {
                        emails[name] = email;
                    }
                }

            }

            foreach (var person in emails.Keys)
            {
                Console.WriteLine($"{person} -> {emails[person]}");
            }

        }
    }
}
