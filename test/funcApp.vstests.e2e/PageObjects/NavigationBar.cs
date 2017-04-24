using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace funcApp.vstests.e2e.PageObjects
{
    public class NavigationBar : Page
    {
        public NavigationBar(IWebDriver driver) : base(driver) { }

        private static IDictionary<Type, By> navSelectors = new Dictionary<Type, By>()
        {
            // TODO: Extend when needed
            { typeof(Functions), By.XPath("//a[@href='/Functions/Edit']") },
            { typeof(HomePage), By.XPath("//a[@href='/']") },
        };

        public static Func<IWebDriver, IWebElement> ElementIsClickable(By locator)
        {
            return driver =>
            {
                var element = driver.FindElement(locator);
                return (element != null && element.Displayed && element.Enabled) ? element : null;
            };
        }

        public T GoTo<T>() where T : Page
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            var clickableLink = wait.Until(ElementIsClickable(navSelectors[typeof(T)]));
            clickableLink.Click();
            return (T)Activator.CreateInstance(typeof(T), new object[] { Driver });
        }
    }
}
