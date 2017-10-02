using System;

public class TrafficLight
{
    public TrafficLight(string signal)
    {
        this.Signal = (Signal)Enum.Parse(typeof(Signal), signal);
    }

    public Signal Signal { get; private set; }

    public void ChangeSignal()
    {
        if (this.Signal == Signal.Red)
        {
            this.Signal = Signal.Green;
        }
        else if (this.Signal == Signal.Green)
        {
            this.Signal = Signal.Yellow;
        }
        else
        {
            this.Signal = Signal.Red;
        }
    }

    public override string ToString()
    {
        return this.Signal.ToString();
    }
}