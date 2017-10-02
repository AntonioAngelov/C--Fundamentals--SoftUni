using System;

public class Card : IComparable<Card>
{
    public Card(string rank, string suit)
    {
        this.Rank = (Rank)Enum.Parse(typeof(Rank), rank);
        this.Suit = (Suit)Enum.Parse(typeof(Suit), suit);
        this.Power = (int)this.Suit + (int)this.Rank;
    }

    public Rank Rank { get; private set; }

    public Suit Suit { get; private set; }

    public int Power { get; private set; }

    public override string ToString()
    {
        return $"{this.Rank} of {this.Suit}";
    }

    public int CompareTo(Card other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;

        if (this.Suit == other.Suit && this.Rank == other.Rank)
        {
            return 0;
        }
        else
        {
            return this.Power.CompareTo(other.Power);
        }
    }
}
