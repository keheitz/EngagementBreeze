using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EngagementBreeze.Commands
{
    public class CommandFactory
    {
        private static List<Command> commands = new List<Command>();

        public static void Initialize()
        {
            if (commands.Count == 0)
            {
                commands = Assembly.GetExecutingAssembly()
                                   .GetTypes()
                                   .Where(type => type.IsClass && !type.IsAbstract && type.IsSubclassOf(typeof(Command)))
                                   .Select(type => Activator.CreateInstance(type))
                                   .Cast<Command>()
                                   .ToList();
            }
        }

        internal static Command GetCommand(string inputLine, string commandName)
        {
            Command command = commands.Where(m => m.GetName().ToLower() == commandName.ToLower()).FirstOrDefault();
            if (command != null) { command._input = inputLine; }
            return command;
        }

        public static List<string> GetCommandInformation()
        {
            List<string> commandInfo = new List<string>();
            foreach(var command in commands)
            {
                commandInfo.Add($"'{command.GetFormat()}': {command.GetDefinition()}");
            }
            return commandInfo;
        }

        public static bool IsValidCommand(string command)
        {
            if(!commands.Any(c => c.GetName().ToLower() == command.ToLower()))
            {
                return false;
            }
            return true;
        }
    }
}
