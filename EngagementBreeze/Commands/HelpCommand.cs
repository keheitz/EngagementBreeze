using System;

namespace EngagementBreeze.Commands
{
    class HelpCommand : Command
    {
        public override void Execute()
        {
            foreach(String helpInfo in CommandFactory.GetCommandInformation())
            {
                Console.WriteLine(helpInfo);
            }
        }

        public override string GetDefinition() => "prints list of supported commands and their expected format";

        public override string GetFormat() => GetName();

        public override string GetName() => "help";
    }
}
