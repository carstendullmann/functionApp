using OpenQA.Selenium;

namespace funcApp.vstests.e2e.PageObjects
{
    public class Page
    {
        private IWebDriver driver;
        public Page(IWebDriver driver)
        {
            this.driver = driver;
        }

        protected IWebDriver Driver
        {
            get
            {
                return this.driver;
            }
        }
    }
}
