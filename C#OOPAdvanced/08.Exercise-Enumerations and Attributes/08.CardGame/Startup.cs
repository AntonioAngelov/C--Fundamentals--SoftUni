using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    static void Main(string[] args)
    {
        var player1 = Console.ReadLine();
        var player2 = Console.ReadLine();

        List<Card> cardsPlayer1 = new List<Card>();
        List<Card> cardsPlayer2 = new List<Card>();

        FillDeck(cardsPlayer1, cardsPlayer2);
        FillDeck(cardsPlayer2, cardsPlayer1);

        Card powerPlayer1 = cardsPlayer1.OrderByDescending(c => c.Power).FirstOrDefault();
        Card powerPlayer2 = cardsPlayer2.OrderByDescending(c => c.Power).FirstOrDefault();

        if (powerPlayer1.Power > powerPlayer2.Power)
        {
            Console.WriteLine($"{player1} wins with {powerPlayer1}.");
        }
        else
        {
            Console.WriteLine($"{player2} wins with {powerPlayer2}.");
        }
    }

    private static void FillDeck(List<Card> deck, List<Card> deck2)
    {
        var ranks = Enum.GetNames(typeof(Rank));
        var suits = Enum.GetNames(typeof(Suit));

        while (deck.Count < 5)
        {
            var data = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            if (!ranks.Contains(data[0]) || !suits.Contains(data[2]))
            {
                Console.WriteLine("No such card exists.");
                continue;
            }
            
            Card currentCard = new Card(data[0], data[2]);

            if (deck.Any(c => c.CompareTo(currentCard) == 0) || deck2.Any(c => c.CompareTo(currentCard) == 0))
            {
                Console.WriteLine("Card is not in the deck.");
                continue;
            }

            deck.Add(currentCard);
        }
    }
}

