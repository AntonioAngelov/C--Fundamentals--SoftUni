using System.Collections.Generic;

public class StackOfStrings
{
    private List<string> data;

    public StackOfStrings()
    {
        this.data = new List<string>();
    }

    public void Push(string item)
    {
        data.Add(item);
    }

    public string Peek()
    {
        return data[data.Count - 1];
    }

    public string Pop()
    {
        var popped = this.Peek();
        this.data.RemoveAt(data.Count - 1);

        return popped;
    }

    public bool IsEmpty()
    {
        return this.data.Count == 0;
    }
}

