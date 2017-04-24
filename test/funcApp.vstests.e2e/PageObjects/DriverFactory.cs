using System;
using OpenQA.Selenium;

namespace funcApp.vstests.e2e.PageObjects
{
    public class DriverFactory
    {
        public virtual IWebDriver CreateDriver()
        {
            // Currently we have everything we need for our tests in 
            // this one method and we do not parameterize anything
            // specific to individual tests. If a need for this will come
            // up, e.g. because a test will need to start somewhere else
            // than all the other tests, this can be extended as needed.
            var driver = (IWebDriver)Activator.CreateInstance(GetDriverType());
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl(TestRunParameters.HomeUrl);
            return driver;
        }

        private static Type GetDriverType()
        {
            Type driverType = Type.GetType(TestRunParameters.DriverType);
            if (driverType == null)
            {
                driverType = Type.GetType($"{TestRunParameters.DriverType}, WebDriver, Version = 3.3.0.0, Culture = neutral, PublicKeyToken = null");
            }

            return driverType;
        }
    }
}
