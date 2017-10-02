using System;
using System.Text;

public abstract class Car
{
    private string brand;
    private string model;
    private int yearOfProduction;
    private int horsepower;
    private int acceleration;
    private int suspension;
    private int durability;
    private int numberOFRacesPerticipating;
    private bool isParked;

    public Car(string brand,string model, int yearOfProduction, int horsepower,
        int acceleration, int suspension, int durability)
    {
        this.Brand = brand;
        this.Model = model;
        this.YearOfProduction = yearOfProduction;
        this.Horsepower = horsepower;
        this.Acceleration = acceleration;
        this.Suspension = suspension;
        this.Durability = durability;
        this.NumberOfRacsPerticipatig = 0;
        this.IsParked = false;
    }

    public bool IsParked
    {
        get { return this.isParked; }
        set { this.isParked = value; }
    }

    public int NumberOfRacsPerticipatig
    {
        get { return this.numberOFRacesPerticipating; }
        set { this.numberOFRacesPerticipating = value; }
    }

    public int Durability
    {
        get { return durability; }
        set { durability = value; }
    }


    public int Suspension
    {
        get { return suspension; }
        private set { suspension = value; }
    }


    public int Acceleration
    {
        get { return acceleration; }
        private set { acceleration = value; }
    }


    public int Horsepower
    {
        get { return horsepower; }
        private set { horsepower = value; }
    }


    public int YearOfProduction
    {
        get { return yearOfProduction; }
        private set { yearOfProduction = value; }
    }


    public string Model
    {
        get { return model; }
        private set { model = value; }
    }


    public string Brand
    {
        get { return brand; }
        private set { brand = value; }
    }

    public virtual void Tune(int index, string addon)
    {
        this.Horsepower += index;
        this.Suspension += index / 2;
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        result.Append($"{this.Brand} {this.Model} {this.YearOfProduction}")
            .Append(Environment.NewLine)
            .Append($"{this.Horsepower} HP, 100 m/h in {this.Acceleration} s")
            .Append(Environment.NewLine)
            .Append($"{this.Suspension} Suspension force, {this.Durability} Durability");

        return result.ToString();
    }
}

