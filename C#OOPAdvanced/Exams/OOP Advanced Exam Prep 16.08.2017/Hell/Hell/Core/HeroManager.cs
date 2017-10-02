using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class HeroManager
    : IManager
{
    private readonly ItemFactory itemFactory;
    private Dictionary<string, IHero> heroes;

    public HeroManager(ItemFactory itemFactory)
    {
        this.itemFactory = itemFactory;
        this.heroes = new Dictionary<string, IHero>();
    }

    public string AddHero(List<String> arguments)
    {
        string result = string.Empty;

        string heroName = arguments[0];
        string heroNameOFType = arguments[1];

        try
        {
            Type heroType = Type.GetType(heroNameOFType);
            var constructors = heroType.GetConstructors();
            
            AbstractHero hero = (AbstractHero)constructors[0].Invoke(new object[] { heroName });
            this.heroes[heroName] = hero;

            result = string.Format($"Created {heroType} - {hero.Name}");
        }
        catch (Exception e)
        {
            return e.Message;
        }

        return result;
    }

    public string AddItemToHero(IList<string> arguments)
    {
        string result = string.Empty;
        string heroName = arguments[1];

        IItem newItem = itemFactory.Create(arguments);
        this.heroes[heroName].AddItem(newItem);

        result = string.Format(Constants.ItemCreateMessage, newItem.Name, heroName);
        return result;
    }

    public string AddRecipeToHero(IList<string> arguments)
    {
        var recipeName = arguments[0];
        var heroName = arguments[1];
        int strengthBonus = int.Parse(arguments[2]);
        int agilityBonus = int.Parse(arguments[3]);
        int intelligenceBonus = int.Parse(arguments[4]);
        int hitPointsBonus = int.Parse(arguments[5]);
        int damageBonus = int.Parse(arguments[6]);
        var neededItems = arguments.Skip(7).ToList();

        IRecipe recipe = new RecipeItem(recipeName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus, neededItems);

        this.heroes[heroName].AddRecipe(recipe);

        return string.Format(Constants.RecipeCreatedMessage, recipeName, heroName);
    }

    public string Inspect(List<String> arguments)
    {
        string heroName = arguments[0];

        return this.heroes[heroName].ToString();
    }

    public string Quit(List<string> args)
    {
        StringBuilder sb = new StringBuilder();

        int counter = 1;

        var orderedHeroes = this.heroes
            .OrderByDescending(h => h.Value.PrimaryStats)
            .ThenByDescending(h => h.Value.SecondaryStats)
            .ToDictionary(x => x.Key, y => y.Value);

        foreach (var hero in orderedHeroes)
        {
            sb.AppendLine($"{counter++}. {hero.Value.GetType().Name}: {hero.Key}");
            sb.AppendLine($"###HitPoints: {hero.Value.HitPoints}");
            sb.AppendLine($"###Damage: {hero.Value.Damage}");
            sb.AppendLine($"###Strength: {hero.Value.Strength}");
            sb.AppendLine($"###Agility: {hero.Value.Agility}");
            sb.AppendLine($"###Intelligence: {hero.Value.Intelligence}");

            if (hero.Value.Items.Count == 0)
            {
                sb.AppendLine($"###Items: None");
            }
            else
            {
                sb.Append($"###Items: ");
                var items = hero.Value.Items.Select(i => i.Name).ToList();
                sb.AppendLine(string.Join(", ", items));
            }
        }

        return sb.ToString().Trim();
    }
}