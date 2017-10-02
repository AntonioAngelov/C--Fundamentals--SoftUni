using System;
using System.Linq;
using System.Text;

public class Book
{
    private string title;
    private string author;
    private decimal price;

    public Book(string author, string title, decimal price)
    {
        this.Author = author;
        this.Title = title;
        this.Price = price;
    }

    public virtual decimal Price
    {
        get { return this.price; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }
            this.price = value; 
        }
    }

    public virtual string Author
    {
        get { return this.author; }
        set
        {
            var splitted = value
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            if (splitted.Length > 1 && splitted[1][0] >= '0' && splitted[1][0]<= '9')
            {
                throw new ArgumentException("Author not valid!"); 
            }
            else
            {
                this.author = value;
            }
        }
    }
    
    public virtual string Title
    {
        get { return this.title; }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }
            this.title = value;
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.Append("Type: ").AppendLine(this.GetType().Name)
        .Append("Title: ").AppendLine(this.Title)
        .Append("Author: ").AppendLine(this.Author)
        .Append("Price: ").Append($"{this.Price:f1}")
        .AppendLine();

        return sb.ToString();
    }

}
