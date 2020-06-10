namespace EngagementBreeze.Commands
{
    class ExitCommand : Command
    {

        public override void Execute()
        {
            //Exit will break the loop in program, no other functionality needs to be supported here
            return;
        }

        public override string GetDefinition() => "leave the application";

        public override string GetFormat() => GetName();

        public override string GetName() => "exit";
    }
}
