public class HappynessFactory
{
    public static int GetHappyness(string food)
    {
        food = food.ToLower();

        var happiness = -1;

        switch (food)
        {
            case "cram":
                happiness = 2;
                break;
            case "lembas":
                happiness = 3;
                break;
            case "apple":
            case "melon":
                happiness = 1;
                break;
            case "honeycake":
                happiness = 5;
                break;
            case "mushrooms":
                happiness = -10;
                break;
        }

        return happiness;
    }

}

