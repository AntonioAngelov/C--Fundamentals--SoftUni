using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Society
{
    private List<IIdentifiable> inhabitants;
    private List<IBirthdate> petsAndCitizens;
    
    public Society()
    {
        this.inhabitants = new List<IIdentifiable>();
        this.petsAndCitizens = new List<IBirthdate>();
    }

    public void AddInhabitant(IIdentifiable inhabitant)
    {
        this.inhabitants.Add(inhabitant);
    }

    public void AddPetOrCitizen(IBirthdate petOrCitizen)
    {
        this.petsAndCitizens.Add(petOrCitizen);
    }

    public string Detain(string suffix)
    {
        StringBuilder result = new StringBuilder();

        var detained = this.inhabitants.Where(i => i.Id.EndsWith(suffix));

        foreach (var d in detained)
        {
            result.Append(d.Id)
                .Append(Environment.NewLine);
        }

        if (detained.Count() != 0)
        {
            result.Remove(result.Length - 1, 1);
        }

        return result.ToString();
    }

    public string GetBurthdatesInYear(string year)
    {
        var dates = this.petsAndCitizens
            .Where(pc => pc.Birthdate.EndsWith($"/{year}"))
            .Select(pc => pc.Birthdate);

        StringBuilder result = new StringBuilder();

        int counter = 1;

        foreach (var date in dates)
        {
            result.Append(date);

            if (counter != dates.Count())
            {
                result.Append(Environment.NewLine);
            }

            counter++;
        }
        
        return result.ToString();
    }
}
