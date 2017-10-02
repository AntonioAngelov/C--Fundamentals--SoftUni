using System;
using System.Linq;
using System.Reflection;

public class Startup
{
    static void Main(string[] args)
    {
        Type classType = typeof(BlackBoxInt);

        ConstructorInfo constructor = classType.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance).First();

        BlackBoxInt classInstance = (BlackBoxInt) constructor.Invoke(new object[] {0});   
        FieldInfo containerField = classType.GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic);

        MethodInfo addMethod = classType.GetMethod("Add", BindingFlags.NonPublic | BindingFlags.Instance);
        MethodInfo subtractMethod = classType.GetMethod("Subtract", BindingFlags.NonPublic | BindingFlags.Instance);
        MethodInfo divideMethod = classType.GetMethod("Divide", BindingFlags.NonPublic | BindingFlags.Instance);
        MethodInfo multiplyMethod = classType.GetMethod("Multiply", BindingFlags.NonPublic | BindingFlags.Instance);
        MethodInfo shiftRightMethod = classType.GetMethod("RightShift", BindingFlags.NonPublic | BindingFlags.Instance);
        MethodInfo shiftLeftMethod = classType.GetMethod("LeftShift", BindingFlags.NonPublic | BindingFlags.Instance);

        var input = Console.ReadLine();

        while (input != "END")
        {
            var splitted = input.Split('_').ToList();
            string command = splitted[0];
            int value = int.Parse(splitted[1]);

            switch (command)
            {
                case "Add":
                    addMethod.Invoke(classInstance, new object[] {value});
                    break;
                case "Subtract":
                    subtractMethod.Invoke(classInstance, new object[] {value});
                    break;
                case "Divide":
                    divideMethod.Invoke(classInstance, new object[] {value});
                    break;
                case "Multiply":
                    multiplyMethod.Invoke(classInstance, new object[] {value});
                    break;
                case "RightShift":
                    shiftRightMethod.Invoke(classInstance, new object[] {value});
                    break;
                case "LeftShift":
                    shiftLeftMethod.Invoke(classInstance, new object[] {value});
                    break;
            }

            Console.WriteLine(containerField.GetValue(classInstance));

            input = Console.ReadLine();
        }
    }
}

