using System;

public class Startup
{
    static void Main(string[] args)
    {
        Rank rankCard1 = (Rank) Enum.Parse(typeof(Rank), Console.ReadLine().Trim());
        Suit suitCard1 = (Suit)Enum.Parse(typeof(Suit), Console.ReadLine().Trim());

        Rank rankCard2 = (Rank)Enum.Parse(typeof(Rank), Console.ReadLine().Trim());
        Suit suitCard2 = (Suit)Enum.Parse(typeof(Suit), Console.ReadLine().Trim());

        Card card1 = new Card(rankCard1, suitCard1);
        Card card2 = new Card(rankCard2, suitCard2);

        if (card1.CompareTo(card2) > 0)
        {
            Console.WriteLine(card1);
        }
        else
        {
            Console.WriteLine(card2);
        }
    }
}

