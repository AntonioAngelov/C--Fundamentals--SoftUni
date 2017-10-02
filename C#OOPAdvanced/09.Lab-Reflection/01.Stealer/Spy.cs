using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string nameOfClass, params string[] namesOfFields)
    {
        Type classType = Type.GetType(nameOfClass);
        FieldInfo[] fieldsInfo = classType.GetFields(BindingFlags.Instance 
                                                     | BindingFlags.NonPublic 
                                                     | BindingFlags.Public 
                                                     | BindingFlags.Static);

        Object classInstance = Activator.CreateInstance(classType, new object[] {});

        StringBuilder resultInfo = new StringBuilder();
        resultInfo.AppendLine($"Class under investigation: {nameOfClass}");

        foreach (FieldInfo fieldInfo in fieldsInfo.Where(f => namesOfFields.Contains(f.Name)))
        {
            resultInfo.AppendLine($"{fieldInfo.Name} = {fieldInfo.GetValue(classInstance)}");
        }

        return resultInfo.ToString().Trim();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        Type classType = Type.GetType(className);
        FieldInfo[] fieldsInfo = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
        MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance);
        MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        StringBuilder resultInfo = new StringBuilder();

        foreach (FieldInfo fieldInfo in fieldsInfo)
        {
            resultInfo.AppendLine($"{fieldInfo.Name} must be private!");
        }

        foreach (MethodInfo method in classNonPublicMethods.Where(m => m.Name.StartsWith("get")))
        {
            resultInfo.AppendLine($"{method.Name} have to be public!");
        }

        foreach (MethodInfo method in classPublicMethods.Where(m => m.Name.StartsWith("set")))
        {
            resultInfo.AppendLine($"{method.Name} have to be private!");
        }

        return resultInfo.ToString().Trim();
    }

    public string RevealPrivateMethods(string className)
    {
        Type classType = Type.GetType(className);

        MethodInfo[] methodsInfo =
            classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        StringBuilder resultInfo = new StringBuilder();

        resultInfo.AppendLine($"All Private Methods of Class: {className}");
        resultInfo.AppendLine($"Base Class: {classType.BaseType.Name}");

        foreach (MethodInfo method in methodsInfo)
        {
            resultInfo.AppendLine(method.Name);
        }

        return resultInfo.ToString().Trim();
    }

    public string CollectGettersAndSetters(string className)
    {
        Type type = Type.GetType(className);

        MethodInfo[] methods =
            type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                
        StringBuilder result = new StringBuilder();

        foreach (MethodInfo getter in methods.Where(m => m.Name.StartsWith("get")))
        {
            result.AppendLine($"{getter.Name} will return {getter.ReturnType}");
        }

        foreach (MethodInfo setter in methods.Where(m => m.Name.StartsWith("set")))
        {
            result.AppendLine($"{setter.Name} will set field of {setter.GetParameters().First().ParameterType}");
        }

        return result.ToString().Trim();
    }
}
