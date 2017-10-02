using System;

public abstract class Vehicle
{
    private double fuelQuantity;
    private double fuelConsumption;
    private double tankCapacity;
    
    public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumption = fuelConsumption;
        this.TankCapacity = tankCapacity;
    }

    public double TankCapacity
    {
        get { return this.tankCapacity; }
        private set { this.tankCapacity = value; }
    }

    public double FuelConsumption
    {
        get { return fuelConsumption; }
        protected set
        {
            if (value <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else
            {
                fuelConsumption = value;
            }
        }
    }

    public double FuelQuantity
    {
        get { return this.fuelQuantity; }
        protected set { this.fuelQuantity = value; }
    }

    public virtual void Refuel(double quantity)
    {
        if (quantity <= 0)
        {
            Console.WriteLine("Fuel must be a positive number");
        }
        else
        {
            this.FuelQuantity += quantity;
        }
    }

    protected void DriveVehicle(double distance, double addedConsumprion)
    {
        var fuelNeeded = distance * (this.FuelConsumption + addedConsumprion);

        if (fuelNeeded > this.FuelQuantity)
        {
            Console.WriteLine($"{this.GetType().Name} needs refueling");
        }
        else
        {
            this.FuelQuantity -= fuelNeeded;
            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
        }
    }

    public abstract void Drive(double distance);

    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
    }
}