using System;

public class Product
{
    private string name;

    private double cost;

    public Product(string name, double cost)
    {
        this.Name = name;
        this.Cost = cost;
    }

    public double Cost
    {
        get { return this.cost; }
        set
        {
            if (value >= 0)
            {
                this.cost = value;
            }
            else
            {
                throw new ArgumentException("Money cannot be negative");
            }
        }
    }
    
    public string Name
    {
        get { return this.name; }
        set
        {
            if (!String.IsNullOrEmpty(value) && value != " ")
            {
                this.name = value;
            }
            else
            {
                throw new ArgumentException("Value does not fall within the expected range.");
            }
        }
    }

}

