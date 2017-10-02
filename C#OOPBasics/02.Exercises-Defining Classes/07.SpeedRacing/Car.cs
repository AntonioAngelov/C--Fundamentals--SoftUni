using System;

public class Car
{
    public Car(string model, double fuelAmount, double consumption)
    {
        this.Model = model;
        this.FuelAmount = fuelAmount;
        this.PerKilometerConsumption = consumption;
        this.DistanceTraveled = 0;
    }

    public string Model { get; set; }

    public double FuelAmount { get; set; }

    public double PerKilometerConsumption { get; set; }

    public double DistanceTraveled { get; set; }

    public void Drive(double amountOfKM)
    {
        var consumption = amountOfKM * this.PerKilometerConsumption;
        if (consumption > this.FuelAmount)
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
        else
        {
            this.DistanceTraveled += amountOfKM;
            this.FuelAmount -= consumption;
        }
    }

    public override string ToString()
    {
        return $"{this.Model} {this.FuelAmount:f2} {this.DistanceTraveled}";
    }
}
