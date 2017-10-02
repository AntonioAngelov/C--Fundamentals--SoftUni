using System;
using System.Reflection;
using _01HarestingFields;

public class Startup
{
    static void Main(string[] args)
    {
        Type classType = typeof(HarvestingFields);

        FieldInfo[] allFields = classType.GetFields(BindingFlags.Instance
                                                    | BindingFlags.Static
                                                    | BindingFlags.Public
                                                    | BindingFlags.NonPublic);
        FieldInfo[] protectedFields = classType.GetFields(BindingFlags.NonPublic
                                                          | BindingFlags.Instance);
        FieldInfo[] privateFields = classType.GetFields(BindingFlags.NonPublic
                                                          | BindingFlags.Instance);
        FieldInfo[] publicFields = classType.GetFields(BindingFlags.Public
                                                          | BindingFlags.Instance);


        var input = Console.ReadLine();
        
        while (input != "HARVEST")
        {
            switch (input)
            {
                case "private":
                    foreach (FieldInfo field in privateFields)
                    {
                        if (field.IsPrivate)
                        {
                            Console.WriteLine($"private {field.FieldType.Name} {field.Name}");
                        }
                    }

                    break;
                case "protected":
                    foreach (FieldInfo field in protectedFields)
                    {
                        if (field.IsFamily)
                        {
                            Console.WriteLine($"protected {field.FieldType.Name} {field.Name}");
                        }
                    }

                    break;
                case "public":
                    foreach (FieldInfo field in publicFields)
                    {
                        Console.WriteLine($"public {field.FieldType.Name} {field.Name}");
                    }

                    break;
                case "all":
                    foreach (FieldInfo field in allFields)
                    {
                        string accessModiefierType = String.Empty;
                        if (field.IsPublic)
                        {
                            accessModiefierType = "public";
                        }
                        else if (field.IsFamily)
                        {
                            accessModiefierType = "protected";
                        }
                        else if (field.IsPrivate)
                        {
                            accessModiefierType = "private";
                        }

                        Console.WriteLine($"{accessModiefierType} {field.FieldType.Name} {field.Name}");
                    }
                    break;
            }

            input = Console.ReadLine();
        }
    }
}

