using System;
using System.Collections.Generic;
using System.Text;

public class CarManager
{
    private Dictionary<int, Car> cars;
    private Dictionary<int, Race> races;
    private Garage garage;

    public CarManager()
    {
        this.cars = new Dictionary<int, Car>();
        this.races = new Dictionary<int, Race>();
        this.garage = new Garage();
    }

    public void Register(int id, string type, string brand, string model,
        int yearOfProduction, int horsepower, int acceleration,
        int suspension, int durability)
    {
        if (type == "Performance")
        {
            cars.Add(id, new PerformanceCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability));
        }
        else
        {
            cars.Add(id, new ShowCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability));
        }
    }

    public string Check(int id)
    {
        return cars[id].ToString();
    }

    public void Open(int id, string type, int length, string route, int prizePool, int addedArgument)
    {
        if (type == "Casual")
        {
            races.Add(id, new CasualRace(length, route, prizePool));
        }
        else if (type == "Drag")
        {
            races.Add(id, new DragRace(length, route, prizePool));
        }
        else if(type == "Drift")
        {
            races.Add(id, new DriftRace(length, route, prizePool));
        }
        else if(type == "Circuit")
        {
            races.Add(id, new CircuitRace(length, route, prizePool, addedArgument));
        }
        else
        {
            races.Add(id, new TimeLimitRace(length, route, prizePool, addedArgument));
        }
    }

    public void Participate(int carId, int raceId)
    {
        if (!cars[carId].IsParked)
        {
            races[raceId].AddParticipant(carId, cars[carId]);
            cars[carId].NumberOfRacsPerticipatig += 1;
        }
    }

    public string Start(int id)
    {
        var race = races[id];

        return race.GetScoreboard();
    }

    public void Park(int id)
    {
        if (cars[id].NumberOfRacsPerticipatig == 0)
        {
            garage.AddToGarage(cars[id]);
            cars[id].IsParked = true;
        }
    }

    public void Unpark(int id)
    {
        var car = cars[id];
        garage.RemoveFromGarange(car);
        car.IsParked = false;
    }

    public void Tune(int tuneIndex, string addOn)
    {
        foreach (var car in garage.ParkedCars)
        {
            car.Tune(tuneIndex, addOn);
        }
    }
}

