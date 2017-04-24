using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using System;

namespace funcApp.vstests.e2e.PageObjects
{
    [TestClass]
    public class TestRunParameters
    {
        // This is currently dependent on MSTest. To use another testing framework 
        // you would need to change this to that framework's method of passing in
        // parameters. Or yet another way, e.g. app.config.

        public static string HomeUrl { get; private set; } = "http://localhost:8000";
        public static string DriverType { get; private set; } = "OpenQA.Selenium.PhantomJS.PhantomJSDriver";

        [AssemblyInitialize]
        public static void Init(TestContext TestContext)
        {
            if (TestContext.Properties.Contains("homeUrl")) // No .TryGetValue() here unfortunately
            {
                HomeUrl = (string)TestContext.Properties["homeUrl"];
            }

            if (TestContext.Properties.Contains("driverType"))
            {
                DriverType = (string)TestContext.Properties["driverType"];
            }
        }
    }
}
