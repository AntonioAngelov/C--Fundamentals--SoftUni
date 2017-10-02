using System;
using System.Linq;

public class Startup
{
    static void Main(string[] args)
    {
        //exercise 07 and 08
        CommadInterpreter();
        
    }

    private static void CommadInterpreter()
    {
        var input = Console.ReadLine();

        MyList<string> myList = new MyList<string>();
        
        while (input != "END")
        {
            var splitted = input
                .Split(' ')
                .ToList();

            switch (splitted[0])
            {
                case "Add":
                    myList.Add(splitted[1]);
                    break;
                case "Remove":
                    myList.Remove(int.Parse(splitted[1]));
                    break;
                case "Contains":
                    Console.WriteLine(myList.Contains(splitted[1]));
                    break;
                case "Swap":
                    myList.Swap(int.Parse(splitted[1]), int.Parse(splitted[2]));
                    break;
                case "Greater":
                    Console.WriteLine(myList.CountGreaterThan(splitted[1]));
                    break;
                case "Max":
                    Console.WriteLine(myList.Max());
                    break;
                case "Min":
                    Console.WriteLine(myList.Min());
                    break;
                case "Sort":
                    Sorter.Sort(myList);
                    break;
                case "Print":
                    myList.Print();
                    break;
            }

            input = Console.ReadLine();
        }
    }
}
