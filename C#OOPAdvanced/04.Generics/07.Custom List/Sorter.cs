using System;

public static class Sorter
{
    public static void Sort<T>(MyList<T> list)
        where T : IComparable
    {
        list.Sort();
    }
}

