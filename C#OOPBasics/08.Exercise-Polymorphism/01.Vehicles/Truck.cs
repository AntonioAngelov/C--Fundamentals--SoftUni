using System;

public class Truck : Vehicle
{
    public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : 
        base(fuelQuantity, fuelConsumption, tankCapacity)
    { }

    public override void Refuel(double quantity)
    {
        base.Refuel(quantity * 0.95);
    }

    public override void Drive(double distance)
    {
      base.DriveVehicle(distance, 1.6);
    }
}
