using Microsoft.VisualStudio.TestTools.UnitTesting;
using EngagementBreeze.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EngagementBreeze.ModelsTests
{
    [TestClass()]
    public class ApplicationSettingsTests
    {
        [TestMethod()]
        public void UpdateSetting_SuccessfulResult()
        {
            string testCity = "Houston";
            ApplicationSettings.GetInstance().UpdateSetting(ConfigurableSettings.City, testCity);
            Assert.AreEqual(ApplicationSettings.GetInstance().GetSettingValue(ConfigurableSettings.City), testCity);
        }

        [TestMethod()]
        public void UpdateSetting_Unsuccessful_NotASetting()
        {
            string fakeSettingValue = "this_is_not_a_value_for_any_setting";
            ApplicationSettings.GetInstance().UpdateSetting((ConfigurableSettings)7, fakeSettingValue);
            Assert.IsFalse(ApplicationSettings.GetInstance().GetListOfSettingsAndValues().Any(x => x.Contains(fakeSettingValue)));
        }

        [TestMethod()]
        public void GetListOfSettingsAndValues_ResultCountMatchesCountOfDefinedSettings()
        {
            Assert.AreEqual(ApplicationSettings.GetInstance().GetListOfSettingsAndValues().Count(), Enum.GetNames(typeof(ConfigurableSettings)).Length);
        }
    }
}