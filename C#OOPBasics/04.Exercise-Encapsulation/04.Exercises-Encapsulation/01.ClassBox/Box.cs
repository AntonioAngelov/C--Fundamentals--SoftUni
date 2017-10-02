using System;
using System.Threading;

public class Box
{
    private double length;
    private double width;
    private double height;

    public Box(double length, double width, double height)
    {
        this.Lenght = length;
        this.Width = width;
        this.Height = height;
    }

    public double Lenght
    {
        get { return this.length; }
        private set
        {
            if (value > 0)
            {
                this.length = value;
            }
            else
            {
                throw new ArgumentException("Length cannot be zero or negative.");
            }
        }
    }

    public double Width
    {
        get { return this.width; }
        private set
        {
            if (value > 0)
            {
                this.width = value;
            }
            else
            {
                throw new ArgumentException("Width cannot be zero or negative.");
            }
        }
    }

    public double Height
    {
        get { return this.height; }
        private set
        {
            if (value > 0)
            {
                this.height = value;
            }
            else
            {
                throw new ArgumentException("Height cannot be zero or negative.");
            }
        }
    }

    public double SurfaceAre()
    {
        return 2 * (this.height * this.width) +
               2 * (this.height * this.length) +
               2 * (this.width * this.length);
    }

    public double LateralSurfaceArea()
    {
        return 2 * this.length * this.height +
               2 * this.width * this.height;
    }

    public double Volume()
    {
        return this.width * this.length * this.height;
    }
}

