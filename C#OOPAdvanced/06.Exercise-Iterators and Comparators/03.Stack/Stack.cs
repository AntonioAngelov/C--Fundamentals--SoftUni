using System;
using System.Collections;
using System.Collections.Generic;

public class Stack<T> : IEnumerable<T>
{
    private List<T> data;

    public Stack()
    {
        this.data = new List<T>();
    }

    public void Push(T element)
    {
        this.data.Add(element);
    }

    public T Pop()
    {
        if (this.data.Count != 0)
        {
            var result = this.data[this.data.Count - 1];
            this.data.RemoveAt(this.data.Count - 1);
            return result;
        }

        throw new IndexOutOfRangeException("No elements");
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.data.Count - 1; i >= 0; i--)
        {
            yield return this.data[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

