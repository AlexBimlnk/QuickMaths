using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMaths.BL.Functions
{
    /// <summary>
    /// Переменная.
    /// </summary>
    public class Variable
    {
        public Variable(string name) => Name = name;
        public Variable(double value) => Value = value;
        public Variable(string name, double value)
        {
            Name = name;
            Value = value;
        }


        public string Name { get; }
        public double Value { get; set; } = Double.NaN;
    }
}
