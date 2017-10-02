using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main(string[] args)
    {
        //exercise 01
        //GenericBoxOfString();

        //exercise 02
        //GenericBoxOfInteger();

        //exercise 03
        //GenericSwapMethodStrings();

        //exercise 04
        //GenericSwapMethodInteger();

        //exercise 05
        //GenericCountMethodString();

        //exercise 06
        GenericCountMethodDouble();

    }

    private static void GenericCountMethodDouble()
    {
        var n = int.Parse(Console.ReadLine());

        List<double> list = new List<double>();

        for (int i = 0; i < n; i++)
        {
            list.Add(double.Parse(Console.ReadLine()));
        }

        Console.WriteLine(GetGreaterElements<double>(list, double.Parse(Console.ReadLine())));
    }

    private static int GetGreaterElements<T>(List<T> list, T element) where T : IComparable
    {
        int counter = 0;

        foreach (var el in list)
        {
            if (el.CompareTo(element) > 0)
            {
                counter++;
            }
        }

        return counter;
    }

    private static void GenericCountMethodString()
    {
        var n = int.Parse(Console.ReadLine());

        List<string> list = new List<string>();

        for (int i = 0; i < n; i++)
        {
            list.Add(Console.ReadLine());
        }

        Console.WriteLine(GetGreaterElements<string>(list, Console.ReadLine()));
    }

    private static void GenericSwapMethodInteger()
    {
        var n = int.Parse(Console.ReadLine());

        List<Box<int>> list = new List<Box<int>>();

        for (int i = 0; i < n; i++)
        {
            var value = int.Parse(Console.ReadLine());

            Box<int> box = new Box<int>(value);
            list.Add(box);
        }

        var indexes = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToList();

        SwapElements(indexes[0], indexes[1], list);

        foreach (var element in list)
        {
            Console.WriteLine(element.ToString());
        }
    }

    private static void SwapElements<T>(int index1, int index2, List<T> list)
    {
        var buffer = list[index1];
        list[index1] = list[index2];
        list[index2] = buffer;
    }

    private static void GenericSwapMethodStrings()
    {
        var n = int.Parse(Console.ReadLine());

        List<Box<string>> list = new List<Box<string>>();

        for (int i = 0; i < n; i++)
        {
            var value = Console.ReadLine();

            Box<string> box = new Box<string>(value);
            list.Add(box);
        }

        var indexes = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToList();

        SwapElements(indexes[0], indexes[1], list);

        foreach (var element in list)
        {
            Console.WriteLine(element.ToString());
        }

    }

    private static void GenericBoxOfInteger()
    {
        var n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var value = int.Parse(Console.ReadLine());

            Box<int> box = new Box<int>(value);
            Console.WriteLine(box.ToString());
        }
    }

    private static void GenericBoxOfString()
    {
        var n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var value = Console.ReadLine();

            Box<string> box = new Box<string>(value);
            Console.WriteLine(box.ToString());
        }
    }
}

