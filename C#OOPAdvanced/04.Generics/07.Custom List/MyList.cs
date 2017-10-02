using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MyList<T>
    where T : IComparable 
{
    private List<T> data;

    public MyList()
    {
        this.data = new List<T>();
    }

    public int Count
    {
        get { return this.data.Count; }
    }

    public void Add(T element)
    {
        this.data.Add(element);
    }

    public T Remove(int index)
    {
        var rem = this.data[index];
        this.data.RemoveAt(index);

        return rem;
    }

    public bool Contains(T element)
    {
        return this.data.Contains(element);
    }

    public void Swap(int index1, int index2)
    {
        var buffer = this.data[index1];
        this.data[index1] = this.data[index2];
        this.data[index2] = buffer;
    }

    public int CountGreaterThan(T element)
    {
        int counter = 0;

        foreach (var el in this.data)
        {
            if (el.CompareTo(element) > 0)
            {
                counter++;
            }
        }

        return counter;
    }

    public T Max()
    {
        return this.data.Max();
    }

    public T Min()
    {
        return this.data.Min();
    }

    public void Print()
    {
        foreach (var el in this.data)
        {
            Console.WriteLine(el);
        }
    }

    public void Sort()
    {
        for (int i = 0; i < this.data.Count - 1; i++)
        {
            for (int k = i + 1; k < this.data.Count; k++)
            {
                if (this.data[i].CompareTo(this.data[k]) > 0)
                {
                    this.Swap(i, k);
                }
            }
        }
    }
}
