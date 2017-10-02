using System;
using System.Collections.Generic;

public class CoffeeMachine
{
    private List<CoffeeType> coffeeSold;
    private int coins;

    public CoffeeMachine()
    {
          this.coffeeSold = new List<CoffeeType>(); 
    }

    public IEnumerable<CoffeeType> CoffeesSold => this.coffeeSold;

    public void InsertCoin(string coin)
    {
        Coin rem = (Coin) Enum.Parse(typeof(Coin), coin);
        this.coins += (int) rem;
    }

    public void BuyCoffee(string size, string type)
    {
        CoffeeType coffeType = (CoffeeType) Enum.Parse(typeof(CoffeeType), type);
        CoffeePrice coffeePrice = (CoffeePrice) Enum.Parse(typeof(CoffeePrice), size);

        if ((int)coffeePrice <= this.coins)
        {
            this.coffeeSold.Add(coffeType);
            this.coins = 0;
        }


    }
}
