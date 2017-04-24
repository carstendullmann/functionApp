using OpenQA.Selenium;
using System.Threading;

namespace funcApp.vstests.e2e.PageObjects
{
    public class HomePage : PageWithNavigationBar
    {
        public HomePage(IWebDriver driver) : base(driver) { }

        public Functions GoToFunctions()
        {
            // This is only a convenience method. We always delegat to the implementation
            // in the NavigationBar, so that if the nav bar in our app changes we will
            // only have to change in one place in our Page Objects.
            return NavigationBar.GoTo<Functions>();
        }
    }
}
