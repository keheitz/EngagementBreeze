using EngagementBreeze.Models;
using System;
using System.Drawing;
using Console = Colorful.Console;

namespace EngagementBreeze.Commands
{
    class UpdateCommand : Command
    {
        private int _code;
        public override void Execute()
        {
            string[] inputValues = _input.Split(' ');
            if (inputValues.Length < 3)
            {
                Console.WriteLine("Not enough values provided for setting", Color.Red);
                Console.WriteLine("update <code> <desiredValue>");
                return;
            }
            if (!Int32.TryParse(inputValues[1], out _code))
            {
                Console.WriteLine("Code parameter must be a numerical value", Color.Red);
                return;
            }
            ConfigurableSettings setting = (ConfigurableSettings)_code;
            if (setting == ConfigurableSettings.RainyThreshold ||
                (setting == ConfigurableSettings.SunnyThreshold))
            {
                int thresholdVal = ValidateThresholdValue(inputValues[2]);
                ApplicationSettings.GetInstance().UpdateSetting(setting, thresholdVal.ToString());
                Console.WriteLine($"\t{setting} updated");
                return;
            }
            ApplicationSettings.GetInstance().UpdateSetting(setting, inputValues[2]);
            Console.WriteLine($"\t{setting} updated");
        }

        public override string GetDefinition() => "sets the setting for the provided code to the entered value";

        public override string GetFormat() => "update <code> <value>";

        public override string GetName() => "update";

        /// <summary>
        /// Validate our threshold values to ensure setting provided is an integer between 1-100
        /// </summary>
        /// <param name="inputValues"></param>
        /// <returns></returns>
        private static int ValidateThresholdValue(string value)
        {
            int thresholdVal;
            if (!Int32.TryParse(value, out thresholdVal))
            {
                Console.WriteLine("Value input must be an integer", Color.Red);
            }
            if (thresholdVal <= 0 || thresholdVal > 100)
            {
                Console.WriteLine("Value input must be between 1-100 for this setting.", Color.Red);
            }

            return thresholdVal;
        }
    }
}
