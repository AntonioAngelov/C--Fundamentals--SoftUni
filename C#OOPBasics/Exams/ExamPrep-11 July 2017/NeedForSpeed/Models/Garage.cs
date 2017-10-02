using System.Collections.Generic;
using System.Linq;

public class Garage
{
    private List<Car> parkedCars;

    public Garage()
    {
        this.parkedCars = new List<Car>();
    }

    public List<Car> ParkedCars
    {
        get { return parkedCars; }
    }

    public void AddToGarage(Car car)
    {
        this.parkedCars.Add(car);
    }

    public void RemoveFromGarange(Car car)
    {
        this.parkedCars.Remove(car);
    }

}
