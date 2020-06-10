namespace EngagementBreeze
{
    public abstract class Command
    {
        public string _input { get; set; }

        public abstract void Execute();

        public abstract string GetFormat();

        public abstract string GetDefinition();

        public abstract string GetName();
    }
}
