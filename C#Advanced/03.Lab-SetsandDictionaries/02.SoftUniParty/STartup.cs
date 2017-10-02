using System;
using System.Collections.Generic;

namespace _02.SoftUniParty
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var vipGuests = new SortedSet<string>();
            var ordinaryGuests = new SortedSet<string>();

            var input = Console.ReadLine();
            bool partyStarted = false;

            while (input != "END")
            {
                if (input!="PARTY")
                {
                    if (partyStarted == false)
                    {
                        if (Char.IsNumber(input[0]))
                        {
                            vipGuests.Add(input);
                        }
                        else
                        {
                            ordinaryGuests.Add(input);
                        }
                    }
                    else
                    {
                        if (Char.IsNumber(input[0]))
                        {
                            if (vipGuests.Contains(input))
                            {
                                vipGuests.Remove(input);
                            }
                        }
                        else
                        {
                            if (ordinaryGuests.Contains(input))
                            {
                                ordinaryGuests.Remove(input);
                            }
                        }
                    }
                }
                else
                {
                    partyStarted = true;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(vipGuests.Count + ordinaryGuests.Count);

            foreach (var guest in vipGuests)
            {
                Console.WriteLine(guest);
            }

            foreach (var guest in ordinaryGuests)
            {
                Console.WriteLine(guest);
            }

        }
    }
}
