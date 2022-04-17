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
    public class Variable : IFunction
    {
        public Variable(string name)
        {
            if(name == string.Empty)
                throw new ArgumentException("Название переменной не может быть пустым.", nameof(name));

            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
        public Variable(string name, double value)
        {
            if (name == string.Empty)
                throw new ArgumentException("name");

            Name = name ?? throw new ArgumentNullException("name");
            Value = value;
        }

        public string Name { get; init; }
        public double Value { get; set; }

        public double Calculate()
        {
            return Value;
        }
        public IFunction Derivative()
        {
            return new NumberFunction(1);
        }
        public override string ToString()
        {
            return Name; 
        }
    }
}
