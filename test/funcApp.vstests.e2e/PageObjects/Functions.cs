using System;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace funcApp.vstests.e2e.PageObjects
{
    public class Functions : PageWithNavigationBar
    {
        public Functions(IWebDriver driver) : base(driver) { }

        public string Text
        {
            get
            {
                return Driver.PageSource;
            }
        }

        public Functions EnterRangeAndIntervalForSquareFunction(double lowerBound, double upperBound, double interval)
        {
            throw new NotImplementedException();
        }

        public Functions RequestCalculationOfSquareFunction()
        {
            throw new NotImplementedException();
        }

        public IList<Tuple<double,double>> GetDisplayedValues()
        {
            throw new NotImplementedException();
        }
    }
}
