using System;
using System.Collections.Generic;
using funcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace funcApp.Controllers
{
    public class FunctionsController : Controller
    {
        public IActionResult Edit()
        {
            var functions = new FunctionsModel();
            return View(functions);
        }

        [HttpPost]
        public IActionResult Edit(double squareFunctionLowerBound, double squareFunctionUpperBound, double squareFunctionInterval)
        {
            // deliberately commiting the fat controller antipattern
        
            var x = squareFunctionLowerBound;
            var interval = squareFunctionInterval >= 0 ? squareFunctionInterval : 1.0;
            var upper = squareFunctionUpperBound >= squareFunctionLowerBound ? squareFunctionUpperBound : squareFunctionLowerBound;

            var functions = new FunctionsModel();
            
            // wasting a bit of performance

            for (int i = 0; i<10000; i++)
            {
                var list = new List<Tuple<double,double>>();
                while (x <= squareFunctionUpperBound)
                {
                    list.Add(new Tuple<double,double>(x, Math.Pow(x, 2)));
                    x += interval;
                }

                functions.SquareFunctionInterval = squareFunctionInterval;
                functions.SquareFunctionLowerBound = squareFunctionLowerBound;
                functions.SquareFunctionUpperBound = squareFunctionUpperBound;
                functions.Values = list;

                // wasting more performance
                try
                {
                    throw new Exception($"Blah {i}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }

            return View(functions);
        }
        
    }
}
