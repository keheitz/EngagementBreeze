using Microsoft.VisualStudio.TestTools.UnitTesting;
using EngagementBreeze.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commands.Tests
{
    [TestClass()]
    public class CommandsTests
    {
        [TestMethod()]
        public void IsValidCommandTest()
        {
            CommandFactory.Initialize();
            Assert.IsTrue(CommandFactory.IsValidCommand("help"));
        }

        [TestMethod()]
        public void IsNotValidCommandTest()
        {
            CommandFactory.Initialize();
            Assert.IsFalse(CommandFactory.IsValidCommand("zippitydoodah"));
        }
    }
}