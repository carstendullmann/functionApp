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
        
            var list = new List<Tuple<double,double>>();
            var x = squareFunctionLowerBound;
            var interval = squareFunctionInterval >= 0 ? squareFunctionInterval : 1.0;
            var upper = squareFunctionUpperBound >= squareFunctionLowerBound ? squareFunctionUpperBound : squareFunctionLowerBound;

            while (x <= squareFunctionUpperBound)
            {
                list.Add(new Tuple<double,double>(x, Math.Pow(x, 2)));
                x += interval;
            }

            var functions = new FunctionsModel();
            functions.SquareFunctionInterval = squareFunctionInterval;
            functions.SquareFunctionLowerBound = squareFunctionLowerBound;
            functions.SquareFunctionUpperBound = squareFunctionUpperBound;
            functions.Values = list;

            return View(functions);
        }
        
    }
}
