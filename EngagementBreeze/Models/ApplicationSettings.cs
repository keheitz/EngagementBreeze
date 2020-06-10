using System.Collections.Generic;

namespace EngagementBreeze.Models
{
    /// <summary>
    /// Singleton Class for managing configurable application settings
    /// </summary>
    public class ApplicationSettings
    {
        private Dictionary<ConfigurableSettings,string> _settingValues = new Dictionary<ConfigurableSettings, string>() {
            { ConfigurableSettings.ApiKey, "yoursecretkey"},
            { ConfigurableSettings.City, "Minneapolis" },
            { ConfigurableSettings.RainyThreshold, "50" },
            { ConfigurableSettings.SunnyThreshold, "30" }
        };

        private static ApplicationSettings _instance;
        //private constructor
        private ApplicationSettings() { }

        public static ApplicationSettings GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ApplicationSettings();
            }
            return _instance;
        }

        public void UpdateSetting(ConfigurableSettings setting, string value)
        {
            if (_settingValues.ContainsKey(setting))
            {
                _settingValues[setting] = value;
            }
        }

        public string GetSettingValue(ConfigurableSettings setting)
        {
            return _settingValues[setting] ?? "";
        }

        public List<string> GetListOfSettingsAndValues()
        {
            List<string> currentSettings = new List<string>();
            foreach(var setting in _settingValues)
            {
                currentSettings.Add($"{setting.Key}: {(int)setting.Key} {setting.Value}");
            }
            return currentSettings;
        }
    }
}