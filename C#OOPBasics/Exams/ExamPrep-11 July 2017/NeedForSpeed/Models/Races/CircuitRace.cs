using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CircuitRace : Race 
{
    private int laps;

    public int Laps
    {
        get { return laps; }
        private set { laps = value; }
    }


    public CircuitRace(int length, string route, int prizePool, int laps) 
        : base(length, route, prizePool)
    {
        this.Laps = laps;
    }

    public override List<int> Winners
    {
        get
        {
            Dictionary<int, Car> participantsBuffer = new Dictionary<int, Car>(this.Participants.ToDictionary(p => p.Key, p => p.Value));

            var durabilityDecrease = this.Length * this.Length;

            for (int i = 0; i < this.Laps; i++)
            {
                foreach (var id in participantsBuffer.Keys)
                {
                    participantsBuffer[id].Durability -= durabilityDecrease;
                }
            }

            var winners =
                participantsBuffer.OrderByDescending(p => this.GetPerformance(p.Key))
                    .ThenBy(p => p.Key)
                    .Select(p => p.Key)
                    .Take(4)
                    .ToList();

            return winners;

        }
    }

    public override string GetScoreboard()
    {
        if (this.Participants.Count == 0)
        {
            return "Cannot start the race with zero participants.";
        }

        var winners = this.Winners;

        StringBuilder result = new StringBuilder();
        result.Append($"{this.Route} - {this.Length * this.Laps}")
            .Append(Environment.NewLine);

        int counter = 1;
        int[] percentageMoney = { 40, 30, 20, 10 };

        foreach (var w in winners)
        {
            var winner = this.Participants[w];

            result.Append(
                $"{counter}. {winner.Brand} {winner.Model} {this.GetPerformance(w)}PP - ${this.PrizePool * percentageMoney[counter - 1] / 100}");

            if (counter != winners.Count)
            {
                result.Append(Environment.NewLine);
            }

            counter++;
        }

        foreach (var p in this.Participants.Values)
        {
            p.NumberOfRacsPerticipatig -= 1;
        }

        return result.ToString();
    }
}

