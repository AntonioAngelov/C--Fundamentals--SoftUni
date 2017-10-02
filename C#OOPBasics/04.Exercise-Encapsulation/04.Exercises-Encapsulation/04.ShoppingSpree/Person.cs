using System;
using System.Collections.Generic;
using System.Linq;

public class Person
{
    private string name;
    private double money;
    private List<Product> products;

    public Person(string name, double money)
    {
        this.Name = name;
        this.Money = money;
        this.products = new List<Product>();
    }

    public IReadOnlyCollection<Product> Products
    {
        get { return this.products.AsReadOnly(); }
    }

    public double Money
    {
        get { return this.money; }
        private set
        {
            if (value >= 0)
            {
                this.money = value;
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
        private set
        {
            if (!String.IsNullOrEmpty(value) && value != " ")
            {
                this.name = value;
            }
            else
            {
                throw new ArgumentException("Name cannot be empty");
            }
        }
    }

    public void AdProductToBag(Product product)
    {
        if (this.money >= product.Cost)
        {
            this.money -= product.Cost;
            products.Add(product);
            Console.WriteLine($"{this.name} bought {product.Name}");
        }
        else
        {
            Console.WriteLine($"{this.name} can't afford {product.Name}");
        }
    }

    public override string ToString()
    {
        var result = this.Products.Count > 0 ? $"{this.Name} - {string.Join(", ", this.Products.Select(p => p.Name))}" : $"{this.Name} - Nothing bought";

        return result;
    }
}
