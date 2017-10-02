using System;
using System.Linq;

public class Startup
{
    public static void Main(string[] args)
    {
        var elements = Console.ReadLine()
            .Split(' ')
            .Skip(1)
            .ToList();

        ListyIterator<string> listy1 = new ListyIterator<string>(elements);


        var command = Console.ReadLine();

        while (command != "END")
        {
            switch (command)
            {
                case "Move":
                    Console.WriteLine(listy1.Move());
                    break;
                case "Print":
                    try
                    {
                        listy1.Print();
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                case "HasNext":
                    Console.WriteLine(listy1.HasNext());
                    break;
                case "PrintAll":
                    listy1.PrintAll();
                    break;
            }

            command = Console.ReadLine();
        }
    }
}
