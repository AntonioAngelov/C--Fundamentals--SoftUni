using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.HandsOfCards
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var scores = new Dictionary<string, int>();

            while (true)
            {
                var input = Console.ReadLine();
                    
                if (input == "JOKER")
                {
                    break;
                }

                var data = input
                    .Split(':')
                    .ToArray();
                var name = data[0];
                var cards = data[1]
                    .Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries);
                var uniqueCards = new HashSet<string>(cards);

                var score = GetScore(uniqueCards);

                if (!scores.ContainsKey(name))
                {
                    scores.Add(name, score);
                }
                else
                {
                    scores[name] += score;
                }

            }

            foreach (var player in scores.Keys)
            {
                Console.WriteLine($"{player}: {scores[player]}");
            }
        }

        public static int GetScore(HashSet<string> cards)
        {
            var score = 0;

            foreach (var card in cards)
            {
                var power = 0;
                var multiplier = 1;
                switch (card[0])
                {
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        power = int.Parse(card[0].ToString());
                        break;
                    case '1':
                        power = 10;
                        break;
                    case 'J':
                        power = 11;
                        break;
                    case 'Q':
                        power = 12;
                        break;
                    case 'K':
                        power = 13;
                        break;
                    case 'A':
                        power = 14;
                        break;
                }

                switch (card.Last())
                {
                    case 'S':
                        multiplier = 4;
                        break;
                    case 'H':
                        multiplier = 3;
                        break;
                    case 'D':
                        multiplier = 2;
                        break;
                    case 'C':
                        multiplier = 1;
                        break;
                }

                score += multiplier * power;

            }

            return score;
        }
    }
}
