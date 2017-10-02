using System;
using System.Linq;

namespace _03BarracksFactory.Core
{
    using System.Reflection;
    using Attributes;
    using Contracts;
    public class CommandInterpreter : ICommandInterpreter
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            string firstLet = commandName[0].ToString().ToUpper();
            string rest = string.Join("", commandName.Skip(1));

            string commandClassName = firstLet + rest;

            Type classType = Type.GetType("_03BarracksFactory.Core.Commands." + commandClassName + "Command");
            ConstructorInfo constructor =
                classType.GetConstructor(new Type[]
                    {data.GetType()});

            IExecutable instance = (IExecutable) constructor.Invoke(new object[] {data});

            this.InjectAttributes(instance);

            return instance;
        }

        private void InjectAttributes(IExecutable instance)
        {
            Type instanceType = instance.GetType();

            var fields = instanceType
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => f.GetCustomAttributes(false).Any(x => x.GetType() == typeof(InjectAttribute)));

            var currentTypeFields = this.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (FieldInfo field in fields)
            {
                foreach (var currentField in currentTypeFields)
                {
                    var firstField = field.GetType();
                    var secondField = currentField.GetType();
                    if (field.FieldType == currentField.FieldType)
                    {
                        field.SetValue(instance, currentField.GetValue(this));
                    }
                }
            }

        }
    }
}
