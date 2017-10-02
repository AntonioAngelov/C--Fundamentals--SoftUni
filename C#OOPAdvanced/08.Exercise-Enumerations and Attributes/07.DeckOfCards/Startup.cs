using System;
using System.Collections.Generic;

public class Startup
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine();

        PrintDeck();
    }

    private static void PrintDeck()
    {
        List<Card> deck = GenerateDeck();

        foreach (var card in deck)
        {
            Console.WriteLine(card);
        }
    }

    private static List<Card> GenerateDeck()
    {
        List<Card> deck = new List<Card>();

        var ranks = Enum.GetNames(typeof(Rank));
        var suits = Enum.GetNames(typeof(Suit));

        foreach (var suit in suits)
        {
            foreach (var rank in ranks)
            {
              deck.Add(new Card(rank, suit));  
            }
        }

        return deck;
    }
}

