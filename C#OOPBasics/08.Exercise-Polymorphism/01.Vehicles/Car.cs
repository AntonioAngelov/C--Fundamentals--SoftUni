using System;

public class Car : Vehicle
{
    public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) 
        : base(fuelQuantity, fuelConsumption, tankCapacity)
    { }

    public override void Drive(double distance)
    {
        base.DriveVehicle(distance, 0.9);
    }

    public override void Refuel(double quantity)
    {
        base.Refuel(quantity);

        if (this.FuelQuantity > this.TankCapacity)
        {
            this.FuelQuantity -= quantity;
            Console.WriteLine("Cannot fit fuel in tank");
        }
    }
}

