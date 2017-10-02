using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01.ParkingLot
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var parking = new SortedSet<string>();

            while (input != "END")
            {
                var command = Regex.Split(input, ", ");
                if (command[0] == "IN")
                {
                    parking.Add(command[1]);
                }
                else
                {
                    if (parking.Contains(command[1]))
                    {
                        parking.Remove(command[1]);
                    }
                }

                input = Console.ReadLine();
            }

            if (parking.Count > 0)
            {
                foreach (var car in parking)
                {
                  Console.WriteLine(car);  
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
