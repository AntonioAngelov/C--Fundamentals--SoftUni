using System;
using System.Linq;
using System.Text;

public class TimeLimitRace : Race
{

    private int goldTime;
    
    public TimeLimitRace(int length, string route, int prizePool, int goldTime)
    : base(length, route, prizePool)
    {
        this.GoldTime = goldTime;
    }

    public int GoldTime
    {
        get { return goldTime; }
        private set { goldTime = value; }
    }

    public override void AddParticipant(int id, Car car)
    {
        if (this.Participants.Count == 0)
        {
            base.AddParticipant(id, car);
        }
    }

    public override int GetPerformance(int id)
    {
        return this.Length * ((this.Participants[id].Horsepower / 100) * this.Participants[id].Acceleration);
    }

    public override string GetScoreboard()
    {
        if (this.Participants.Count == 0)
        {
            return "Cannot start the race with zero participants.";
        }

        var timePerformance = this.GetPerformance(this.Participants.Keys.First());

        StringBuilder board = new StringBuilder();
        board.Append($"{this.Route} - {this.Length}")
            .Append(Environment.NewLine)
            .Append(
                $"{this.Participants.Values.First().Brand} {this.Participants.Values.First().Model} - {timePerformance} s.")
            .Append(Environment.NewLine);

        string prize = string.Empty;

        if (timePerformance <= this.GoldTime)
        {
            prize = $"Gold Time, ${this.PrizePool}.";
        }
        else if (timePerformance <= this.GoldTime + 15)
        {
            prize = $"Silver Time, ${this.PrizePool * 50 / 100}.";
        }
        else
        {
            prize = $"Bronze Time, ${this.PrizePool * 30 / 100}.";
        }

        board.Append(prize);

        return board.ToString();
    }
}

