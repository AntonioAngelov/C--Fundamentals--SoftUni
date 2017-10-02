public class MoodFactory
{
    public static string GetMood(int happyness)
    {
        string mood = string.Empty;

        if (happyness < -5)
        {
            mood = "Angry";
        }
        else if (happyness >= -5 && happyness <= 0)
        {
            mood = "Sad";
        }
        else if (happyness >= 1 && happyness <= 15)
        {
            mood = "Happy";
        }
        else
        {
            mood = "JavaScript";
        }

        return mood;
    }
}

