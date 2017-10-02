using System;
using System.Collections;
using System.Collections.Generic;

public class ListyIterator<T> : IEnumerable<T>
{
    private readonly List<T> elements;
    private int currentIndex;

    public ListyIterator(List<T> elements)
    {
        this.elements = elements;
        this.currentIndex = 0;
    }

    public bool Move()
    {
        if (this.HasNext())
        {
            ++this.currentIndex;
            return true;
        }

        return false;
    }

    public bool HasNext()
    {
        return this.currentIndex < this.elements.Count - 1;
    }

    public void Print()
    {
        if (this.elements.Count != 0)
        {
            Console.WriteLine(this.elements[this.currentIndex]);
        }
        else
        {
            throw new IndexOutOfRangeException("Invalid Operation!");
        }

    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.elements.Count; i++)
        {
            yield return this.elements[i];
        }
    }

    public void PrintAll()
    {
        Console.WriteLine(string.Join(" ", this.elements));
    }
}
