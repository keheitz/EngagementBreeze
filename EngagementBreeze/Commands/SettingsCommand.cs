using EngagementBreeze.Models;
using System;

namespace EngagementBreeze.Commands
{
    class SettingsCommand : Command
    {

        public override void Execute()
        {
            foreach (var setting in ApplicationSettings.GetInstance().GetListOfSettingsAndValues())
            {
                Console.WriteLine(setting);
            }
        }

        public override string GetDefinition() => "prints list of the application settings in the following format - '<name>:<code> <current value>";

        public override string GetFormat() => GetName();

        public override string GetName() => "settings";
    }
}
