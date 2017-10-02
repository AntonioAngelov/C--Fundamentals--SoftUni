using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

public abstract class Race
{
    private int length;
    private string route;
    private int prizePool;
    private Dictionary<int, Car> participants;

    public Race(int length, string route, int prizePool)
    {
        this.Length = length;
        this.Route = route;
        this.PrizePool = prizePool;
        this.participants = new Dictionary<int, Car>();
    }

    public virtual List<int> Winners
    {
        get
        {
            var winners =
                this.participants.OrderByDescending(p => this.GetPerformance(p.Key))
                    .ThenBy(p => p.Key)
                    .Select(p => p.Key)
                    .Take(3)
                    .ToList();

            return winners;
        }
    }

    public virtual void AddParticipant(int id, Car car)
    {
        this.participants.Add(id, car);
    }

    public IReadOnlyDictionary<int, Car> Participants
    {
        get { return participants; }
    }


    public int PrizePool
    {
        get { return prizePool; }
        private set { prizePool = value; }
    }


    public string Route
    {
        get { return route; }
        private set { route = value; }
    }


    public int Length
    {
        get { return length; }
        private set { length = value; }
    }

    public virtual int GetPerformance(int id)
    {
        Car car = this.Participants[id];

        return (car.Horsepower / car.Acceleration) + (car.Suspension + car.Durability);
    }

    public virtual string GetScoreboard()
    {
        if (this.Participants.Count == 0)
        {
            return "Cannot start the race with zero participants.";
        }

        var winners = this.Winners;

        StringBuilder result = new StringBuilder();
        result.Append($"{this.Route} - {this.Length}")
            .Append(Environment.NewLine);

        int counter = 1;
        int[] percentageMoney = { 50, 30, 20 };

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
