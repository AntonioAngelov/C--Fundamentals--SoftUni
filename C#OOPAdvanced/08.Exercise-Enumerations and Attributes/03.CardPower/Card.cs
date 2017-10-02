using System;

public class Card : IComparable<Card>
{
    public Card(Rank rank, Suit suit)
    {
        this.Rank = rank;
        this.Suit = suit;
        this.Power = (int) this.Suit + (int) this.Rank;
    }

    public Rank Rank { get; private set; }

    public Suit Suit { get; private set; }

    public int Power { get; private set; }

    public override string ToString()
    {
        return $"Card name: {this.Rank} of {this.Suit}; Card power: {this.Power}";
    }

    public int CompareTo(Card other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        
        return this.Power.CompareTo(other.Power);
    }
}
