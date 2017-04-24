using OpenQA.Selenium;
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

        public T GoTo<T>() where T : Page
        {
            Driver.FindElement(navSelectors[typeof(T)]).Click();
            return (T)Activator.CreateInstance(typeof(T), new object[] { Driver });
        }
    }
}
