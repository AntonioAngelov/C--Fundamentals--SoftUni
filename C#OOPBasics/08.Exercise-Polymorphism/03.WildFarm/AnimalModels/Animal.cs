public abstract class Animal
{
    private string animalName;
    private string animalType;
    private double animalWeight;
    private int foodEaten = 0;

    public Animal(string animalName, string animalType, 
        double animalWeight)
    {
        this.AnimalName = animalName;
        this.AnimalType = animalType;
        this.AnimalWeight = animalWeight;
    }

    public int FoodEaten
    {
        get { return this.foodEaten; }
        protected set { this.foodEaten = value; }
    }


    public double AnimalWeight
    {
        get { return this.animalWeight; }
        private set { this.animalWeight = value; }
    }


    public string AnimalType
    {
        get { return this.animalType; }
        private set { this.animalType = value; }
    }


    public string AnimalName
    {
        get { return this.animalName; }
        private set { this.animalName = value; }
    }

    public abstract void MakeSound();

    public virtual void Eat(Food food)
    {
        this.FoodEaten += food.Quantity;
    }
    
}
