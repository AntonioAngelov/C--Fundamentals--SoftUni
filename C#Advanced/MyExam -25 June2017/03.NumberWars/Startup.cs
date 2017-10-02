namespace _03.NumberWars
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        static void Main(string[] args)
        {
            var playerOne = new Queue<string>(Console.ReadLine()
                .Split(' ')
                .ToList());

            var playerTwo = new Queue<string>(Console.ReadLine()
                .Split(' ')
                .ToList());

            var turns = 0;
            
            while (turns <= 1000000 && playerOne.Count > 0 && playerTwo.Count > 0)
            {
                turns++;

                var cardPlayerOne = playerOne.Dequeue();
                var cardPlayerTwo = playerTwo.Dequeue();

                var winersCards = new List<string>();
                winersCards.Add(cardPlayerTwo);
                winersCards.Add(cardPlayerOne);

                long numPlayerOne = long.Parse(cardPlayerOne.Substring(0, cardPlayerOne.Length - 1).ToString());
                long numPlayerTwo = long.Parse(cardPlayerTwo.Substring(0, cardPlayerTwo.Length - 1).ToString());

                winersCards = winersCards.OrderByDescending(c => long.Parse(c.Substring(0, c.Length - 1).ToString())).ThenByDescending(c => c[c.Length - 1].ToString().ToLower()).ToList();

                if (numPlayerOne > numPlayerTwo)
                {
                    for (int i = 0; i < winersCards.Count; i++)
                    {
                        playerOne.Enqueue(winersCards[i]);
                    }
                }
                else if (numPlayerTwo > numPlayerOne)
                {
                    for (int i = 0; i < winersCards.Count; i++)
                    {
                        playerTwo.Enqueue(winersCards[i]);
                    }
                }
                else
                {
                    var playerOneSum = 0;
                    var playerTwoSum = 0;

                    while (playerOneSum == playerTwoSum && playerOne.Count > 0 && playerTwo.Count > 0)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (playerOne.Count == 0 || playerTwo.Count == 0)
                            {
                                break;
                            }

                            cardPlayerOne = playerOne.Dequeue();
                            cardPlayerTwo = playerTwo.Dequeue();

                            winersCards.Add(cardPlayerOne);
                            winersCards.Add(cardPlayerTwo);

                            playerOneSum += (int)cardPlayerOne.ToLower().Last() - 96;
                            playerTwoSum += (int)cardPlayerTwo.ToLower().Last() - 96;
                        }

                        winersCards = winersCards.OrderByDescending(c => long.Parse(c.Substring(0, c.Length - 1).ToString())).ThenByDescending(c => c[c.Length - 1].ToString().ToLower()).ToList();
                        
                    }
                    

                    if (playerOneSum > playerTwoSum)
                    {
                        for (int i = 0; i < winersCards.Count; i++)
                        {
                            playerOne.Enqueue(winersCards[i]);
                        }
                    }
                    else if(playerTwoSum > playerOneSum)
                    {
                        for (int i = 0; i < winersCards.Count; i++)
                        {
                            playerTwo.Enqueue(winersCards[i]);
                        }
                    }
                }
                
            }
            
                var playerOneCount = playerOne.Count;
                var playerTwoCount = playerTwo.Count;

                if (playerOneCount > playerTwoCount)
                {
                    Console.WriteLine($"First player wins after {turns} turns");
                }
                else if (playerTwoCount > playerOneCount)
                {
                    Console.WriteLine($"Second player wins after {turns} turns");
                }
                else
                {
                    Console.WriteLine($"Draw after {turns} turns");
                }
            




        }
    }
}
