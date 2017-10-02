namespace _03BarracksFactory.Core.Commands
{
    using Contracts;
    public abstract class Command : IExecutable
    {
        private string[] data;
       
        protected Command(string[] data)
        {
            this.data = data;
        }

        public string[] Data
        {
            get { return this.data; }
            set { this.data = value; }
        }
        
        public abstract string Execute();
    }
}
