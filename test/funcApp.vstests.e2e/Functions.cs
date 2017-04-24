using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using System;
using funcApp.vstests.e2e.PageObjects;

namespace funcApp.vstests.e2e
{
    [TestClass]
    public class Functions
    {
        [TestMethod]
        public void RangeForFunctionsIsCreatedAfterRangeIsEntered()
        {
            using (var driver = new DriverFactory().CreateDriver())
            {
                var page = new HomePage(driver)
                    .GoToFunctions()
                    .EnterRangeAndIntervalForSquareFunction(-1.0, 1.0, 1.0)
                    .RequestCalculationOfSquareFunction();
                var actualValues = page.GetDisplayedValues();
                Assert.AreEqual(3, actualValues.Count);
                Assert.AreEqual(-1.0, actualValues[0].Item1);
                Assert.AreEqual(0.0, actualValues[1].Item1);
                Assert.AreEqual(1.0, actualValues[2].Item1);
            }
        }
    }
}
