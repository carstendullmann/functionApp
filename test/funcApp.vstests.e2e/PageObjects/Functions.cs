using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

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
            EnterDoubleValue("SquareFunctionLowerBound", lowerBound);
            EnterDoubleValue("SquareFunctionUpperBound", upperBound);
            EnterDoubleValue("SquareFunctionInterval", interval);
            return this;
        }

        private void EnterDoubleValue(string id, double value)
        {
            // TODO: Make culture proof
            var box = Driver.FindElement(By.Id(id));
            box.Clear();
            box.SendKeys(value.ToString());
        }

        public Functions RequestCalculationOfSquareFunction()
        {
            Driver.FindElement(By.ClassName("btn-default")).Click();
            return this;
        }

        public IList<Tuple<double, double>> GetDisplayedValues()
        {
            var list = new List<Tuple<double, double>>();
            var pointDivs = Driver.FindElements(By.XPath("//div[@id='functionValues']/div[@id='point']"));
            var points = pointDivs.Select(d => double.Parse(d.Text)).ToArray();
            var valueDivs = Driver.FindElements(By.XPath("//div[@id='functionValues']/div[@id='value']"));
            var values = pointDivs.Select(d => double.Parse(d.Text)).ToArray();
            for (int i = 0; i < points.Length; i++)
            {
                list.Add(new Tuple<double, double>(points[i], values[i]));
            }

            return list;
        }
    }
}
