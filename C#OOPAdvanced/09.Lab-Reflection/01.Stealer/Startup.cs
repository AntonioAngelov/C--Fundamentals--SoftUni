using System;

public class Startup
{
    public static void Main(string[] args)
    {
        //exercise 1
        //Stealer();

        //exercise 2
        //HightQualityMistakes();

        //exercise 3
        //MissionPrivateImpossible();
        
        //exercise 4
        Collector();

    }

    private static void Collector()
    {
        Spy spy = new Spy();
        string result = spy.CollectGettersAndSetters("Hacker");
        Console.WriteLine(result);
    }

    private static void MissionPrivateImpossible()
    {
        Spy spy = new Spy();
        string result = spy.RevealPrivateMethods("Hacker");
        Console.WriteLine(result);
    }

    private static void HightQualityMistakes()
    {
        Spy spy = new Spy();

        string result = spy.AnalyzeAcessModifiers("Hacker");
        Console.WriteLine(result);
    }

    private static void Stealer()
    {
        Spy spy = new Spy();

        string result = spy.StealFieldInfo("Hacker", "username", "password");
        Console.WriteLine(result);
    }
}

