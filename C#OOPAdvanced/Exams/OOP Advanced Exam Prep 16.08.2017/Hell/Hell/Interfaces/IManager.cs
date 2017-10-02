using System;
using System.Collections.Generic;

public interface IManager
{
    string AddHero(List<string> arguments);

    string AddItemToHero(IList<string> arguments);

    string AddRecipeToHero(IList<string> arguments);

    string Inspect(List<string> arguments);

    string Quit(List<string> args);
}

