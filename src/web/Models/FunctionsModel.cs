using System;
using System.Collections.Generic;

namespace funcApp.Models
{
    public class FunctionsModel
    {
        public FunctionsModel()
        {
            SquareFunctionLowerBound = -1;
            SquareFunctionUpperBound = 1;
            SquareFunctionInterval = 1;
            Values = new List<Tuple<double,double>>();
        }

        public double SquareFunctionLowerBound;
        public double SquareFunctionUpperBound;
        public double SquareFunctionInterval;
        public IList<Tuple<double,double>> Values;
    }
}