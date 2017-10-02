using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Lake : IEnumerable<int>
{
    private List<int> stones;

    public Lake(List<int> stones)
    {
        this.stones = stones;
    }

    
    public void CrossLake()
    {
        Console.WriteLine(string.Join(", ", this.stones));
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public IEnumerator<int> GetEnumerator()
    {
        List<int> oddStones = new List<int>();
        List<int> evenStones = new List<int>();

        for (int i = 0; i < this.stones.Count; i++)
        {
            if (i % 2 == 0)
            {
                evenStones.Add(this.stones[i]);
            }
            else
            {
                oddStones.Add(this.stones[i]);
            }
        }

        foreach (var es in evenStones)
        {
            yield return es;
        }

        oddStones.Reverse();
        foreach (var os in oddStones)
        {
            yield return os;
        }
    }
    
}

