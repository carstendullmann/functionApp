using OpenQA.Selenium;

namespace funcApp.vstests.e2e.PageObjects
{
    public class PageWithNavigationBar : Page
    {
        private NavigationBar navigationBar;
        public PageWithNavigationBar(IWebDriver driver) : base(driver)
        {
            this.navigationBar = new NavigationBar(driver);
        }

        public NavigationBar NavigationBar
        {
            get
            {
                return navigationBar;
            }
        }
    }
}
