using EngagementBreeze.Commands;
using System.Drawing;
using Console = Colorful.Console;

namespace EngagementBreeze
{
    class Program
    {
    static void Main(string[] args)
        {
            WelcomeUser();
            CommandFactory.Initialize();
            while (true)
            {
                string line = Console.ReadLine();
                string[] inputs = line.Split(' ');
                if (line == "exit")
                {
                    break;
                }
                if (CommandFactory.IsValidCommand(inputs[0]))
                {
                    Command requestedCommand = CommandFactory.GetCommand(line, inputs[0]);
                    requestedCommand.Execute();
                }
                else
                {
                    Console.WriteLine($"Sorry, '{line}' is not a supported command.", Color.Red);
                }
            }
        }

        private static void WelcomeUser()
        {
            Console.WriteLine("********************************************************", Color.Yellow);
            Console.WriteLine("       Welcome to the Engagement Breeze Console         ", Color.RoyalBlue);
            Console.WriteLine("       ----------------------------------------         ");
            Console.WriteLine("Acme Software Inc. - Making customer engagement a breeze", Color.RoyalBlue);
            Console.WriteLine("********************************************************", Color.Yellow);
            Console.WriteLine("Please enter any command (enter 'help' for available options)"); // Prompt
        }

    }
}
