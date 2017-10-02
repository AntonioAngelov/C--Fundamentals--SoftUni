using System;

public class Card 
{
    public Card(string rank, string suit)
    {
        this.Rank = (Rank)Enum.Parse(typeof(Rank), rank);
        this.Suit = (Suit)Enum.Parse(typeof(Suit), suit);
        this.Power = (int) this.Suit + (int) this.Rank;
    }

    public Rank Rank { get; private set; }

    public Suit Suit { get; private set; }

    public int Power { get; private set; }

    public override string ToString()
    {
        return $"{this.Rank} of {this.Suit}";
    }
    
}
